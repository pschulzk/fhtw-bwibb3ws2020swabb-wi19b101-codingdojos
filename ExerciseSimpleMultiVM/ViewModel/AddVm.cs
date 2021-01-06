using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using ExerciseSimpleMultiVM.Converters;

namespace ExerciseSimpleMultiVM.ViewModel
{
    public class AddVm : ViewModelBase
    {

        public PersonVm Person { get; set; }
        private IMessenger msg = Messenger.Default; //get default Messenger from MVVM light lib
        public RelayCommand AddBtnClicked { get; set; }
        public RelayCommand BtnSelectFileClick { get; set; }

        public AddVm()
        {
            Person = new PersonVm();
            AddBtnClicked = new RelayCommand(() =>
            {
                //clone the Person object and send it to mainVM
                //different Messagetypes are available, see ObjectBrowser of Galasoft.MvvmLight dll
                msg.Send<GenericMessage<PersonVm>>(new GenericMessage<PersonVm>(Person.Clone()));
                msg.Send<GenericMessage<string>>(new GenericMessage<string>("Overview"));
            },
            () => { return Person.Lastname.Length > 4; });

            BtnSelectFileClick = new RelayCommand(() => OpenFileChooser());
        }

        private void OpenFileChooser()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string uri = openFileDialog.FileName;
                System.Diagnostics.Debug.WriteLine("AddVm -> OpenFileChooser.uri: " + uri);
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(uri);
                bitmap.EndInit();
                Person.Image = bitmap;
                RaisePropertyChanged();
            }
        }
    }
}
