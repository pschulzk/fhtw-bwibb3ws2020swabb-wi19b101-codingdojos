using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseSimpleMultiVM.ViewModel
{
    public class OverviewVm : DetailVm
    {

        private PersonVm selectedEntry;
        public RelayCommand<PersonVm> DeleteBtnClicked { get; set; }
        public PersonVm SelectedEntry { get => selectedEntry; set { selectedEntry = value; RaisePropertyChanged(); } }

    
        public OverviewVm() : base()
        {
            DeleteBtnClicked = new RelayCommand<PersonVm>(DeleteItem);
        }

        private void DeleteItem(PersonVm obj)
        {
            //inform mainviewmodel about changes...
            msg.Send<NotificationMessage<PersonVm>>(new NotificationMessage<PersonVm>(obj,"deleted"));
        }

     
    }
}
