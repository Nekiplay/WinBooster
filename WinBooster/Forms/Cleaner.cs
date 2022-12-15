using DevExpress.Utils.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBooster.Native;
using WinBooster.DataBase;
using WinBooster.Data;
using System.Collections.Generic;
using static DevExpress.Utils.Svg.CommonSvgImages;

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
                Program.form.Size = new System.Drawing.Size(318, 31 + 194);
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
                long removed_bytes = 0;
                long removed_files = 0;
                Task t3 = Task.Factory.StartNew(() =>
                {
                    if (cheatsCheckbox.Checked)
                    {
                        foreach (WorkingI working in Files.cheats)
                        {
                            try { 
                                var removed = working.Work();
                                removed_files += removed.Item1;
                                removed_bytes += removed.Item2;
                            } catch { }
                        }
                        cheatsCheckbox.Invoke(new MethodInvoker(() =>
                        {
                            cheatsCheckbox.Checked = false;
                        }));
                    }
                });
                Task t1 = Task.Factory.StartNew(async () =>
                {
                    if (logsCheckbox.Checked)
                    {
                        var a1 = Utils.Chunk<WorkingI>(Files.logs.AsEnumerable(), Files.logs.Count() / (Files.logs.Count() / 2));
                        List<Task> tasks = new List<Task>();
                        foreach (var a2 in a1)
                        {
                            Task<bool> t1a = new Task<bool>(() =>
                            {
                                foreach (var a3 in a2)
                                {
                                    Console.WriteLine(a3.GetDirectory());
                                    try
                                    {
                                        var removed = a3.Work();
                                        removed_files += removed.Item1;
                                        removed_bytes += removed.Item2;
                                    }
                                    catch { }

                                }
                                return true;
                            });
                            t1a.Start();
                            tasks.Add(t1a);
                        }
                        foreach (Task t in tasks)
                        {
                            t.Wait();
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
                        var a1 = Utils.Chunk<WorkingI>(Files.cache.AsEnumerable(), Files.cache.Count() / (Files.cache.Count() / 2));
                        List<Task> tasks = new List<Task>();
                        foreach (var a2 in a1)
                        {
                            Task<bool> t1a = new Task<bool>(() =>
                            {
                                foreach (var a3 in a2)
                                {

                                    try
                                    {
                                        var removed = a3.Work();
                                        removed_files += removed.Item1;
                                        removed_bytes += removed.Item2;
                                    }
                                    catch { }

                                }
                                return true;
                            });
                            t1a.Start();
                            tasks.Add(t1a);
                        }
                        foreach (Task t in tasks)
                        {
                            t.Wait();
                        }
                        cacheCheckbox.Invoke(new MethodInvoker(() =>
                        {
                            cacheCheckbox.Checked = false;
                        }));



                        //foreach (WorkingI working in Files.cache)
                        //{
                        //    try
                        //    {
                        //        var removed = working.Work();
                        //        removed_files += removed.Item1;
                        //        removed_bytes += removed.Item2;
                        //    }
                        //    catch { }
                        //}
                        //cacheCheckbox.Invoke(new MethodInvoker(() =>
                        //{
                        //    cacheCheckbox.Checked = false;
                        //}));
                    }
                });
                Task t4 = Task.Factory.StartNew(() =>
                {
                    if (lastactivityCheckbox.Checked)
                    {
                        if (guna2ComboBox1.SelectedIndex == 0)
                        {
                            foreach (WorkingI working in Files.lastactivity_safe)
                            {
                                try
                                {
                                    var removed = working.Work();
                                    removed_files += removed.Item1;
                                    removed_bytes += removed.Item2;
                                }
                                catch { }
                            }
                        }
                        else if (guna2ComboBox1.SelectedIndex == 1)
                        {
                            foreach (WorkingI working in Files.lastactivity_full)
                            {
                                try
                                {
                                    var removed = working.Work();
                                    removed_files += removed.Item1;
                                    removed_bytes += removed.Item2;
                                }
                                catch { }
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
                        removed_bytes += reg.Work().Item2;
                        if (guna2ComboBox1.SelectedIndex == 1)
                        {
                            RegUnsafe regUnsafe = new RegUnsafe();
                            removed_bytes += regUnsafe.Work().Item2;
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
                        foreach (WorkingI working in Files.images)
                        {
                            try
                            {
                                var removed = working.Work();
                                removed_files += removed.Item1;
                                removed_bytes += removed.Item2;
                            }
                            catch { }
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
                        foreach (WorkingI working in Files.media)
                        {
                            try
                            {
                                var removed = working.Work();
                                removed_files += removed.Item1;
                                removed_bytes += removed.Item2;
                            }
                            catch { }
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
                    script.OnClearDone(cheatsCheckbox.Checked, logsCheckbox.Checked, cacheCheckbox.Checked, lastactivityCheckbox.Checked, registryCheckbox.Checked, photoCheckbox.Checked, videoCheckbox.Checked, removed_bytes);
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

                if (removed_bytes > 0)
                {
                    SaveAndLoad.statistic.TotalGodClears++;
                    SaveAndLoad.statistic.TotalDeletedFiles += removed_files;
                }
                SaveAndLoad.statistic.TotalSizeClear += removed_bytes;
                if (SaveAndLoad.statistic.MaximumSizeClear < removed_bytes)
                {
                    SaveAndLoad.statistic.MaximumSizeClear = removed_bytes;
                }
                if (SaveAndLoad.statistic.MaximumDeletedFiles < removed_files)
                {
                    SaveAndLoad.statistic.MaximumDeletedFiles = removed_files;
                }
                SaveAndLoad.statistic.Save(SaveAndLoad.statistic_path);
                Program.form.statistic.UpdateUI();

                var item = toastNotificationsManager1.YieldArray().First();
                var item2 = item.Notifications.First();
                item2.Header = "Clearing";
                item2.Body = "Deleted files: " + removed_files +"\nDeleted size: " + Utils.GetStringSize(removed_bytes);
                toastNotificationsManager1.ShowNotification(item2.ID);
            }
        }

        public void onShow()
        {
            if (registryCheckbox.Checked)
                lastactivityCheckbox.Checked = true;
            if (registryCheckbox.Checked)
            {
                guna2GroupBox2.Visible = true;
                Program.form.Size = new System.Drawing.Size(318, 31 + 194);
            }
            if (!registryCheckbox.Checked && !lastactivityCheckbox.Checked)
            {
                Program.form.Size = new System.Drawing.Size(206, 31 + 194);
                guna2GroupBox2.Visible = lastactivityCheckbox.Checked;
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
