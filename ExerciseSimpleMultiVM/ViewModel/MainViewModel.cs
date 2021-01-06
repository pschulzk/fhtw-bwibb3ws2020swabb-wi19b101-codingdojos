using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.CommandWpf;

namespace ExerciseSimpleMultiVM.ViewModel
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
        private IMessenger msg = Messenger.Default;
        private ViewModelBase currentDetailView;

        public RelayCommand<string> ChangeDetailView { get; set; }
        public ObservableCollection<PersonVm> PersonList { get; set; }
        public ViewModelBase CurrentDetailView
        {
            get => currentDetailView;
            set
            {
                currentDetailView = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel()
        {
            PersonList = new ObservableCollection<PersonVm>();
            //set default Detail view:
            CurrentDetailView = SimpleIoc.Default.GetInstance<AddVm>();

            ChangeDetailView = new RelayCommand<string>(SwitchView);
            //Register on Messenger to distribute new entries in list
            msg.Register<GenericMessage<PersonVm>>(this, Received);
            //REgister on Messenger to handle deletion 
            msg.Register<NotificationMessage<PersonVm>>(this, EntryDeleted);
            //Register on Messenger change view
            msg.Register<GenericMessage<string>>(this, SwitchViewTrigger);
        }


        private void SwitchViewTrigger(GenericMessage<string> obj)
        {
            System.Diagnostics.Debug.WriteLine("MainViewModel -> SwitchViewTrigger.obj.Content: " + obj.Content);
            SwitchView(obj.Content);
        }


        private void SwitchView(string obj)
        {
            switch (obj)
            {
                case "Overview":
                    CurrentDetailView = SimpleIoc.Default.GetInstance<OverviewVm>();
                    break;
                case "Detail":
                    CurrentDetailView = SimpleIoc.Default.GetInstance<DetailVm>();
                    break;

                default:
                case "NewData":
                    CurrentDetailView = SimpleIoc.Default.GetInstance<AddVm>();
                    break;
            }
        }

        private void EntryDeleted(NotificationMessage<PersonVm> obj)
        {
            if (obj.Notification.Equals("deleted"))
                PersonList.Remove(obj.Content);
            //inform others about the change
            InformAboutChange();
        }

        private void Received(GenericMessage<PersonVm> obj)
        {
            PersonList.Add(obj.Content);
            InformAboutChange();
        }

        private void InformAboutChange()
        {
            msg.Send<GenericMessage<ObservableCollection<PersonVm>>>(new GenericMessage<ObservableCollection<PersonVm>>(PersonList));

        }
    }
}