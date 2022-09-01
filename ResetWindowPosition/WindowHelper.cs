using static PInvoke.User32;
using HWND = System.IntPtr;

namespace ResetWindowPosition
{
    internal class WindowHelper
    {
        HWND shellWindow;
        string[] ignoredClasses = { "Windows.UI.Core.CoreWindow", "ApplicationFrameWindow" };

        public Dictionary<HWND, string> windows { get; private set; }

        public WindowHelper()
        {
            windows = new Dictionary<HWND, string>();
            shellWindow = PInvoke.User32.GetShellWindow();
        }

        public void GetWindows()
        {
            EnumWindows(new WNDENUMPROC(EWCallback), HWND.Zero);
        }

        private bool EWCallback(HWND hWND, IntPtr lParam)
        {
            // ignore if current windows is the desktop/shell.
            if (hWND == shellWindow) return true;

            // ignore if the window is hidden.
            if (!IsWindowVisible(hWND)) return true;

            // ignore if the window is of type we don't want.
            // primarily Modern Apps that can be suspended.
            var className = GetClassName(hWND);
            if (ignoredClasses.Contains(className)) return true;

            // ignore if the title is empty.
            int length = GetWindowTextLength(hWND);
            if (length == 0) return true;

            string title = GetWindowText(hWND);
            windows[hWND] = title;

            return true;
        }

        public void MoveWindow(HWND hWND, int parentX, int parentY)
        {
            if (hWND != HWND.Zero)
            {
                // if the window is minimized, restore it.
                WINDOWPLACEMENT wp = GetWindowPlacement(hWND);
                if (wp.showCmd == WindowShowStyle.SW_SHOWMINIMIZED)
                {
                    wp.showCmd = WindowShowStyle.SW_RESTORE;
                    SetWindowPlacement(hWND, wp);
                }
                // move window to X=50, y=50 (arbitrary), no resizing
                SetWindowPos(hWND, HWND.Zero, parentX + 50, parentY + 50, 0, 0, SetWindowPosFlags.SWP_NOSIZE);
            }
        }

        public WindowInfo GetWindowInfo(HWND hWnd)
        {
            return new WindowInfo
            {
                Placement = GetWindowPlacement(hWnd),
                Title = GetWindowText(hWnd),
                Class = GetClassName(hWnd)
            };

        }

    }

    public class WindowInfo
    {
        public string Title { get; set; }
        public WINDOWPLACEMENT Placement { get; set; }
        public string Class { get; set; }
        public override string ToString()
        {
            return $"Title: {Title} {Environment.NewLine}" +
                   $"Class: {Class} {Environment.NewLine}" +
                   $"X    : {Placement.rcNormalPosition.left} {Environment.NewLine}" +
                   $"Y    : {Placement.rcNormalPosition.top} {Environment.NewLine}" +
                   $"State: {Placement.showCmd}"; 
        }

        public string GetXY()
        {
            return $"X = {Placement.rcNormalPosition.left}, Y={Placement.rcNormalPosition.top}";
        }

    }
}
