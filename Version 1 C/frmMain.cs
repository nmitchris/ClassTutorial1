using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// Matthias Otto, NMIT, 2010-2016
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        private clsArtistList _ArtistList; // 5f vii = new clsArtistList();
        //private const string fileName = "gallery.xml";

        private void UpdateDisplay()
        {
            string[] lcDisplayList = new string[_ArtistList.Count];

            lstArtists.DataSource = null;
            _ArtistList.Keys.CopyTo(lcDisplayList, 0);
            lstArtists.DataSource = lcDisplayList;
            lblValue.Text = Convert.ToString(_ArtistList.GetTotalValue());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ArtistList.NewArtist();
            UpdateDisplay();
        }

        private void lstArtists_DoubleClick(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null)
            {
                _ArtistList.EditArtist(lcKey);
                UpdateDisplay();
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            _ArtistList.Save();
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null)
            {
                lstArtists.ClearSelected();
                _ArtistList.Remove(lcKey);
                UpdateDisplay();
            }
        }

        //private void Save()
        //{
        //    try
        //    {
        //        System.IO.FileStream lcFileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Create);
        //        System.Runtime.Serialization.Formatters.Soap.SoapFormatter lcFormatter =
        //            new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();

        //        lcFormatter.Serialize(lcFileStream, theArtistList);
        //        lcFileStream.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "File Save Error");
        //    }
        //}

        //private void Retrieve()
        //{
        //    try
        //    {
        //        System.IO.FileStream lcFileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Open);
        //        System.Runtime.Serialization.Formatters.Soap.SoapFormatter lcFormatter =
        //            new System.Runtime.Serialization.Formatters.Soap.SoapFormatter();

        //        theArtistList = (clsArtistList)lcFormatter.Deserialize(lcFileStream);
        //        UpdateDisplay();
        //        lcFileStream.Close();
        //    }

        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "File Retrieve Error");
        //    }
        //}

        // Chris Lab1 Prt.6 / g. 14/03/2016.
        private void frmMain_Load(object sender, EventArgs e)
        {
            _ArtistList = clsArtistList.Retrieve();
            UpdateDisplay();
        }
    }
}