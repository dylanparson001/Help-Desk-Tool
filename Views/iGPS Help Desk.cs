using iGPS_Help_Desk.Controllers;
using iGPS_Help_Desk.Models;
using iGPS_Help_Desk.Repositories;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iGPS_Help_Desk.Views
{
    public partial class Igps : BaseForm
    {
        private Timer closeTimer;
        private readonly ILogger _logger = Log.ForContext<Igps>();
        private readonly ILogger _rollbackLogger = Log.ForContext("Rollback", true);

        private List<IGPS_DEPOT_GLN> igpsDepotGln = new List<IGPS_DEPOT_GLN>();
        private List<string> ordersEntered = new List<string>();
        private bool showButtonClicked = false;
        private bool saveButtonClicked = false;
        private static string TicketNum = string.Empty;
        public Igps()
        {
            InitializeComponent();
            InitialLoad();
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            try
            {

                var settings = configFile.AppSettings.Settings;
                
                lblVersionNumber.Text = settings["version"].Value;
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

            Task.Run(async () =>
            {

                try
                {
                    var settings = configFile.AppSettings.Settings;

                    configFile.AppSettings.Settings["siteId"].Value = await _siteController.GetSiteIDAsync();
                    configFile.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

                }
                catch (Exception ex)
                {
                    _logger.Error(ex.ToString());
                }
            });

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
            MessageBox.Show($"{txtNumToBeDeleted.Text} Grais have been deleted from {glnList.Count} Containers have been cleared", "Containers Cleared", MessageBoxButtons.OK, MessageBoxIcon.Information);
            saveButtonClicked = false;
            GC.Collect();
            txtTicketNumber.Text = string.Empty;
            txtNumToBeDeleted.Text = "0";
            txtContainersToClear.Text = "";
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
            TicketNum = txtTicketNumber.Text;
            bool saveSnapshot = false;
            bool savingSnapshot = true;
            string ticketNumber = "";
            if (!string.IsNullOrEmpty(txtTicketNumber.Text))
            {
                ticketNumber = txtTicketNumber.Text;
            }

            if (!showButtonClicked)
            {
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "No GRAIs have been retreived";
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

            if (igpsDepotGln.Count == 0)
            {
                ShowContent();
            }

            // Save current container clear request
            List<string> zoutGlnList = ParseGln(txtContainersToClear.Text);
            string zoutCount = zoutGlnList.Count.ToString();

            try
            {
                this.Cursor = Cursors.WaitCursor;

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
                        allContainers.Item2.ToString(), saveSnapshot, igpsDepotGln, TicketNum);
                }
                else
                {
                    List<string> emptyList = new List<string>();
                    await _csvFileController.SaveCsvFilesAndZip(txtNumToBeDeleted.Text, zoutGlnList, emptyList, "0",
                        saveSnapshot, igpsDepotGln, TicketNum);
                }

                _clearContainerPath = ConfigurationManager.AppSettings.Get("clearContainerPath");
                MessageBox.Show("Files have been saved to " + _clearContainerPath, "File Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;

            }
            lblErrorMessage.Visible = false;
            saveButtonClicked = true;
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
            listViewRollbackContainers.Items.Clear();

            // Outputs them to List View
            foreach (var container in listContainers)
            {
                var item = new ListViewItem(container.Gln);
                item.SubItems.Add(container.Description);
                item.SubItems.Add(container.Status);
                item.SubItems.Add(container.SubStatus);
                item.SubItems.Add(container.Count.ToString());
                listViewRollbackContainers.Items.Add(item);
            }
            listViewRollbackContainers.CheckBoxes = true;
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
                orderIdList.Add(lvOrders.CheckedItems[i].Text.Trim());
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
                    MessageBox.Show("Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
        // ROLLBACK TAB
        private async void clickLoadOrderId(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBolToRollback.Text))
            {
                //MessageBox.Show("No BOL has been entered", "Enter BOL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                listOrderId.Items.Clear();
                return;
            }
            await reloadOrderRollback();
        }
        private async Task reloadOrderRollback()
        {


            lblError.Visible = false;

            listOrderId.CheckBoxes = true;
            listOrderId.Items.Clear();
            var parsedBol = ParseGln(txtBolToRollback.Text);

            parsedBol = parsedBol.Select(x => x.ToString()).Distinct().ToList();

            var bolResult = await _orderController.GetBolsFromList(parsedBol);



            bolResult = bolResult
                .OrderBy(x => x.BolId)
                .OrderBy(x => x.STATUS_DATE)
                .ToList();

            for (int i = 0; i < bolResult.Count; i++)
            {
                string completedCount = await _orderController.GetCountOfOrderId(bolResult[i].OrderId);
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
                item.SubItems.Add(completedCount);


                // Alternate row colors
                if (i % 2 == 0)
                {
                    item.BackColor = Color.LightBlue;
                }

                listOrderId.Items.Add(item);
            }

        }

        private async void clickRollbackButton(object sender, EventArgs e)
        {
            string ticketNumber = rollbackTicket.Text;
            if (string.IsNullOrEmpty(txtSelectedOrderId.Text))
            {
                MessageBox.Show("Please select a BOL", "No BOL Selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(txtGLNRollback.Text))
            {
                MessageBox.Show("Please select a GLN", "No GLN Selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(txtBolTotal.Text))
            {
                return;
            }
            string stringCountCompleted = txtBolTotal.Text.Trim();
            int integerCountCompleted = int.Parse(stringCountCompleted);
            if (integerCountCompleted == 0)
            {
                MessageBox.Show("No GRAIs have been completed with this order ID", "No GRAIs Completed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string countOfSelectedContainer = await _clearContainerController.GetCountOfGln(txtGLNRollback.Text);

            int parsedCount = int.Parse(countOfSelectedContainer);

            if (parsedCount != 0)
            {
                MessageBox.Show("Container chosen is not empty, cannot perform rollback", "Non-empty Container", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string count = await _orderController.GetCountOfOrderId(txtSelectedOrderId.Text);
            var response = MessageBox.Show(
                $"Do you want to perform rollback from {txtBolToRollback.Text} ({count} GRAIs)" +
                $" into container {txtGLNRollback.Text}?",
                "Confirm Rollback",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (response == DialogResult.No)
            {
                return;
            }
            string gln = txtGLNRollback.Text;
            string orderId = txtSelectedOrderId.Text;
            try
            {
                Cursor = Cursors.WaitCursor;
                await _rollbackController.Rollback(orderId, gln);
                reloadGlnRollbacks();
                await reloadOrderRollback();
                InitialLoad();
                MessageBox.Show($"Rollback Completed successfully into {gln}", "Rollback Completed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Primary Key Violation, need to remove GRAIs from IGPS_DEPOT_GLN Table
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("Primary Key Violation: GRAIs exist in the IGPS_DEPOT_GLN table. \nSaving and clearing now...", "GRAIs found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                _logger.Error("Primary key violation: " + ex.Message);
                var grais = await _csvFileController._orderRequestNewHeaderRepository.GetGraisFromOrderId(orderId);
                var graiString = _csvFileController.ConcatStringFromList(grais);

                var rnd = new Random();
                int random = rnd.Next(1, 1000);
                await _csvFileController.SaveCsvOfIndividualGrais(
                    txtZoutCount: grais.Count.ToString(),
                    txtGraisToClear: grais, 
                    rand: random, 
                    ticketNum: ticketNumber
                    );

                await _csvFileController._orderRequestNewHeaderRepository.ClearExistingGrais(graiString);

                // Attempt Rollback again
                try
                {
                    await _csvFileController._orderRequestNewHeaderRepository.Rollback(orderId, gln);
                    reloadGlnRollbacks();
                    await reloadOrderRollback();
                    InitialLoad();
                    _rollbackLogger.Information("Second rollback attempt completed successfully after GRAIs were cleared");
                    
                    MessageBox.Show($"Rollback Completed successfully into {gln}", "Rollback Completed",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception innerEx)
                {
                    _logger.Error(innerEx.Message);
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                this.Cursor = Cursors.Default;

            }
        }
        private void selectOrder(object sender, ItemCheckEventArgs e)
        {

            // Uncheck all other items if the current item is being checked
            if (e.NewValue == CheckState.Checked)
            {
                foreach (ListViewItem item in listOrderId.Items)
                {
                    if (item.Index != e.Index)
                    {
                        item.Checked = false;
                    }
                }
            }

        }

        private async void updateOrderIdSelect(object sender, ItemCheckedEventArgs e)
        {

        }

        private async void searchRollbackContainersText(object sender, EventArgs e)
        {
            var result = await _moveContainerController.ReadContainersFromSearch(txtRollbackContainerSearch.Text);

            LoadRollbackContainers(result);
        }
        private void LoadRollbackContainers(List<IGPS_DEPOT_LOCATION> listContainers)
        {
            listViewRollbackContainers.Items.Clear();

            // Outputs them to List View
            foreach (var container in listContainers)
            {
                var item = new ListViewItem(container.Gln);
                item.SubItems.Add(container.Description);
                item.SubItems.Add(container.Status);
                item.SubItems.Add(container.SubStatus);
                item.SubItems.Add(container.Count.ToString());
                listViewRollbackContainers.Items.Add(item);
            }
            listViewRollbackContainers.CheckBoxes = true;
        }

        private void selectRollbackContainer(object sender, ItemCheckEventArgs e)
        {
            // Uncheck all other items if the current item is being checked
            if (e.NewValue == CheckState.Checked)
            {
                foreach (ListViewItem item in listViewRollbackContainers.Items)
                {
                    if (item.Index != e.Index)
                    {
                        item.Checked = false;
                    }
                }
            }
        }

        private void updateGlnSelect(object sender, ItemCheckedEventArgs e)
        {
            txtGLNRollback.Text = e.Item.Text;
        }

        private void updateSelectedGLNRollback(object sender, EventArgs e)
        {
            if (listViewRollbackContainers.CheckedItems.Count == 0)
            {
                MessageBox.Show("No container selected", "Select a Container", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtGLNRollback.Text = listViewRollbackContainers.CheckedItems[0].Text;
        }

        private async void clickSelectOrderId(object sender, EventArgs e)
        {
            if (listOrderId.CheckedItems.Count == 0)
            {
                MessageBox.Show("No Order has been selected", "Select an order", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            txtSelectedOrderId.Text = listOrderId.CheckedItems[0].Text;
            txtTrailer.Text = await _rollbackController.GetTrailerNumber(txtSelectedOrderId.Text);
            txtSeal.Text = await _rollbackController.GetSealNumber(txtSelectedOrderId.Text);
            txtBolTotal.Text = await _orderController.GetCountOfOrderId(txtSelectedOrderId.Text);
        }

        private async void reloadRollbackContainers(object sender, EventArgs e)
        {
            reloadGlnRollbacks();
        }
        private async void reloadGlnRollbacks()
        {
            var result = await _moveContainerController.ReadContainersFromSearch(txtRollbackContainerSearch.Text);

            LoadRollbackContainers(result);
        }
    }
}