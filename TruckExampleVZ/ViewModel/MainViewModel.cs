using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using TruckExampleVZ.Helpers;
using TruckExampleVZ.ServerCommunication;

namespace TruckExampleVZ.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private TruckVm selectedTruck;
        private ObservableCollection<TruckVm> trucks;
        private ObservableCollection<LoadVm> selectedLoads;
        private readonly Server server;
        public ObservableCollection<TruckVm> Trucks
        {
            get { return trucks; }

            set { trucks = value; }
        }
        public ObservableCollection<LoadVm> SelectedLoads
        {
            get { return selectedLoads; }
            set { selectedLoads = value; RaisePropertyChanged(); }
        }
        public RelayCommand SelectBtnClicked { get; set; }
        public RelayCommand UnloadBtnClicked { get; set; }
        public TruckVm SelectedTruck
        {
            get => selectedTruck;
            set
            {
                selectedTruck = value;
                RaisePropertyChanged();
                SelectedLoads = null;
            }
        }

        public MainViewModel()
        {
            System.Diagnostics.Debug.WriteLine("!!! MainViewModel.IsInDesignMode: " + IsInDesignMode.ToString());
            // Thead nummer anzeigen
            var tid3 = Dispatcher.CurrentDispatcher.Thread.ManagedThreadId;
            Trucks = new ObservableCollection<TruckVm>();
            SelectedLoads = new ObservableCollection<LoadVm>();
            SelectBtnClicked = new RelayCommand(new Action(ShowLoadBtnClicked), IsShowLoadBtnClickedEnabled);
            //SelectBtnClicked = new RelayCommand(ShowLoadBtnClicked); //shortcut
            UnloadBtnClicked = new RelayCommand(
                () => Trucks.Remove(SelectedTruck),
                () => SelectedTruck != null
            );

            if (IsInDesignMode)
            {
                GenerateDemoData();
            }
            else
            {
                server = new Server(GuiUpdateReceived);
            }
        }

        private void GuiUpdateReceived(string s)
        {
            System.Diagnostics.Debug.WriteLine("!!! MainViewModel.GuiUpdateReceived.param: " + s);
            //ID@Abfahrtsort@Ladungsbez@Menge@Gewicht
            MessageConverter conv = new MessageConverter(s);
            //Thread Nummer von ClientHandler
            var tid = Dispatcher.CurrentDispatcher.Thread.ManagedThreadId;
            App.Current.Dispatcher.Invoke(() =>
            {
                Trucks.Add(conv.Convert());
                //Thread von "Gui"-Thread
                var tid2 = Dispatcher.CurrentDispatcher.Thread.ManagedThreadId;

                Console.Write("!!! MainViewModel.GuiUpdateReceived.App.Current.Dispatcher.Invoke: " + s + " !!! with ThreadID: " + tid2.ToString());

            });

        }

        private bool IsShowLoadBtnClickedEnabled()
        {
            return SelectedTruck != null;
        }

        private void ShowLoadBtnClicked()
        {
            SelectedLoads = SelectedTruck.Loads;
        }

        private void GenerateDemoData()
        {
            Trucks.Add(new TruckVm()
            {
                Id = "SL-123AB",
                Source = "Salzburg",
                Loads = new ObservableCollection<LoadVm>() {
                    new LoadVm(){ Description = "Mozartkugel", Amount = 1000, Weight = 300 },
                    new LoadVm(){ Description = "Mettenwürste", Amount = 500, Weight = 150 }
                }
            });

            Trucks.Add(new TruckVm()
            {
                Id = "SL-123AB",
                Source = "Graz",
                Loads = new ObservableCollection<LoadVm>() {
                    new LoadVm(){ Description = "Wein", Amount = 1000, Weight = 1000 },
                    new LoadVm(){ Description = "Äpfel", Amount = 500, Weight = 300 }
                }
            });

        }

    }
}