using System;
using System.Runtime.InteropServices;

namespace WpfAppBar
{
    class Interop
    {
        // Structure to define the dimensions of a rectangle
        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        // Structure to pass appbar data to the system
        [StructLayout(LayoutKind.Sequential)]
        internal struct APPBARDATA
        {
            public int cbSize; // Size of the structure
            public IntPtr hWnd; // Handle to the appbar window
            public int uCallbackMessage; // Application-defined message identifier
            public int uEdge; // Screen edge for the appbar
            public RECT rc; // Rectangle for the appbar position
            public IntPtr lParam; // Message parameter
        }

        // Enum for various window attributes
        [System.Flags]
        internal enum DWMWINDOWATTRIBUTE
        {
            DWMA_NCRENDERING_ENABLED = 1,
            DWMA_NCRENDERING_POLICY,
            DWMA_TRANSITIONS_FORCEDISABLED,
            DWMA_ALLOW_NCPAINT,
            DWMA_CPATION_BUTTON_BOUNDS,
            DWMA_NONCLIENT_RTL_LAYOUT,
            DWMA_FORCE_ICONIC_REPRESENTATION,
            DWMA_FLIP3D_POLICY,
            DWMA_EXTENDED_FRAME_BOUNDS,
            DWMA_HAS_ICONIC_BITMAP,
            DWMA_DISALLOW_PEEK,
            DWMA_EXCLUDED_FROM_PEEK,
            DWMA_LAST
        }

        // Enum for DWM non-client rendering policy
        [System.Flags]
        internal enum DWMNCRenderingPolicy
        {
            UseWindowStyle,
            Disabled,
            Enabled,
            Last
        }

        // Enum for appbar messages
        internal enum ABMsg : int
        {
            ABM_NEW = 0,
            ABM_REMOVE,
            ABM_QUERYPOS,
            ABM_SETPOS,
            ABM_GETSTATE,
            ABM_GETTASKBARPOS,
            ABM_ACTIVATE,
            ABM_GETAUTOHIDEBAR,
            ABM_SETAUTOHIDEBAR,
            ABM_WINDOWPOSCHANGED,
            ABM_SETSTATE
        }

        // Enum for appbar notifications
        internal enum ABNotify : int
        {
            ABN_STATECHANGE = 0,
            ABN_POSCHANGED,
            ABN_FULLSCREENAPP,
            ABN_WINDOWARRANGE
        }

        // Enum for monitor defaults
        internal enum MonitorDefaultTo
        {
            MONITOR_DEFAULTTONULL,
            MONITOR_DEFAULTTOPRIMARY,
            MONITOR_DEFAULTTONEAREST
        }

        // Structure to get information about a display monitor
        [StructLayout(LayoutKind.Sequential)]
        internal struct MONITORINFO
        {
            public int cbSize; // Size of the structure
            public RECT rcMonitor; // Rectangle of the monitor
            public RECT rcWork; // Work area rectangle of the monitor
            public uint dwFlags; // Flags
        }

        // Function to send messages to the system's appbar
        [DllImport("SHELL32", CallingConvention = CallingConvention.StdCall)]
        internal static extern uint SHAppBarMessage(int dwMessage, ref APPBARDATA pData);

        // Function to register a window message
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern int RegisterWindowMessage(string msg);

        // Function to set window attributes
        [DllImport("dwmapi.dll")]
        internal static extern int DwmSetWindowAttribute(IntPtr hWnd, int attr, ref int attrValue, int attrSize);

        // Function to get the monitor handle from a window handle
        [DllImport("User32.dll")]
        internal static extern IntPtr MonitorFromWindow(IntPtr hWnd, MonitorDefaultTo dwFlags);

        // Function to get information about a monitor
        [DllImport("User32.dll")]
        internal static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFO lpmi);
    }
}
