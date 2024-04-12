/* Dylan Parson
 * Desktop Application For iGPS Help Desk team to clear containers, change statuses and other
 * common tasks more efficiently and reduce errors.
 *
 */


using iGPS_Help_Desk.Models;
using iGPS_Help_Desk.Repositories;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace iGPS_Help_Desk.Views
{
    public partial class Igps : BaseForm
    {
        private Timer closeTimer;
        private readonly ILogger _logger = Log.ForContext<Igps>();
        private List<IGPS_DEPOT_GLN> igpsDepotGln = new List<IGPS_DEPOT_GLN>();
        private bool showButtonClicked = false;
        public Igps()
        {
            InitializeComponent();
            InitialLoad();

            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                var settings = configFile.AppSettings.Settings;

                int timeout = Int32.Parse(settings["timeout"].Value);
                // Initialize the timer
                closeTimer = new Timer();
                closeTimer.Interval = timeout; // 30 minutes in milliseconds
                closeTimer.Tick += CloseTimer_Tick;
                closeTimer.Start();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.ToString());
                closeTimer.Interval = 1800000; // if the config file value was not found, set to 30 minutes
            }
        }

        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            // Timer has elapsed, close the application
            Application.Exit();
        }


        // Parses GLNs from the list entered from form
        private List<string> ParseGln(string glnList)
        {
            string[] delimiters = { "\n", "\r\n", " ", "'" };

            List<string> tempList = new List<string>();

            // removes empty items after split for carriage returns
            tempList.AddRange(glnList.Split(delimiters, StringSplitOptions.RemoveEmptyEntries));

            return tempList;
        }

        // ------------------------ CLEAR CONTAINERS -------------------------------//
        private void ClearContainerFields()
        {
            txtContainersToClear.Text = string.Empty;
            txtNumToBeDeleted.Text = string.Empty;
            lvGlnContent.Items.Clear();
        }
        // Deletes GLNS from IGPS_DEPOT_GLN and IGPS_DEPOT_LOCATION
        private void ClickClearContainers(object sender, EventArgs e)
        {
            if (!showButtonClicked)
            {
                MessageBox.Show("Click 'Show Content'");
                return;
            }
            if (lvGlnContent.Items.Count == 0 && txtContainersToClear.Text == "")
            {
                lblErrorMessage.Text = "No containers entered";
                lblErrorMessage.Visible = true;
                return;
            }

            // Initial List from user of glns (will be parsed to get rid of spaces, returns, quotes, etc)
            List<string> glnList = new List<string>();

            // Parsed list
            glnList = ParseGln(txtContainersToClear.Text);
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete {lvGlnContent.Items.Count} Grais and " +
                $"{glnList.Count} containers?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response
            if (result == DialogResult.Yes)
            {
                _clearContainerController.ClearContainers(glnList);
                lvGlnContent.Items.Clear();
                lblErrorMessage.Visible = false;
            }

            GC.Collect();
        }

        // Updates list in view
        private void UpdateContainerClearList(List<IGPS_DEPOT_GLN> listGlns, List<IGPS_DEPOT_LOCATION> locationGlns,
            List<string> totalList)
        {
            ClearContainerFields();
            if (listGlns == null) return;

            // Update Text box of containers entered to only show distinct containers
            var newList = locationGlns.Select(x => x.Gln).Distinct();
            foreach (string gln in totalList)
            {
                txtContainersToClear.AppendText($"{gln}\r\n");
            }

            // Outputs them to List View to show details for every GRAI
            for (int i = 0; i < listGlns.Count; i++)
            {
                var item = new ListViewItem(listGlns.ElementAt(i).Gln);
                item.SubItems.Add(listGlns.ElementAt(i).Grai);
                item.SubItems.Add(listGlns.ElementAt(i).Date_Time.ToString());

                lvGlnContent.Items.Add(item);
            }

            txtNumToBeDeleted.Text = listGlns.Count.ToString();
        }

        private void ClickShowContent(object sender, EventArgs e)
        {
            ShowContent();
        }

        private async void ShowContent()
        {
            showButtonClicked = true;
            if (txtContainersToClear.Text == string.Empty)
            {
                lblErrorMessage.Text = "No containers entered";
                lblErrorMessage.Visible = true;
                return;
            }

            // Initial List from user of glns (will be parsed to get rid of spaces, returns, quotes, etc)
            List<string> glnList = new List<string>();

            // Lists that will be returned from database

            // Parsed list
            glnList = ParseGln(txtContainersToClear.Text);

            // List from db
            try
            {
                igpsDepotGln = await _clearContainerController.GetContainersFromList(glnList);
                var igpsDepotLocation = await _clearContainerController.GetLocationContainersFromList(glnList);

                var totalList = new List<string>();

                foreach (var depotGln in igpsDepotGln)
                {
                    totalList.Add(depotGln.Gln);
                }

                foreach (var depotLocation in igpsDepotLocation)
                {
                    totalList.Add(depotLocation.Gln);
                }

                totalList = totalList.Distinct().ToList();
                UpdateContainerClearList(igpsDepotGln, igpsDepotLocation, totalList);
                lblErrorMessage.Visible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async void BtnSaveContent(object sender, EventArgs e)
        {
            bool saveSnapshot = false;

            if (!showButtonClicked)
            {
                MessageBox.Show("Click 'Show Content'");
                return;
            }

            if (txtContainersToClear.Text == "")
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "No containers entered";
                return;
            }

            if (_clearContainerPath == "")
            {
                MessageBox.Show("No file path shown");
                return;
            }

            // Save current container clear request
            List<string> zoutGlnList = ParseGln(txtContainersToClear.Text);
            string zoutCount = zoutGlnList.Count.ToString();

            // Get data for snapshot
            if (cbSaveSnapshot.Checked)
            {
                saveSnapshot = true;
                var allContainers = await _clearContainerController.GetAllContainers();

                var allGlnList = new List<string>();

                foreach (IGPS_DEPOT_GLN gln in allContainers.Item1)
                {
                    allGlnList.Add(gln.Gln);
                }

                await _csvFileController.SaveCsvFilesAndZip(txtNumToBeDeleted.Text, zoutGlnList, allGlnList,
                    allContainers.Item2.ToString(), saveSnapshot, igpsDepotGln);
            }
            else
            {
                List<string> emptyList = new List<string>();
                await _csvFileController.SaveCsvFilesAndZip(txtNumToBeDeleted.Text, zoutGlnList, emptyList, "0",
                    saveSnapshot, igpsDepotGln);
            }

            _clearContainerPath = ConfigurationManager.AppSettings.Get("clearContainerPath");
            MessageBox.Show("Files have been saved to " + _clearContainerPath);
            lblErrorMessage.Visible = false;
            // Gets rid of excess memory usage from snapshot
            GC.Collect();
        }

        private async void BtnFindGhosts(object sender, EventArgs e)
        {
            var result = await _clearContainerController.GetGhostGrais();

            if (result.Count == 0)
            {
                lblErrorMessage.Text = "No Ghosts found";
                lblErrorMessage.Visible = true;
                return;
            }

            foreach (var g in result)
            {
                txtContainersToClear.Text += $"{g}\r\n";
            }

            lblErrorMessage.Visible = false;
        }

        private async void ClickGetDnus(object sender, EventArgs e)
        {
            try
            {
                var glnList = await _clearContainerController.GetDnus();

                foreach (var g in glnList.Item2)
                {
                    txtContainersToClear.Text += $"{g.Gln}\r\n";
                }

                lblErrorMessage.Visible = false;
            }
            catch
            {
                lblErrorMessage.Text = "No DNUs found";
                lblErrorMessage.Visible = true;
            }
        }

        private void ClickSettings(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
            _siteId = ConfigurationManager.AppSettings.Get("siteId");
            _clearContainerPath = ConfigurationManager.AppSettings.Get("clearContainerPath");
        }

        private void ClickContainerCancel(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
            showButtonClicked = false;
            ClearContainerFields();
        }


        // --------------------------- Rollback Tab ----------------------------

        private void ClickRollback(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }


        // --------------------------- Search Containers ------------------------


        private void LoadContainers(List<IGPS_DEPOT_LOCATION> listContainers)
        {
            lvPlacards.Items.Clear();

            // Outputs them to List View
            foreach (var container in listContainers)
            {
                var item = new ListViewItem(container.Gln);
                item.SubItems.Add(container.Description);
                item.SubItems.Add(container.Status);
                item.SubItems.Add(container.SubStatus);
                item.SubItems.Add(container.Count.ToString());
                lvPlacards.Items.Add(item);
            }
        }

        private async void InitialLoad()
        {
            var result = new List<IGPS_DEPOT_LOCATION>();

            if (tbSearchBar.Text.Length > 0)
            {
                result = await _moveContainerController.ReadContainersFromSearch(tbSearchBar.Text);
            }
            else
            {

                result = await _moveContainerController.ReadAllContainers();
            }

            LoadContainers(result);
        }


        private void ReloadContainers(object sender, EventArgs e)
        {
            InitialLoad();
        }

        private void moveExisitngForm(object sender, EventArgs e)
        {
            if (lvPlacards.SelectedItems.Count == 0) return;

            var fromGln = lvPlacards.SelectedItems[0].Text;
            var moveContainerForm = new ClearGraisForm(fromGln);
            moveContainerForm.ShowDialog();
        }


        private async void searchContainersText(object sender, EventArgs e)
        {
            var result = await _moveContainerController.ReadContainersFromSearch(tbSearchBar.Text);

            LoadContainers(result);
        }

        private void addToClearList(object sender, EventArgs e)
        {
            if (lvPlacards.SelectedItems.Count == 0) return;

            for (int i = 0; i < lvPlacards.SelectedItems.Count; i++)
            {
                txtContainersToClear.AppendText($"{lvPlacards.SelectedItems[i].Text}\r\n");
            }

            ShowContent();
            lblContainersAddSuccess.Visible = true;
        }
    }
}