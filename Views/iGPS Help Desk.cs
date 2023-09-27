/* Dylan Parson
 * Desktop Application For iGPS Help Desk team to clear containers, change statuses and other
 * common tasks more efficiently and safely.
 *
 */


using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iGPS_Help_Desk.Controllers;
using iGPS_Help_Desk.Models;

namespace iGPS_Help_Desk.Forms
{
    public partial class Igps : Form
    {
        private string _siteId = ConfigurationManager.AppSettings.Get("siteId");
        public string ClearContainerFilePath = ConfigurationManager.AppSettings.Get("clearContainerPath");
        private readonly ChangeStatusController _changeStatusController = new ChangeStatusController();
        private readonly ClearContainerController _clearContainerController = new ClearContainerController();
        private readonly CsvFileController _csvFileController = new CsvFileController();
        
        public Igps()
        {
            InitializeComponent();
        }

        //  ------------- Status Change Tab  ---------------------------------// 
        private void ClickStatusChange(object sender, EventArgs e)
        {
            List<string> listGlns = new List<string>();
            string inputFromUser = txtGlnList.Text;
            string  newStatus = txtNewStatus.Text;
            string newSubStatus = txtNewSubStatus.Text;
            
            if (inputFromUser.Length == 0 || inputFromUser == null) return;

            List<string> newList = ParseGln(inputFromUser);
            
            string stringGlns = string.Join(",", newList.Select(i => $"'{i}'"));

            List<IGPS_DEPOT_LOCATION> listContainers = _changeStatusController.ChangeStatus(stringGlns,
                newStatus, newSubStatus);
            
            UpdateGlnList(listContainers);
        }
        private void ClickCancel(object sender, EventArgs e)
        {
            ClearStatusFields();
        }

        private void ClearStatusFields()
        {
            txtGlnList.Text = string.Empty;
            txtNewStatus.Text = string.Empty;
            txtNewSubStatus.Text = string.Empty;
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

            // Initial List from user of glns (will be parsed to get rid of spaces, returns, quotes, etc)
            List<string> glnList = new List<string>();

            // Parsed list
            glnList = ParseGln(txtContainersToClear.Text);
            
            _clearContainerController.ClearContainers(glnList);
            lvGlnContent.Items.Clear();
        }

        // Updates list in view
        private void UpdateContainerClearList(List<IGPS_DEPOT_GLN> listGlns)
        {
            ClearContainerFields();
            if (listGlns == null) return;
            
            // Update Text box of containers entered to only show distinct containers
            var newList = listGlns.Select(x => x.Gln).Distinct();
            foreach(string gln in newList)
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
            // Initial List from user of glns (will be parsed to get rid of spaces, returns, quotes, etc)
            List<string> glnList = new List<string>();

            // Lists that will be returned from database
            var igpsDepotGln = new List<IGPS_DEPOT_GLN>();
            var rnd = new Random();

            // Parsed list
            glnList = ParseGln(txtContainersToClear.Text);

            // List from db
            try
            {
                igpsDepotGln = _clearContainerController.GetContainersFromList(glnList);
                UpdateContainerClearList(igpsDepotGln);

            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }


        private void BtnSaveContent(object sender, EventArgs e)
        {
           
           var glnList = ParseGln(txtContainersToClear.Text);
            _csvFileController.SaveContainersFromList(txtNumToBeDeleted.Text, ClearContainerFilePath, glnList, _siteId);
            
        }


        private void ClickGetDnus(object sender, EventArgs e)
        {
            ClearContainerFields();
            try
            {
                List<IGPS_DEPOT_GLN> glnList = _clearContainerController.GetDnus();
                UpdateContainerClearList(glnList);
            }
            catch
            {
                MessageBox.Show("No DNUS found");
                return;
            }
        }

        private void clickSettings(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
            _siteId = ConfigurationManager.AppSettings.Get("siteId");
            ClearContainerFilePath = ConfigurationManager.AppSettings.Get("clearContainerPath");
        }

        private void clickCancel(object sender, EventArgs e)
        {
            ClearContainerFields();
        }
    }
}
