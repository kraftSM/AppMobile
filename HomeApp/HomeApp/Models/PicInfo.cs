using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace HomeApp.Models
{
    public  class PicInfo : INotifyPropertyChanged
    {
        private string _picFileName;
        private string _picFilePath;
        private DateTime _picCreateDate;

        public PicInfo(string picFileName, string picFilePath, DateTime createDate)
        {
            _picFileName = picFileName;
            _picFilePath = picFilePath;
            _picCreateDate = createDate;
        }

        public string NameFile
        {
            get { return _picFileName; }
            set
            {
                if (_picFileName != value)
                {
                    _picFileName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string PathToPicture
        {
            get { return _picFilePath; }
            set
            {
                if (_picFilePath != value)
                {
                    _picFilePath = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DateTime CreateDate
        {
            get { return _picCreateDate; }
            set
            {
                if (_picCreateDate != value)
                {
                    _picCreateDate = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
