using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBooster.DataBase.FilesHashes;
using WinBooster.Native;
using WinBoosterNative.Events;
using WinBoosterNative.Memory;

namespace WinBooster
{
    public partial class AntiScreenShare : Form
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        public AntiScreenShare()
        {
            InitializeComponent();
        }
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }
        static bool ctrl = false;
        static bool num5 = false;
        static bool hided = false;
        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                if (wParam == (IntPtr)WM_KEYDOWN)
                {
                    int vkCode = Marshal.ReadInt32(lParam);
                    Keys key = (Keys)vkCode;
                    if (key == Keys.LControlKey)
                    {
                        ctrl = true;
                    }
                    else if (key == Keys.NumPad5)
                    {
                        num5 = true;
                    }
                    if (ctrl && num5 && hided)
                    {
                        hided = false;
                        Program.form.PeSafeForm = new Forms.PESafeForm();
                        Program.form.Show();
                        UnhookWindowsHookEx(_hookID);
                    }
                }
                else if (wParam == (IntPtr)WM_KEYUP)
                {
                    int vkCode = Marshal.ReadInt32(lParam);
                    Keys key = (Keys)vkCode;
                    if (key == Keys.LControlKey)
                    {
                        ctrl = false;
                    }
                    else if (key == Keys.NumPad5)
                    {
                        num5 = false;
                    }
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                Program.form.PeSafeForm.Dispose();
            }
            catch
            {

            }
            Program.form.PeSafeForm = null;
            _hookID = SetHook(_proc);
            EventManager eventManager = new EventManager();
            eventManager.Listen();
            eventManager.OnProcessStarted += EventManager_OnProcessStarted;
            Program.form.Hide();
            hided = true;
        }
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr h, string message, string title, long type);
        private void EventManager_OnProcessStarted(ProcessRunning process)
        {
            string md5 = Utils.CalculateMD5(process.file.FullName);
            FileInfoByMD5 file_info = FIleHashesDatabase.GetInfo(md5);
            if (file_info != null)
            {
                if (file_info.name == "Process Hacker" && registryCheckbox.Checked)
                {
                    MemoryManager memoryManager = new MemoryManager(process.process);
                    if (guna2ComboBox1.SelectedIndex == 1)
                    {
                        memoryManager.user32.MessageBox("Your Windows version does not support this application", "Process Hacker", 0x00000030);
                    }
                    process.process.Kill();
                    Thread.Sleep(25);
                    Utils.BreakFile(process.file, 7);
                }
                else if (file_info.name == "LastActivityView" && guna2CheckBox1.Checked)
                {
                    MemoryManager memoryManager = new MemoryManager(process.process);
                    if (guna2ComboBox1.SelectedIndex == 1)
                    {
                        memoryManager.user32.MessageBox("Your Windows version does not support this application", "LastActivityView", 0x00000030);
                    }
                    process.process.Kill();
                    Thread.Sleep(25);
                    Utils.BreakFile(process.file, 6);
                }
            }
        }

        private void AntiScreenShare_Load(object sender, EventArgs e)
        {

        }

        private void AntiScreenShare_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            Program.bdos = guna2CheckBox2.Checked;
        }
    }
}
