using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using System;
using System.Threading;
using System.Windows.Forms;
using WinBooster.DataBase.FilesHashes;
using WinBooster.Forms.AntiSS;
using WinBooster.Native;
using WinBoosterNative.Events;

namespace WinBooster
{
    public partial class AntiScreenShare : Form
    {
        public AntiScreenShare()
        {
            InitializeComponent();
        }
        bool ctrl = false;
        bool num5 = false;
        bool hided = false;
        private KeyboardHookListener _globalKeyboardListener;

        public void Subscribe()
        {
            _globalKeyboardListener = new KeyboardHookListener(new GlobalHooker());
            _globalKeyboardListener.KeyDown += OnGlobalKeyDown;
            _globalKeyboardListener.KeyUp += OnGlobalKeyUp;
            _globalKeyboardListener.Start();
        }
        public void Unsubscribe()
        {
            _globalKeyboardListener.KeyDown -= OnGlobalKeyDown;
            _globalKeyboardListener.KeyUp -= OnGlobalKeyUp;

            //It is recommened to dispose it
            _globalKeyboardListener.Dispose();
        }
        private void OnGlobalKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.LControlKey)
            {
                ctrl = false;
            }
            if (e.KeyData == Keys.NumPad5)
            {
                num5 = false;
            }
        }
        private void OnGlobalKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.LControlKey)
            {
                ctrl = true;
            }
            if (e.KeyData == Keys.NumPad5)
            {
                num5 = true;
            }
            if (num5 && ctrl)
            {
                ctrl = false;
                num5 = false;
                Unsubscribe();
                hided = false;
                Program.form.PeSafeForm = new Forms.PESafeForm();
                Program.form.Show();
            }
        }
        int fake_sim = 1;
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                Program.form.PeSafeForm.Dispose();
            }
            catch
            {

            }
            Subscribe();
            Program.form.PeSafeForm = null;
            EventManager eventManager = new EventManager();
            eventManager.Listen();
            eventManager.OnProcessStarted += EventManager_OnProcessStarted;
            Program.form.Hide();
            hided = true;
        }
        private void EventManager_OnProcessStarted(ProcessRunning process)
        {
            if (process.file.Exists)
            {
                string md5 = Utils.CalculateMD5(process.file.FullName);
                FileInfoByMD5 file_info = FIleHashesDatabase.GetInfo(md5);
                if (file_info != null)
                {
                    if (file_info.name == "Process Hacker" && registryCheckbox.Checked)
                    {
                        process.process.Kill();
                        Thread.Sleep(145);
                        Utils.BreakFile(process.file, 9);
                    }
                    else if (file_info.name == "LastActivityView" && guna2CheckBox1.Checked)
                    {
                        process.process.Kill();
                        Thread.Sleep(145);
                        Utils.BreakFile(process.file, 8);
                    }
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

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
