using iGPS_Help_Desk.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iGPS_Help_Desk.Views
{
    public partial class MoveContainersForm : Form
    {
        private MoveContainerController _moveContainerController = new MoveContainerController();
        private ClearContainerController _clearContainerController = new ClearContainerController();
        private readonly string _fromGln;
        private readonly string _toGln;
        private List<string> listOfFromGrais = new List<string>();
        List<string> listOfToGrais = new List<string>();

        public MoveContainersForm()
        {
            InitializeComponent();
        }
        public MoveContainersForm(string fromGln, string toGln) : this()
        {

            _fromGln = fromGln;
            _toGln = toGln;

            lblFromGln.Text += fromGln;
            lblToGln.Text += toGln;
            
            LoadGrais();
        }

        private async Task LoadGrais()
        {
            await LoadFromGrais();
            await LoadToGrais();
        }
        private async Task LoadFromGrais()
        {

            lvFromGrais.Items.Clear();
            listOfFromGrais.Clear();
            var listContainers = await _moveContainerController.ReadGraisFromContainer(_fromGln);
            

            for (int i = 0; i < listContainers.Count; i++)
            {
                listOfFromGrais.Add(listContainers[i].Grai);

                var item = new ListViewItem(listContainers[i].Grai);
                item.SubItems.Add($"{i+1}");
                lvFromGrais.Items.Add(item);

            }
            lblFromGraisCount.Text = $"Container Count: {listOfFromGrais.Count}";
        }
        private async Task LoadToGrais()
        {
            lvToGln.Items.Clear();
            listOfToGrais.Clear();
            var listContainers = await _moveContainerController.ReadGraisFromContainer(_toGln);


            for (int i = 0; i < listContainers.Count; i++)
            {
                listOfToGrais.Add(listContainers[i].Grai);

                var item = new ListViewItem(listContainers[i].Grai);
                item.SubItems.Add($"{i + 1}");
                lvToGln.Items.Add(item);
            }
            lblToGraisCount.Text = $"Container Count: {listOfToGrais.Count}";
        }

        private void checkAllFromGln(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                for (int i = 0; i < listOfFromGrais.Count; i++)
                {
                    lvFromGrais.Items[i].Selected = true;
                }
            }
            else
            {
                unCheckGrais();
            }
        }

        private void unCheckGrais()
        {
            for (int i = 0; i < listOfFromGrais.Count; i++)
            {
                lvFromGrais.Items[i].Selected = false;
            }
        }

        private void unCheckAllFromGln(object sender, EventArgs e)
        {
            for (int i = 0; i < listOfFromGrais.Count; i++)
            {
                lvFromGrais.Items[i].Selected = false;
            }
        }

        private void checkAllToGln(object sender, EventArgs e)
        {
            for (int i = 0; i < listOfToGrais.Count; i++)
            {
                lvToGln.Items[i].Selected = true;
            }
        }
        private void unCheckAllToGln(object sender, EventArgs e)
        {
            for (int i = 0; i < listOfToGrais.Count; i++)
            {
                lvToGln.Items[i].Selected = false;
            }
        }

        private async void clickMoveAllGrais(object sender, EventArgs e)
        {
            /*List<string> glnToDelete = new List<string>();
            glnToDelete.Add(_fromGln);

            _moveContainerController.MoveContainers(_fromGln, _toGln, listOfFromGrais.Count);
            if (cbDeleteContainer.Checked)
            {
                _moveContainerController.DeleteContainer(_fromGln);
            }
            await LoadFromGrais();
            await LoadToGrais();*/
        }

        private async void clickMoveSelectedGrais(object sender, EventArgs e)
        {
            var listOfGrais = new List<string>();
            var selectedGrais = lvFromGrais.SelectedItems;
            if (selectedGrais.Count > 0)
            {

                for (int i = 0; i < selectedGrais.Count; i++)
                {
                    listOfGrais.Add(selectedGrais[i].Text);
                }
            
            _moveContainerController.MoveSelectedGraisToContainer(listOfGrais, _toGln);
            
            }
            await LoadFromGrais();
            await LoadToGrais();
        }

        private void clickCloseForm(object sender, EventArgs e)
        {
            Close();
        }
    }
}

