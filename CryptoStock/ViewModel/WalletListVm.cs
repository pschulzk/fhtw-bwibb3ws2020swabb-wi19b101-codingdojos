using CryptoStock.Helpers;
using CryptoStock.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoStock.ViewModel
{
    public class WalletListVm : ViewModelBase
    {
        
        private readonly MainViewModel main;
        private readonly DataStore dataStore;
        private readonly IMessenger msg = Messenger.Default;


        public readonly RelayCommand<Wallet> DeleteBtnClicked;
        private Wallet selectedEntry;
        public Wallet SelectedEntry { get => selectedEntry; set { selectedEntry = value; RaisePropertyChanged(); } }


        public WalletListVm()
        {
            main = SimpleIoc.Default.GetInstance<MainViewModel>();
            dataStore = main.dataStore;
            DeleteBtnClicked = new RelayCommand<Wallet>(DeleteItem);

            dataStore.AddWallet(new Wallet(777, "xxxx"));
        }

        public void DeleteItem(Wallet obj)
        {
            //inform mainviewmodel about changes...
            msg.Send(new NotificationMessage<Wallet>(obj, "deleted"));
        }
    }
}
