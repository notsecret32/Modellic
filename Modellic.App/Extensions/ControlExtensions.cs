using System;
using System.Windows.Forms;

namespace Modellic.App.Extensions
{
    public static class ControlExtensions
    {
        public static void SafeInvoke(this Control control, Action action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
