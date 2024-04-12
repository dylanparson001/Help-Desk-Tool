using iGPS_Help_Desk.Controllers;
using iGPS_Help_Desk.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iGPS_Help_Desk.Views
{
    public partial class ClearGraisForm : Form
    {
        private readonly MoveContainerController _moveContainerController = new MoveContainerController();
        private readonly ClearContainerController _clearContainerController = new ClearContainerController();
        private readonly CsvFileController _csvFileController = new CsvFileController();
        private readonly string _fromGln;
        private readonly string _toGln;
        private readonly List<string> listOfFromGrais = new List<string>();
        List<string> listOfToGrais = new List<string>();
        private readonly ILogger _logger = Log.ForContext<Igps>();

        private ClearGraisForm()
        {
            InitializeComponent();
        }
        public ClearGraisForm(string fromGln) : this()
        {

            _fromGln = fromGln;

            lblFromGln.Text += fromGln;

            LoadGrais();
        }

        private async void LoadGrais()
        {
            await LoadFromGrais();
        }
        private async Task LoadFromGrais()
        {

            lvFromGrais.Items.Clear();
            listOfFromGrais.Clear();
            var listContainers = new List<IGPS_DEPOT_GLN>();
            if (graiSearchBar.Text.Length != 0)
            {
                listContainers = await _moveContainerController.SearchGraiFromContainer(graiSearchBar.Text, _fromGln);
            }
            else
            {

                listContainers = await _moveContainerController.ReadGraisFromContainer(_fromGln);

            }

            for (int i = 0; i < listContainers.Count; i++)
            {
                listOfFromGrais.Add(listContainers[i].Grai);

                var item = new ListViewItem(listContainers[i].Grai);
                item.SubItems.Add($"{listContainers[i].Date_Time}");
                item.SubItems.Add($"{i + 1}");
                lvFromGrais.Items.Add(item);

            }
            lblFromGraisCount.Text = $"Container Count: {listOfFromGrais.Count}";
        }


        private async void clickDeleteSelectedGrais(object sender, EventArgs e)
        {


            var listOfGrais = new List<string>();
            var selectedGrais = lvFromGrais.SelectedItems;

            if (selectedGrais.Count > 0)
            {
                lblSelectGraisError.Text = "";
                DialogResult result = MessageBox.Show($"Are you sure you want to delete {selectedGrais.Count} Grais?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Check the user's response
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < selectedGrais.Count; i++)
                    {
                        listOfGrais.Add(selectedGrais[i].Text);
                    }
                    _logger.Information($"{selectedGrais.Count} grai(s) have been deleted from {_fromGln}");
                    _clearContainerController.ClearGrais(listOfGrais);

                    await LoadFromGrais();
                }

            }
            else
            {
                lblSelectGraisError.Text = "No Grais selected";

            }
        }

        private void clickCloseForm(object sender, EventArgs e)
        {
            Close();
        }

        private void orderByColumn(object sender, ColumnClickEventArgs e)
        {

        }

        private async void saveSelectedGrais(object sender, EventArgs e)
        {
            Random rand = new Random();

            var num = rand.Next(1, 100);

            var listOfGrais = new List<string>();
            var selectedGrais = lvFromGrais.SelectedItems;
            if (selectedGrais.Count > 0)
            {
                lblSelectGraisError.Text = "";
                for (int i = 0; i < selectedGrais.Count; i++)
                {
                    listOfGrais.Add(selectedGrais[i].Text);
                }
                var path = CsvFileController.GetCurrentFolderPath();
                await _csvFileController.SaveCsvOfIndividualGrais(selectedGrais.Count.ToString(), listOfGrais, _fromGln, num);
                MessageBox.Show($"Grais have been saved to {path}");
            }
            else
            {
                lblSelectGraisError.Text = "No Grais selected";

            }
        }

        private async void ReloadButtonClick(object sender, EventArgs e)
        {
            await LoadFromGrais();
        }

        private async void searchContainerForGrai(object sender, EventArgs e)
        {

            var listContainers = await _moveContainerController.SearchGraiFromContainer(graiSearchBar.Text, lblFromGln.Text);

            lvFromGrais.Items.Clear();
            listOfFromGrais.Clear();
            for (int i = 0; i < listContainers.Count; i++)
            {
                listOfFromGrais.Add(listContainers[i].Grai);

                var item = new ListViewItem(listContainers[i].Grai);
                item.SubItems.Add($"{listContainers[i].Date_Time}");
                item.SubItems.Add($"{i + 1}");
                lvFromGrais.Items.Add(item);

            }
            lblFromGraisCount.Text = $"Container Count: {listOfFromGrais.Count}";
        }
    }
}

