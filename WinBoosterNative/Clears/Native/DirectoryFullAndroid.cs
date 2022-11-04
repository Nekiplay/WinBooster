using MediaDevices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinBooster.Native;

namespace WinBoosterNative.Clears.Native
{
    public class DirectoryFullAndroid : WorkingI
    {
        public string directory;
        public DirectoryFullAndroid(string dir)
        {
            this.directory = dir;
        }

        public string GetDirectory()
        {
            return directory;
        }

        public string GetPattern()
        {
            return "";
        }
        public List<string> GetSafeNames()
        {
            return new List<string>();
        }
        public Tuple<long, long> Work()
        {
            long pre = 0;
            long files = 0;
            try
            {
                var devices = MediaDevice.GetDevices();
                foreach (var div in devices)
                {
                    using (var device = div)
                    {
                        device.Connect();
                        var dirs = device.GetRootDirectory();
                        if (device.DirectoryExists(dirs.FullName))
                        {
                            var photoDir = device.GetDirectories(dirs.FullName);

                            foreach (var dir3 in photoDir)
                            {
                                if (device.DirectoryExists(dir3 + "\\" + directory))
                                {
                                    var info = device.GetDirectoryInfo(dir3 + "\\" + directory);
                                    var customDirInfo = Utils.CustomDirInfo(device, info);
                                    pre = customDirInfo.size;
                                    files = customDirInfo.files;
                                    device.DeleteDirectory(info.FullName, true);
                                    if (device.DirectoryExists(dir3 + "\\" + directory))
                                    {
                                        info = device.GetDirectoryInfo(dir3 + "\\" + directory);
                                        customDirInfo = Utils.CustomDirInfo(device, info);
                                        pre -= customDirInfo.size;
                                        files -= customDirInfo.files;
                                    }
                                }
                            }
                        }
                        device.Disconnect();
                    }
                }
            }
            catch { }
            return new Tuple<long, long>(files, pre);
        }
    }
}
