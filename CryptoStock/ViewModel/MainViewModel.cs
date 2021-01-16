using CryptoStock.Communication;
using CryptoStock.Helpers;
using CryptoStock.Models;
using GalaSoft.MvvmLight;
using System.Windows.Threading;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;

namespace CryptoStock.ViewModel
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
        public readonly DataStore dataStore;
        private readonly IMessenger msg = Messenger.Default;
        private readonly CustomLogger logger;
        private readonly Server server;

        public RelayCommand<string> ChangeDetailView { get; set; }
        private ViewModelBase currentDetailView;
        public ViewModelBase CurrentDetailView
        {
            get => currentDetailView;
            set
            {
                currentDetailView = value;
                RaisePropertyChanged();
            }
        }


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            // Register messengers
            msg.Register<GenericMessage<string>>(this, SwitchViewTrigger);
            msg.Register<NotificationMessage<Wallet>>(this, WalletListAction);

            ChangeDetailView = new RelayCommand<string>(SwitchView);

            logger = new CustomLogger();
            logger.WriteLog("MainViewModel::CONSTRUCTOR");
            dataStore = new DataStore(logger);

            server = new Server(ClientMessageReceived, logger);            
        }

        private void SwitchViewTrigger(GenericMessage<string> obj)
        {
            SwitchView(obj.Content);
        }

        private void SwitchView(string obj)
        {
            logger.WriteLog("MainViewModel -> SwitchView.obj.Content: " + obj);

            switch (obj)
            {
                case "WalletList":
                    CurrentDetailView = SimpleIoc.Default.GetInstance<WalletListVm>();
                    break;

                case "WalletDetails":
                    CurrentDetailView = SimpleIoc.Default.GetInstance<WalletDetailsVm>();
                    break;

                default:
                    CurrentDetailView = SimpleIoc.Default.GetInstance<WalletListVm>();
                    break;
            }
        }

        private void ClientMessageReceived(string s)
        {
            //Thread Nummer von ClientHandler
            // var tid = Dispatcher.CurrentDispatcher.Thread.ManagedThreadId;
            App.Current.Dispatcher.Invoke(() =>
            {
                ProceedClientMessage(s);

                //Thread von "Gui"-Thread
                var tid2 = Dispatcher.CurrentDispatcher.Thread.ManagedThreadId;
                logger.WriteLog("MainViewModel.ClientMessageReceived.App.Current.Dispatcher.Invoke: " + s + " !!! with ThreadID: " + tid2.ToString());

            });
        }

        private void ProceedClientMessage(string s)
        {
            //ID@Name
            if (!s.Contains("@"))
            {
                logger.WriteLog("ERROR: Received message is malformed. Message: " + s);
                return;
            }
            Wallet newWallet = MessageConverter.Convert(s);
            
        }

        private void WalletListAction(NotificationMessage<Wallet> obj)
        {
            logger.WriteLog("WalletListAction !!! ACTION: " + obj.Notification);
            if (obj.Notification.Equals("deleted"))
                dataStore.Wallets.Remove(obj.Content);

            //inform others about the change
            // InformAboutChange();
        }

    }
}