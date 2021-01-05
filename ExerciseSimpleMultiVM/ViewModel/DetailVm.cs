using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseSimpleMultiVM.ViewModel
{
    public class DetailVm : ViewModelBase
    {

        protected IMessenger msg = Messenger.Default;
        private ObservableCollection<PersonVm> personList;


        public ObservableCollection<PersonVm> PersonList
        {
            get => personList;
            set
            {
                personList = value;
                RaisePropertyChanged();
            }
        }

        public DetailVm()
        {
            PersonList = new ObservableCollection<PersonVm>();


            //Register for list
            msg.Register<GenericMessage<ObservableCollection<PersonVm>>>(this, ListReceived);
        }

        protected void ListReceived(GenericMessage<ObservableCollection<PersonVm>> obj)
        {
            PersonList = obj.Content;
        }
    }
}
