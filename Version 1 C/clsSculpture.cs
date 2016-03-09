using System;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()] 
    public class clsSculpture : clsWork
    {
        private float _weight;
        private string _material;

        [NonSerialized()]
        private static frmSculpture sculpDialog;

        public override void EditDetails()
       {
            if (sculpDialog == null)
            {
                sculpDialog = new frmSculpture();
            }
            sculpDialog.SetDetails(_name, _date, _value, _weight, _material);
            if (sculpDialog.ShowDialog() == DialogResult.OK)
            {
                sculpDialog.GetDetails(ref _name, ref _date, ref _value, ref _weight, ref _material);
            }
        }
    }
}
