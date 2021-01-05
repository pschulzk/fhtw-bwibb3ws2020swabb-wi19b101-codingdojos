using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System;
using GalaSoft.MvvmLight.CommandWpf;

namespace exercise_04.ViewModel
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
        private AnimalVm selectedData;
        public ObservableCollection<AnimalVm> Data { get; set; }
        public ObservableCollection<string> Habitates { get; set; }
        public RelayCommand DeleteBtnClicked { get; set; }

        public AnimalVm SelectedData
        {
            get { return selectedData; }
            set { selectedData = value; RaisePropertyChanged(); }
        }

        public MainViewModel()
        {
            Data = new ObservableCollection<AnimalVm>();
            Habitates = new ObservableCollection<string>();
            LoadData();
            DeleteBtnClicked = new RelayCommand(() => { Data.Remove(SelectedData); }, () => { return SelectedData != null; });
        }

        private void LoadData()
        {
            Habitates.Add("Dschungel");
            Habitates.Add("Süßwasser");
            Habitates.Add("Steppe");
            Habitates.Add("Luft");

            Data.Add(new AnimalVm("Tiger", 10, "Raubkatze", "Dschungel", true, 6000));
            Data.Add(new AnimalVm("Goldbrasse", 4, "Fisch", "Süßwasser", false, 100000));
            Data.Add(new AnimalVm("Coala", 20, "Beuteltier", "Steppe", false, 500));
            Data.Add(new AnimalVm("Eisvogel", 1, "Vogel", "Luft", true, 50));


        }
    }
}