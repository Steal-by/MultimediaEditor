using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Win32;
using System.IO;

namespace MultimediaEditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double scaling = 3.76;
        public int flag_mic = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        [Obsolete]
        private void RecordMicroBut_Click(object sender, RoutedEventArgs e)
        {
            Microphone micro = null;
            string url = "";
            MenuItem item = (MenuItem)TopPanel.Items[5];
            if (item.IsChecked == false)
            {
                SaveFileDialog textDialog = new SaveFileDialog();
                textDialog.AddExtension = true;
                textDialog.InitialDirectory = "c:\\";
                textDialog.Filter = "AVI files (*.wav)|*.wav";
                textDialog.FilterIndex = 1;
                textDialog.DefaultExt = "wav";
                textDialog.OverwritePrompt = true;

                if (textDialog.ShowDialog() == true)
                {
                    try
                    {
                        if ((textDialog.FileName) != null)
                        {
                            string format = Path.GetExtension(textDialog.FileName);
                            if (format == ".wav")
                                url = textDialog.FileName;
                            else
                                url = textDialog.FileName + ".wav";
                            item.IsChecked = true;
                            flag_mic = 1;
                            micro = new Microphone(this, url);
                            micro.StartRecord();
                            if(flag_mic==10)
                                item.IsChecked = false;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }

            }
            else
            {
                item.IsChecked = false;

                if (flag_mic != 10)
                    micro.StopRecord();
                flag_mic = 0;
                OpenCvSharp.Cv2.WaitKey(1000);

            }
        }
    }
}
