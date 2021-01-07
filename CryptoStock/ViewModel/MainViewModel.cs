using CryptoStock.Communication;
using CryptoStock.Helpers;
using CryptoStock.Models;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Threading;
// using System.Text.Json;
// using System.Text.Json.Serialization;

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

        private readonly CustomLogger logger;
        private readonly Server server;

        private readonly ObservableCollection<Wallet> wallets;


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            logger = new CustomLogger();
            logger.WriteLog("MainViewModel.IsInDesignMode: " + IsInDesignMode.ToString());
            server = new Server(ClientMessageReceived, logger);

            wallets = new ObservableCollection<Wallet>();
        }

        private void ClientMessageReceived(string s)
        {
            //ID@Abfahrtsort@Ladungsbez@Menge@Gewicht
            if (!s.Contains("@"))
            {
                logger.WriteLog("ERROR: Received message is malformed. Message: " + s);
                return;
            }
            MessageConverter conv = new MessageConverter();
            wallets.Add(conv.Convert(s));
            // string jsonString = JsonSerializer.Serialize(weatherForecast);
            // System.Diagnostics.Debug.WriteLine("#### LOGGER ### -> " + message);

            //Thread Nummer von ClientHandler
            // var tid = Dispatcher.CurrentDispatcher.Thread.ManagedThreadId;
            App.Current.Dispatcher.Invoke(() =>
            {
                // Trucks.Add(conv.Convert());

                //Thread von "Gui"-Thread
                var tid2 = Dispatcher.CurrentDispatcher.Thread.ManagedThreadId;

                logger.WriteLog("MainViewModel.ClientMessageReceived.App.Current.Dispatcher.Invoke: " + s + " !!! with ThreadID: " + tid2.ToString());

            });

        }
    }
}