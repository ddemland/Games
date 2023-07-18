
using System.Runtime.InteropServices;

namespace TicTacToe.GUI
{
    public static class SystemScalingHelper
    {
        [DllImport("User32.dll")]
        private static extern nint GetDC(nint hWnd);

        [DllImport("User32.dll")]
        private static extern int GetDpiForSystem();

        [DllImport("User32.dll")]
        private static extern int ReleaseDC(nint hWnd, nint hDC);

        public static float GetSystemScaling()
        {
            var hWnd = nint.Zero;
            var hDC = GetDC(hWnd);
            var dpi = GetDpiForSystem();
            ReleaseDC(hWnd, hDC);

            // Scaling is typically 96 DPI (100%), 120 DPI (125%), 144 DPI (150%), etc.
            var scaling = dpi / 96f;
            return scaling;
        }
    }
}
