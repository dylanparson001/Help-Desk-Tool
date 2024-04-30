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
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace iGPS_Help_Desk.Views
{
    public partial class Igps : BaseForm
    {
        private Timer closeTimer;
        private readonly ILogger _logger = Log.ForContext<Igps>();
        private List<IGPS_DEPOT_GLN> igpsDepotGln = new List<IGPS_DEPOT_GLN>();
        private List<string> ordersEntered = new List<string>();
        private bool showButtonClicked = false;
        private bool saveButtonClicked = false;
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
        }


        // Parses GLNs from the list entered from form
        private List<string> ParseGln(string glnList)
        {
            string[] delimiters = { "\n", "\r\n", " ", "'", "•", "\t" };

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
            if (!saveButtonClicked)
                if (!saveButtonClicked)
                {
                    MessageBox.Show("Please save GRAIs before clearing containers", "GRAIs not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            saveButtonClicked = false;
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
            MessageBox.Show("Files have been saved to " + _clearContainerPath, "File Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblErrorMessage.Visible = false;
            saveButtonClicked = true;
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
            saveButtonClicked = false;
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

        // Order Removal Tab -----------------------------------------------------------------
        private async void clickShowOrder(object sender, EventArgs e)
        {
            await ReloadShowOrders();
        }

        private async void clickRemoveOrders(object sender, EventArgs e)
        {
            var orderIdList = new List<string>();

            if (lvOrders.CheckedItems.Count == 0)
            {
                lblError.Text = "No orders selected";
                lblError.Visible = true;
                return;
            }
            lblError.Visible = false;
            for (int i = 0; i < lvOrders.CheckedItems.Count; i++)
            {
                orderIdList.Add(lvOrders.CheckedItems[i].Text);
            }

            DialogResult userChoice = MessageBox.Show($"Are you sure you want to remove {orderIdList.Count}" +
                $" orders from iSum?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (userChoice == DialogResult.Yes)
            {
                await _orderController.RemoveSelectedOrders(orderIdList);
                await ReloadShowOrders();
            }

        }

        private async Task ReloadShowOrders()
        {
            if (String.IsNullOrEmpty(txtBols.Text))
            {
                lblError.Text = "No Bols entered!";
                lblError.ForeColor = Color.Red;
                lblError.Visible = true;
                lvOrders.Items.Clear();
                return;
            };

            lblError.Visible = false;

            lvOrders.CheckBoxes = true;
            lvOrders.Items.Clear();
            var parsedBol = ParseGln(txtBols.Text);

            parsedBol = parsedBol.Select(x => x.ToString()).Distinct().ToList();

            txtBols.Clear();
            foreach (var bol in parsedBol)
            {
                txtBols.AppendText($"{bol} \r\n");

            }
            var bolResult = await _orderController.GetBolsFromList(parsedBol);



            bolResult = bolResult
                .OrderBy(x => x.BolId)
                .OrderBy(x => x.STATUS_DATE)
                .ToList();

            for (int i = 0; i < bolResult.Count; i++)
            {
                string status = bolResult[i].PROCESSING_STATUS;

                if (String.IsNullOrEmpty(status))
                {
                    status = "NULL";
                }


                var item = new ListViewItem(bolResult[i].OrderId);
                item.SubItems.Add(bolResult[i].BolId);
                item.SubItems.Add(status);
                item.SubItems.Add(bolResult[i].FacilityId_Source);
                item.SubItems.Add(bolResult[i].STATUS_DATE.ToString());
                item.SubItems.Add(bolResult[i].RequestedQuantity.ToString());


                // Alternate row colors
                if (i % 2 == 0)
                {
                    item.BackColor = Color.LightBlue;
                }

                lvOrders.Items.Add(item);
            }
            cbCheckAllOrders.Checked = false;

        }

        private async void clickChangeQuantity(object sender, EventArgs e)
        {
            var orderIdList = new List<string>();

            if (lvOrders.CheckedItems.Count == 0)
            {
                lblError.Text = "No orders selected";
                lblError.Visible = true;
                return;
            }
            lblError.Visible = false;


            for (int i = 0; i < lvOrders.CheckedItems.Count; i++)
            {
                orderIdList.Add(lvOrders.CheckedItems[i].Text);
            }
            int newQuantity = Show("Enter a new quantity:", "New Quantity");

            // value will be 0 on cancel
            if (newQuantity != 0)
            {
                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to change the quantity to" +
                    $"{newQuantity}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    await _orderController.UpdateRequestedQuantity(newQuantity, orderIdList);
                }
            }

            await ReloadShowOrders();
        }

        public static int Show(string prompt, string caption)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = caption;
            label.Text = prompt;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new System.Drawing.Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new System.Drawing.Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                int result;
                if (int.TryParse(textBox.Text, out result))
                {
                    return result;
                }
                else
                {
                    MessageBox.Show("Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return Show(prompt, caption);
                }
            }
            else
            {
                return 0;
            }
        }

        private void clickCheckAll(object sender, EventArgs e)
        {
            if (cbCheckAllOrders.Checked)
            {
                for (int i = 0; i < lvOrders.Items.Count; i++)
                {
                    lvOrders.Items[i].Checked = true;
                }
                return;
            }
            for (int i = 0; i < lvOrders.Items.Count; i++)
            {
                lvOrders.Items[i].Checked = false;
            }
        }
    }
}