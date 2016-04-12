using System;

namespace Version_1_C
{
    [Serializable()] 
    public class clsArtist
    {
        private string _Name;
        private string _Speciality;
        private string _Phone;
        
        private decimal _TotalValue;

        private clsWorksList _WorksList;
        private clsArtistList _ArtistList;
        
        private static frmArtist _ArtistDialog = new frmArtist();

        //private byte sortOrder;
        //20160412 - Stage 1 - Refactoring Q.7:'Move Field' to clsWorksList Cd'E
        //Remove "sortOrder", as the field has been moved.

        public clsArtist() { }

        public clsArtist(clsArtistList prArtistList)
        {
            _WorksList = new clsWorksList();
            _ArtistList = prArtistList;
            EditDetails();
        }

        //20160412 - Stage 1 - Refactoring Q.8h:'simplify' as all getting & setting
        //Is completed by frmArtist now. Cd'E
        public void EditDetails()
        {
            //_ArtistDialog.SetDetails(Name, Speciality, Phone, WorksList, _ArtistList);
            //if (_ArtistDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            _ArtistDialog.SetDetails(this);
            _TotalValue = _WorksList.GetTotalValue();
            //{
            //_ArtistDialog.GetDetails(ref Name, ref Speciality, ref Phone);
            //TotalValue = WorksList.GetTotalValue();
            //}
        }

        //public string GetKey()
        //{
        //    return _Name;
        //}

        //public decimal GetWorksValue()
        //{
        //    return _TotalValue;
        //}

        //20160412 Stage.1 Q.8 - Code Smell 'inapproriate Intimacy'
        //- resolve with 'hide delegate' Cd'E
        public bool IsDuplicate(string prArtistName)
        {
            return _ArtistList.ContainsKey(prArtistName);
        }

        //20160412 - Stage 1 - Refactoring Q.8:'Long Parameter List'. Cd'E
        //Replace 'parameter' wih method. (Quick Actions - Encapsulate ...).

        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
            }
        }

        public string Speciality
        {
            get
            {
                return _Speciality;
            }

            set
            {
                _Speciality = value;
            }
        }

        public string Phone
        {
            get
            {
                return _Phone;
            }

            set
            {
                _Phone = value;
            }
        }

        public decimal TotalValue
        {
            get
            {
                return _TotalValue;
            }

            set
            {
                _TotalValue = value;
            }
        }

        public clsWorksList WorksList
        {
            get
            {
                return _WorksList;
            }

            set
            {
                _WorksList = value;
            }
        }
    }
}
