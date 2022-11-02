using DevExpress.Utils.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBooster.Native;
using WinBooster.DataBase;
using WinBooster.Data;

namespace WinBooster
{
    public partial class Cleaner : Form
    {
        public Cleaner()
        {
            InitializeComponent();
        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!registryCheckbox.Checked && !lastactivityCheckbox.Checked)
            {
                Program.form.Size = new System.Drawing.Size(206, 31 + 194);
                guna2GroupBox2.Visible = lastactivityCheckbox.Checked;
            }
            if (lastactivityCheckbox.Checked)
            {
                registryCheckbox.Checked = true;
            }
        }

        private void guna2CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (cheatsCheckbox.Checked)
            {
                registryCheckbox.Checked = true;
                guna2GroupBox2.Visible = true;
                lastactivityCheckbox.Checked = true;
            }
        }

        private void guna2CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (registryCheckbox.Checked)
                lastactivityCheckbox.Checked = true;
            if (registryCheckbox.Checked)
            {
                guna2GroupBox2.Visible = true;
                Program.form.Size = new System.Drawing.Size(303, 31 + 194);
            }
            if (!registryCheckbox.Checked && !lastactivityCheckbox.Checked)
            {
                Program.form.Size = new System.Drawing.Size(206, 31 + 194);
                guna2GroupBox2.Visible = lastactivityCheckbox.Checked;
            }
        }

        private void Cleaner_Load(object sender, EventArgs e)
        {
            
        }

        private async void guna2Button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                logsCheckbox.Checked = true;
                lastactivityCheckbox.Checked = true;
                cacheCheckbox.Checked = true;
                cheatsCheckbox.Checked = true;
                registryCheckbox.Checked = true;
                photoCheckbox.Checked = true;
                videoCheckbox.Checked = true;
            }
            else if (e.Button == MouseButtons.Left)
            {
                var scripts = MainMenu.charpManager.plugins;
                foreach (var script in scripts)
                {
                    script.OnClearStart(cheatsCheckbox.Checked, logsCheckbox.Checked, cacheCheckbox.Checked, lastactivityCheckbox.Checked, registryCheckbox.Checked, photoCheckbox.Checked, videoCheckbox.Checked);
                }
                guna2Button1.Invoke(new MethodInvoker(() =>
                {
                    guna2Button1.Enabled = false;
                    logsCheckbox.Enabled = false;
                    lastactivityCheckbox.Enabled = false;
                    cacheCheckbox.Enabled = false;
                    cheatsCheckbox.Enabled = false;
                    registryCheckbox.Enabled = false;
                    photoCheckbox.Enabled = false;
                    videoCheckbox.Enabled = false;
                }));
                long removed = 0;
                Task t3 = Task.Factory.StartNew(() =>
                {
                    if (cheatsCheckbox.Checked)
                    {
                        foreach (WorkingI log in Files.cheats)
                        {
                            try { removed += log.Work(); } catch { }
                        }
                        cheatsCheckbox.Invoke(new MethodInvoker(() =>
                        {
                            cheatsCheckbox.Checked = false;
                        }));
                    }
                });
                Task t1 = Task.Factory.StartNew(() =>
                {
                    if (logsCheckbox.Checked)
                    {
                        foreach (WorkingI log in Files.logs)
                        {
                            try { removed += log.Work(); } catch { }
                        }
                        logsCheckbox.Invoke(new MethodInvoker(() =>
                        {
                            logsCheckbox.Checked = false;
                        }));
                    }
                });
                Task t2 = Task.Factory.StartNew(() =>
                {
                    if (cacheCheckbox.Checked)
                    {
                        foreach (WorkingI log in Files.cache)
                        {
                            try { removed += log.Work(); } catch { }
                        }
                        cacheCheckbox.Invoke(new MethodInvoker(() =>
                        {
                            cacheCheckbox.Checked = false;
                        }));
                    }
                });
                Task t4 = Task.Factory.StartNew(() =>
                {
                    if (lastactivityCheckbox.Checked)
                    {
                        if (guna2ComboBox1.SelectedIndex == 0)
                        {
                            foreach (WorkingI log in Files.lastactivity_safe)
                            {
                                try { removed += log.Work(); } catch { }
                            }
                        }
                        else if (guna2ComboBox1.SelectedIndex == 1)
                        {
                            foreach (WorkingI log in Files.lastactivity_full)
                            {
                                try { removed += log.Work(); } catch { }
                            }
                        }
                        lastactivityCheckbox.Invoke(new MethodInvoker(() =>
                        {
                            lastactivityCheckbox.Checked = false;
                        }));
                    }
                });
                Task t5 = Task.Factory.StartNew(() =>
                {
                    if (registryCheckbox.Checked)
                    {
                        Reg reg = new Reg();
                        removed += reg.Work();
                        if (guna2ComboBox1.SelectedIndex == 1)
                        {
                            RegUnsafe regUnsafe = new RegUnsafe();
                            removed += regUnsafe.Work();
                        }
                        registryCheckbox.Invoke(new MethodInvoker(() =>
                        {
                            registryCheckbox.Checked = false;
                        }));
                    }
                });
                Task t6 = Task.Factory.StartNew(() =>
                {
                    if (photoCheckbox.Checked)
                    {
                        foreach (WorkingI log in Files.images)
                        {
                            try { removed += log.Work(); } catch { }
                        }
                        photoCheckbox.Invoke(new MethodInvoker(() =>
                        {
                            photoCheckbox.Checked = false;
                        }));
                    }
                });
                Task t7 = Task.Factory.StartNew(() =>
                {
                    if (videoCheckbox.Checked)
                    {
                        foreach (WorkingI log in Files.media)
                        {
                            try { removed += log.Work(); } catch { }
                        }
                        videoCheckbox.Invoke(new MethodInvoker(() =>
                        {
                            videoCheckbox.Checked = false;
                        }));
                    }
                });

                await t1;
                await t2;
                await t3;
                await t4;
                await t5;
                await t6;
                await t7;
                foreach (var script in scripts)
                {
                    script.OnClearDone(cheatsCheckbox.Checked, logsCheckbox.Checked, cacheCheckbox.Checked, lastactivityCheckbox.Checked, registryCheckbox.Checked, photoCheckbox.Checked, videoCheckbox.Checked, removed);
                }
                guna2Button1.Invoke(new MethodInvoker(() =>
                {
                    guna2Button1.Enabled = true;
                    logsCheckbox.Enabled = true;
                    lastactivityCheckbox.Enabled = true;
                    cacheCheckbox.Enabled = true;
                    cheatsCheckbox.Enabled = true;
                    registryCheckbox.Enabled = true;
                    photoCheckbox.Enabled = true;
                    videoCheckbox.Enabled = true;
                }));

                if (removed > 0)
                {
                    SaveAndLoad.statistic.TotalGodClears++;
                }
                SaveAndLoad.statistic.TotalSizeClear += removed;
                if (SaveAndLoad.statistic.MaximumSizeClear < removed)
                {
                    SaveAndLoad.statistic.MaximumSizeClear = removed;
                }
                SaveAndLoad.statistic.Save(SaveAndLoad.statistic_path);
                Program.form.statistic.UpdateUI();

                var item = toastNotificationsManager1.YieldArray().First();
                var item2 = item.Notifications.First();
                item2.Header = "Очистка";
                item2.Body = "Удалено: " + Utils.GetStringSize(removed);
                toastNotificationsManager1.ShowNotification(item2.ID);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void logsCheckbox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
