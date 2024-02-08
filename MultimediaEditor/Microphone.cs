using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using System.Windows;

namespace MultimediaEditor
{
    class Microphone
    {
        MainWindow main;
        string outputFilename = "";
        public Microphone(MainWindow wind, string uri)
        {
            main = wind;
            outputFilename = uri;
        }
        WaveIn waveIn;
        WaveFileWriter writer;

        [Obsolete]
        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {

           
            
             writer.WriteData(e.Buffer, 0, e.BytesRecorded);
           

        }

        private void WaveIn_RecordingStopped(object sender, EventArgs e)
        {

            waveIn.Dispose();
            waveIn = null;
            writer.Close();
            writer = null;

        }

        [Obsolete]
        public void StartRecord()
        {
            try
            {

                waveIn = new WaveIn();

                waveIn.DeviceNumber = 0;

                waveIn.DataAvailable += WaveIn_DataAvailable;

                waveIn.RecordingStopped += new EventHandler<StoppedEventArgs>(WaveIn_RecordingStopped);

                waveIn.WaveFormat = new WaveFormat(8000, 1);

                writer = new WaveFileWriter(outputFilename, waveIn.WaveFormat);

                waveIn.StartRecording();
            }
            catch (Exception)
            {
               // main.flag_mic = 10;
                writer.Dispose();
                System.IO.File.Delete(outputFilename);
                MessageBox.Show("Микрофон не подключён");

            }
        }
        public void StopRecord()
        {
            waveIn.StopRecording();
        }
    }
}
