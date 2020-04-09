using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDataTriggerAttempt
{
    public sealed class SingletonBoy : INotifyPropertyChanged
    {
        private static SingletonBoy instance = null;
        private static readonly object padlock = new object();

        private bool boolFlag = false;
        public bool BoolFlag
        {
            get { return boolFlag; }
            set
            {
                boolFlag = value;
                RaisePropertyChanged("BoolFlag");
            }
        }

        SingletonBoy() //closed
        {
        }

        public static SingletonBoy Instance //threadsafe
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SingletonBoy();
                    }
                    return instance;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
