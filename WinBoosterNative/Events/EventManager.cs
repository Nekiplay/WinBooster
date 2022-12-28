using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using WinBooster.Native;

namespace WinBoosterNative.Events
{
    public class EventManager
    {
        public delegate void ProcessEventHandler(ProcessRunning process);

        //This event can cause any method which conforms
        //to MyEventHandler to be called.
        public event ProcessEventHandler OnProcessStarted;
        public void Listen()
        {
            ManagementEventWatcher w = null;
            WqlEventQuery q;
            try
            {
                q = new WqlEventQuery();
                q.EventClassName = "Win32_ProcessStartTrace";
                w = new ManagementEventWatcher(q);
                w.EventArrived += new EventArrivedEventHandler(ProcessStartEventArrived);
                w.Start();
            }
            catch (Exception ex)
            {

            }
        }

        private void ProcessStartEventArrived(object sender, EventArrivedEventArgs e)
        {
            foreach (PropertyData pd in e.NewEvent.Properties)
            {
                if (pd.Name == "ProcessID")
                {
                    int id = int.Parse(pd.Value.ToString());
                    Process process = Process.GetProcessById(id);
                    if (process != null)
                    {
                        var info = Utils.GetProcessPath(process);
                        ProcessRunning processRunning = new ProcessRunning(process, info);
                        OnProcessStarted(processRunning);
                    }
                }
            }
        }
    }
}
