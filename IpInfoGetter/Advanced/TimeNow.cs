using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IpInfoGetter
{
    class TimeNow : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        private string timenow;
        public string Timenow
        {
            get { return timenow; }
            set
            {
                timenow = value;
                OnPropertyChanged();
            }
        }
        public TimeNow()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Task.Delay(1000).Wait();
                    Timenow = DateTime.Now.ToString("HH.mm.ss");
                }
            });
        }

    }
}
