using System;
//using System.Collections;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmArtist : Form
    {
        public frmArtist()
        {
            InitializeComponent();
        }
        //20160412 Stage.1 Q.9 ""Remove all references to _ArtistList". Cd'E

        //20160412 - Stage 1 - Refactoring Q.8c: create private member variable Cd'E
        private clsArtist _Artist;
        private clsWorksList _WorksList;
        //private byte _SortOrder; // 0 = Name, 1 = Date

        private void UpdateDisplay()
        {
            //_ArtistList.Save();
            txtName.Enabled = txtName.Text == "";
            if (_WorksList.SortOrder == 0)
            {
                _WorksList.SortByName();
                rbByName.Checked = true;
            }
            else
            {
                _WorksList.SortByDate();
                rbByDate.Checked = true;
            }

            lstWorks.DataSource = null;
            lstWorks.DataSource = _WorksList;
            lblTotal.Text = Convert.ToString(_WorksList.GetTotalValue());
        }

        //20160412 - Stage 1 - Refactoring Q.7:'Move Field' to clsWorksList Cd'E
        //Remove "sortOrder", as the field has been moved.
        //Q8e - Simplify SetDetails()
        //"Remove Parameter", "Preserve Whole Object", & "CHange Unidirectional to Bidirectional Association"
        //public void SetDetails(string prName, string prSpeciality, string prPhone,
        //               clsWorksList prWorksList, clsArtistList prArtistList)
        //{
        //    txtName.Text = prName;
        //    txtSpeciality.Text = prSpeciality;
        //    txtPhone.Text = prPhone;
        //    _ArtistList = prArtistList;
        //    _WorksList = prWorksList;
        //    _SortOrder = _WorksList.SortOrder;
        //    UpdateDisplay();
        //}
        public void SetDetails(clsArtist prArtist)
        {
            _Artist = prArtist;
            updateForm();
            UpdateDisplay();
            ShowDialog();
        }

        //20160412 - Stage 1 - Refactoring Q.8d:'updateForm()' & 'pushData()' Cd'E
        //Replace "SetDetails()" & "GetDetails()".
        private void updateForm()
        {
            txtName.Text = _Artist.Name;
            txtSpeciality.Text = _Artist.Speciality;
            txtPhone.Text = _Artist.Phone;
            _WorksList = _Artist.WorksList;
        }

        private void pushData()
        {
            _Artist.Name = txtName.Text;
            _Artist.Speciality = txtSpeciality.Text;
            _Artist.Phone = txtPhone.Text;
        }

        //20160412 - Stage 1 - Refactoring Q.7:'Move Field' to clsWorksList Cd'E
        //Remove "sortOrder", as the field has been moved.
        //8f - GetDetails() no longer needed.
        //public void GetDetails(ref string prName, ref string prSpeciality, ref string prPhone)
        //{
        //    prName = txtName.Text;
        //    prSpeciality = txtSpeciality.Text;
        //    prPhone = txtPhone.Text;
        //    _SortOrder = _WorksList.SortOrder;
        //}

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _WorksList.DeleteWork(lstWorks.SelectedIndex);
            UpdateDisplay();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _WorksList.AddWork();
            UpdateDisplay();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (isValid() == true)
            {
                //DialogResult = DialogResult.OK;
                pushData();
                Close();
            }
        }

        public virtual Boolean isValid()
        {
            if (txtName.Enabled && txtName.Text != "")
                //if (_ArtistList.Contains(txtName.Text)) | Q.9b 20160412 Cd'E
                if (_Artist.IsDuplicate(txtName.Text))
                {
                    MessageBox.Show("Artist with that name already exists!", "Error adding artist");
                    return false;
                }
                else
                    return true;
            else
                return true;
        }

        private void lstWorks_DoubleClick(object sender, EventArgs e)
        {
            int lcIndex = lstWorks.SelectedIndex;
            if (lcIndex >= 0)
            {
                _WorksList.EditWork(lcIndex);
                UpdateDisplay();
            }
        }

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            _WorksList.SortOrder = Convert.ToByte(rbByDate.Checked);
            UpdateDisplay();
        }

    }
}