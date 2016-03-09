using System;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()] 
    public class clsPainting : clsWork
    {
        private float _width;
        private float _height;
        private string _type;

        [NonSerialized()]
        private static frmPainting paintDialog;

        public override void EditDetails()
        {
            if (paintDialog == null)
            {
                paintDialog = new frmPainting();
            }
            paintDialog.SetDetails(_name, _date, _value, _width, _height, _type);
            if(paintDialog.ShowDialog() == DialogResult.OK)
            {
               paintDialog.GetDetails(ref _name, ref _date, ref _value, ref _width, ref _height, ref _type);
            }
        }
    }
}
