using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//This is a Helper class that I use to handle cross thread operations.
namespace AccessoryPowerTestProject
{
    public class InvokeResources
    {
        #region InvokeDelegates
        private delegate void SetControlVisibilityD(Control control, Boolean flag);
        private delegate void ClearGridViewRowsD(DataGridView control);
        #endregion

        #region InvokeMethods
        private static void SetControlVisibilityM(Control control, Boolean flag)
        {
            control.Visible = flag;
        }
        private static void ClearGridViewRowsM(DataGridView control)
        {
            control.Rows.Clear();
        }
        #endregion

        #region PublicInvokeMethods
        public static void SetControlVisibility(Control control, Boolean flag)
        {
            if (control.InvokeRequired)
                control.Invoke(new SetControlVisibilityD(SetControlVisibility), new Object[] { control, flag });
            else
                SetControlVisibilityM(control, flag);
        }
        public static void ClearGridViewRows(DataGridView control)
        {
            if (control.InvokeRequired)
                control.Invoke(new ClearGridViewRowsD(ClearGridViewRows), new Object[] { control });
            else
                ClearGridViewRowsM(control);
        }
        #endregion
    }
}
