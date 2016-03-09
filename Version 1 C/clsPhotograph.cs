using System;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()]
    public class clsPhotograph : clsWork
    {
        private float _width;
        private float _height;
        private string _type;

        [NonSerialized()]
        private static frmPhotograph photoDialog;

        public override void EditDetails()
        {
            if (photoDialog == null)
            {
                photoDialog = new frmPhotograph();
            }
            photoDialog.SetDetails(_name, _date, _value, _width, _height, _type);
            if (photoDialog.ShowDialog() == DialogResult.OK)
            {
                photoDialog.GetDetails(ref _name, ref _date, ref _value, ref _width, ref _height, ref _type);
            }
        }
    }
}
