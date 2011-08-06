using System;
using WindowsFormsApplication1.Interfaces;

namespace WindowsFormsApplication1.Features {
    public class WindowFocus : IFeature {
        private readonly IntPtr _windowHandle;

        public WindowFocus() {
            _windowHandle = Utils.GetMsAccessWindowHandle();
        }

        public void Run() {
            MakeTopMost(_windowHandle);
        }

        public void Clear() {
            MakeNormal(_windowHandle);
        }

        #region Implementation Details

        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        //static readonly IntPtr HWND_TOP = new IntPtr(0);
        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        //const UInt32 SWP_NOZORDER = 0x0004;
        //const UInt32 SWP_NOREDRAW = 0x0008;
        //const UInt32 SWP_NOACTIVATE = 0x0010;
        //const UInt32 SWP_FRAMECHANGED = 0x0020; /* The frame changed: send WM_NCCALCSIZE */
        //const UInt32 SWP_SHOWWINDOW = 0x0040;
        //const UInt32 SWP_HIDEWINDOW = 0x0080;
        //const UInt32 SWP_NOCOPYBITS = 0x0100;
        //const UInt32 SWP_NOOWNERZORDER = 0x0200; /* Don't do owner Z ordering */
        //const UInt32 SWP_NOSENDCHANGING = 0x0400; /* Don't send WM_WINDOWPOSCHANGING */

        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        public static void MakeTopMost(IntPtr window) {
            WinApi.SetForegroundWindow(window);
            WinApi.SetWindowPos(window, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
        }

        public static void MakeNormal(IntPtr window) {
            WinApi.SetWindowPos(window, HWND_NOTOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
        }

        #endregion
    }
}