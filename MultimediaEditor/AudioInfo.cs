using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace MultimediaEditor
{
    class AudioInfo
    {
        public AudioInfo(AudioFile file, string Url)
        {




            FileInfo info = new FileInfo(Url);
            file.Name = info.Name;
            file.Format = info.Extension;

            file.Url = Url;

            double Duration = 0;
            WMPLib.WindowsMediaPlayer w = new WMPLib.WindowsMediaPlayer();
            WMPLib.IWMPMedia m = w.newMedia(file.Url);
            if (m != null)
            {
                Duration = m.duration;
            }
            w.close();
            file.TotalTime = Convert.ToInt32(Duration * MainWindow.scaling);
            file.EndTime = file.TotalTime;


        }
    }
}
