using CodingDojo2.DataSimulation;
using CodingDojo2.ViewModel;
using Dojo3Help.ViewModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Shared.BaseModels;
using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Threading;

namespace dojo_02.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        public BrushConverter con = new BrushConverter();
        private Simulator<ItemVm> sim;
        private readonly ObservableCollection<ItemVm> modelItems = new ObservableCollection<ItemVm>();
        public ObservableCollection<ItemVm> SensorList { get; set; }
        public ObservableCollection<ItemVm> ActorList { get; set; }
        public RelayCommand SensorAddBtnClickCmd { get; set; }
        public RelayCommand SensorDelBtnCmd { get; set; }
        public RelayCommand ActuatorAddBtnClickCmd { get; set; }
        public RelayCommand ActuatorDelBtnClickCmd { get; set; }
        private readonly string currentTime = DateTime.Now.ToLocalTime().ToShortTimeString();
        private readonly string currentDate = DateTime.Now.ToLocalTime().ToShortDateString();

        public ObservableCollection<string> ModeSelectionList { get; private set; }

        private string _now;

        public MainViewModel()
        {
            SensorList = new ObservableCollection<ItemVm>();
            ActorList = new ObservableCollection<ItemVm>();
            ModeSelectionList = new ObservableCollection<string>();

            //Fill ModeSelectionList
            foreach (var item in Enum.GetNames(typeof(SensorModeType)))
            {
                ModeSelectionList.Add(item);
            }
            foreach (var item in Enum.GetNames(typeof(ModeType)))
            {
                ModeSelectionList.Add(item);

            }

            LoadData();

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
            }
        }

        void TimerTick(object sender, EventArgs e)
        {
            CurrentDateTime = DateTime.Now.ToString("t");
        }

        private void LoadData()
        {
            sim = new Simulator<ItemVm>(modelItems);
            while (sim.Items != null)
            {
                foreach (var item in sim.Items)
                {
                    if (item.ItemType.Equals(typeof(ISensor)))
                        SensorList.Add(item);
                    else if (item.ItemType.Equals(typeof(IActuator)))
                        ActorList.Add(item);
                }
            }


        }

    }
}
