using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Modellic.App
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if DEBUG
            // Инициализируем консоль перед любыми вызовами Console
            AllocConsole();
#endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

#if DEBUG
            // Закрываем консоль при завершении приложения
            FreeConsole();
#endif
        }

        #region DLL Import

        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        private static extern bool FreeConsole();

        #endregion
    }
}
