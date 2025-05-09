using Modellic.Interfaces;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Runtime.InteropServices;

namespace Modellic.Services
{
    public class SwService : ISwService
    {
        private ISldWorks _swApp;

        private bool _isConnected;

        private const string SW_PROG_ID = "SldWorks.Application";

        public ISldWorks SwApp => _swApp;

        public bool IsConnected => _isConnected;

        public bool Connect()
        {
            if (_swApp != null) {
                return true;
            }

            try
            {
                try
                {
                    _swApp = (ISldWorks)Marshal.GetActiveObject(SW_PROG_ID);
                }
                catch (COMException)
                {
                    Type solidWorksType = Type.GetTypeFromProgID(SW_PROG_ID);
                    _swApp = (ISldWorks)Activator.CreateInstance(solidWorksType);
                }
                finally
                {
                    _swApp.Visible = true;
                    _swApp.FrameState = (int)swWindowState_e.swWindowMaximized;
                }

                _isConnected = true;
                return true;
            }
            catch (Exception ex)
            {
                _isConnected = false;
                throw ex;
            }
        }

        public void Disconnect()
        {
            if (_swApp != null)
            {
                Marshal.ReleaseComObject(_swApp);
                _swApp = null;
            }

            _isConnected = false;
        }

        public void Dispose()
        {
            Disconnect();
        }

        public override string ToString()
        {
            return IsConnected ? "Подключено" : "Не подключено";
        }
    }
}
