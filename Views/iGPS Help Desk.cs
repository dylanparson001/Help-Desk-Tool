﻿/* Dylan Parson
 * Desktop Application For iGPS Help Desk team to clear containers, change statuses and other
 * common tasks more efficiently and reduce errors.
 *
 */


using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using iGPS_Help_Desk.Models;

namespace iGPS_Help_Desk.Views
{
    public partial class Igps : BaseForm
    {

        public Igps()
        {
            InitializeComponent();
            GetStatuses();
            InitialLoad();
        }

        //  ------------- Status Change Tab  ---------------------------------// 
        private async void ClickStatusChange(object sender, EventArgs e)
        {
            if (txtGlnList.Text == "")
            {
                MessageBox.Show("No Containers");
                return;
            }

            if (cbNewStatus.Text == "" || cbNewSubStatus.Text == "")
            {
                MessageBox.Show("Enter a status and substatus");
                return;
            }

            List<string> listGlns = new List<string>();
            string inputFromUser = txtGlnList.Text;
            string newStatus = cbNewStatus.GetItemText(cbNewStatus.Text);
            string newSubStatus = cbNewSubStatus.GetItemText(cbNewSubStatus.Text);

            List<string> newList = ParseGln(inputFromUser);

            string stringGlns = string.Join(",", newList.Select(i => $"'{i}'"));

            List<IGPS_DEPOT_LOCATION> listContainers = await _changeStatusController.ChangeStatus(stringGlns,
                newStatus, newSubStatus);

            UpdateGlnList(listContainers);
        }

        private async void GetStatuses()
        {
            var listStatuses = new List<string>();

            listStatuses = await _facilityContainerStatusRepository.GetStatuses();

            listStatuses = listStatuses.Distinct().ToList();

            foreach (string status in listStatuses)
            {
                cbNewStatus.Items.Add(status);

            }

        }
        // Click the dropdown list for 
        private void statusSelected(object sender, EventArgs e)
        {
            cbNewSubStatus.Items.Clear();
            GetSubStatuses(cbNewStatus.SelectedItem.ToString());
        }

        private void GetSubStatuses(string selectedStatus)
        {
            var listSubStatuses = new List<string>();

            listSubStatuses = _facilityContainerStatusRepository.GetSubStatusesFromStatus(selectedStatus);

            listSubStatuses = listSubStatuses.Distinct().ToList();

            // listGlns.Select(x => x.Gln).Distinct();
            foreach (string subStatus in listSubStatuses)
            {
                cbNewSubStatus.Items.Add(subStatus);

            }

        }
        private void ClickCancel(object sender, EventArgs e)
        {
            ClearStatusFields();
        }

        private void ClearStatusFields()
        {
            txtGlnList.Text = string.Empty;
            cbNewStatus.Text = string.Empty;
            cbNewSubStatus.Text = string.Empty;
            lvGlnList.Items.Clear();
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

        private void UpdateGlnList(List<IGPS_DEPOT_LOCATION> listGlns)
        {

            //// Prevents repeating previous outputs
            lvGlnList.Items.Clear();

            //Outputs them to List View
            for (int i = 0; i < listGlns.Count; i++)
            {
                var item = new ListViewItem(listGlns.ElementAt(i).Gln);
                item.SubItems.Add(listGlns.ElementAt(i).Status);
                item.SubItems.Add(listGlns.ElementAt(i).SubStatus);

                lvGlnList.Items.Add(item);
            }
        }
        // ------------------------ CLEAR CONTAINERS -------------------------------//
        private void ClearContainerFields()
        {
            txtGlnList.Text = string.Empty;
            txtContainersToClear.Text = string.Empty;
            txtNumToBeDeleted.Text = string.Empty;
            lvGlnContent.Items.Clear();
        }

        private void ClickClearContainers(object sender, EventArgs e)
        {
            if (lvGlnContent.Items.Count == 0 && txtContainersToClear.Text == "")
            {
                MessageBox.Show("Container list is empty");
                return;
            }

            // Initial List from user of glns (will be parsed to get rid of spaces, returns, quotes, etc)
            List<string> glnList = new List<string>();

            // Parsed list
            glnList = ParseGln(txtContainersToClear.Text);

            _clearContainerController.ClearContainers(glnList);
            lvGlnContent.Items.Clear();
        }

        // Updates list in view
        private void UpdateContainerClearList(List<IGPS_DEPOT_GLN> listGlns, List<IGPS_DEPOT_LOCATION> locationGlns)
        {
            ClearContainerFields();
            if (listGlns == null) return;

            // Update Text box of containers entered to only show distinct containers
            var newList = locationGlns.Select(x => x.Gln).Distinct();
            foreach (string gln in newList)
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
        private void UpdateDnuContainerClearList(List<IGPS_DEPOT_GLN> listGlns)
        {
            ClearContainerFields();
            if (listGlns == null) return;

            // Update Text box of containers entered to only show distinct containers
            var newList = listGlns.Select(x => x.Gln).Distinct();
            foreach (string gln in newList)
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

        private async void ClickShowContent(object sender, EventArgs e)
        {
            if (txtContainersToClear.Text == string.Empty)
            {
                MessageBox.Show("Container list is empty");
                return;
            }
            // Initial List from user of glns (will be parsed to get rid of spaces, returns, quotes, etc)
            List<string> glnList = new List<string>();

            // Lists that will be returned from database
            var igpsDepotGln = new List<IGPS_DEPOT_GLN>();

            // Parsed list
            glnList = ParseGln(txtContainersToClear.Text);

            // List from db
            try
            {
                igpsDepotGln = await _clearContainerController.GetContainersFromList(glnList);
                var igpsDepotLocation = _clearContainerController.GetLocationContainersFromList(glnList);
                UpdateContainerClearList(igpsDepotGln, await igpsDepotLocation);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }


        private async void BtnSaveContent(object sender, EventArgs e)
        {
            if (lvGlnContent.Items.Count == 0)
            {
                MessageBox.Show("Container list is empty");
                return;
            }

            if (_clearContainerPath == null)
            {
                MessageBox.Show("No file path shown");
                return;
            }

            // Save current container clear request
            var glnList = ParseGln(txtContainersToClear.Text);

            _csvFileController.SaveContainersFromList(txtNumToBeDeleted.Text, _clearContainerPath, glnList, _siteId);


            // Get data for snapshot
            if (cbSaveSnapshot.Checked)
            {
                var allContainers = await _clearContainerController.GetAllContainers();
                var allGlnList = new List<string>();

                foreach (IGPS_DEPOT_GLN gln in  allContainers)
                {
                    allGlnList.Add(gln.Gln);
                }
                 _csvFileController.SaveSnapShot( allContainers.Count.ToString(), _clearContainerPath, allGlnList, _siteId);

            }


            // Gets rid of excess memory usage from snapshot
            GC.Collect();

        }


        private async void ClickGetDnus(object sender, EventArgs e)
        {
            ClearContainerFields();
            try
            {
                List<IGPS_DEPOT_GLN> glnList = await _clearContainerController.GetDnus();
                UpdateDnuContainerClearList(glnList);
            }
            catch
            {
                MessageBox.Show("No DNUS found");
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
            ClearContainerFields();
        }


        // --------------------------- Rollback Tab ----------------------------

        private void ClickRollback(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }


        // --------------------------- Move Containers ------------------------


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
                //item.SubItems.Add(count.ToString());
                lvPlacards.Items.Add(item);
            }
        }

        private async void InitialLoad()
        {
            var result = await _moveContainerController.ReadAllContainers();
            LoadContainers(result);
        }


        private void ReloadContainers(object sender, EventArgs e)
        {
            InitialLoad();
        }

        private void moveExisitngForm(object sender, EventArgs e)
        {
            if (lvPlacards.SelectedItems.Count == 0) return;

            var fromGln = txtFromGln.Text;
            var toGln = txtToGln.Text;
            MoveContainersForm moveContainerForm = new MoveContainersForm(fromGln, toGln);
            moveContainerForm.ShowDialog();
        }

        private void clickSetFromGln(object sender, EventArgs e)
        {
            if (lvPlacards.SelectedItems.Count == 0) return;
            txtFromGln.Text = lvPlacards.SelectedItems[0].Text;
        }

        private void clickSetToGln(object sender, MouseEventArgs e)
        {
            if (lvPlacards.SelectedItems.Count == 0) return;
            txtToGln.Text = lvPlacards.SelectedItems[0].Text;

        }

        private  void searchContainers(object sender, KeyEventArgs e)
        {

        }

        private  async void searchContainersText(object sender, EventArgs e)
        {
            var result = _moveContainerController.ReadContainersFromSearch(tbSearchBar.Text);

            LoadContainers(await result);
        }
    }
}