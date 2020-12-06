using Dojo3Help.ViewModel;
using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace dojo_02.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        //public event PropertyChangedEventHandler PropertyChanged;
        private string _now;

        public MainViewModel()
        {
            _now = DateTime.Now.ToString("t");
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(500)
            };
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
        }

        public string CurrentDateTime
        {
            get { return _now; }
            private set
            {
                _now = value;
                RaisePropertyChanged();
                // PropertyChanged.Invoke(this, new PropertyChangedEventArgs("CurrentDateTime"));
            }
        }

        void TimerTick(object sender, EventArgs e)
        {
            CurrentDateTime = DateTime.Now.ToString("t");
        }

    }
}
