using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using Application = System.Windows.Application;

namespace KeyboardDisabler
{
    public partial class MainWindow : Window
    {
        // Delegate for the LowLevelKeyboardProc callback function
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        // NotifyIcon for system tray
        private NotifyIcon notifyIcon;

        public MainWindow()
        {
            InitializeComponent();
            CreateTrayIcon();
        }

        private void CreateTrayIcon()
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new System.Drawing.Icon(SystemIcons.Application, 40, 40);
            notifyIcon.Visible = true;
            notifyIcon.Text = "Keyboard Disabler";

            var contextMenu = new ContextMenuStrip();
            var disableItem = new ToolStripMenuItem("Disable Keyboard", null, DisableKeyboard);
            var enableItem = new ToolStripMenuItem("Enable Keyboard", null, EnableKeyboard);
            var exitItem = new ToolStripMenuItem("Exit", null, ExitApplication);

            contextMenu.Items.Add(disableItem);
            contextMenu.Items.Add(enableItem);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add(exitItem);

            notifyIcon.ContextMenuStrip = contextMenu;
        }

        private void DisableKeyboard(object sender, EventArgs e)
        {
            _hookID = SetHook(_proc);
            System.Windows.MessageBox.Show("Keyboard Disabled!", "Status", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void EnableKeyboard(object sender, EventArgs e)
        {
            UnhookWindowsHookEx(_hookID);
            System.Windows.MessageBox.Show("Keyboard Enabled!", "Status", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Application.Current.Shutdown();
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (var curProcess = System.Diagnostics.Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                // Block all keys when keyboard is disabled
                return (IntPtr)1; // Prevents the key from being processed
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        // DLL Imports
        private const int WH_KEYBOARD_LL = 13;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
