using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Pyke.Window
{
    public class WindowHandler
    {
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        private PykeAPI pyke;
        public WindowHandler(PykeAPI pykeAPI)
        {
            pyke = pykeAPI;
        }

        public RECT GetWindowLocation()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                throw new NotImplementedException("GetWindowLocation is only supported on Windows Platforms");
            RECT rct = new RECT();
            GetWindowRect(pyke.wProc.MainWindowHandle, ref rct);
            return rct;
        }

        public void SetWindowLocation(int x, int y, int width, int height)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                throw new NotImplementedException("SetWindowLocation is only supported on Windows Platforms");
            MoveWindow(pyke.wProc.MainWindowHandle, x, y, width, height, true);
        }
    }
}
