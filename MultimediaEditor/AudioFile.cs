using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultimediaEditor
{
    [Serializable()]
    public class AudioFile
    {
        private string _url;
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _totaltime;
        public int TotalTime
        {
            get { return _totaltime; }
            set { _totaltime = value; }
        }

        private int _starttime;
        public int StartTime
        {
            get { return _starttime; }
            set { _starttime = value; }
        }

        private int _endtime;
        public int EndTime
        {
            get { return _endtime; }
            set { _endtime = value; }
        }

        private string _format;
        public string Format
        {
            get { return _format; }
            set { _format = value; }
        }
        private double _left;
        public double Left
        {
            get { return _left; }
            set { _left = value; }
        }
        private double _len;
        public double Len
        {
            get { return _len; }
            set { _len = value; }
        }
    }
}
