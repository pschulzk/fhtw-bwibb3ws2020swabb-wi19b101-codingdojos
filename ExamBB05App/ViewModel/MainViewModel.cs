using ExamBB05App.ServerCommunication;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Globalization;

namespace ExamBB05App.ViewModel
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

        public ObservableCollection<Warenkorb> Warenkoerbe { get; set; }

        public int SumAmountProdukte { get; set; }

        public float SumPriceProdukte { get; set; }

        private Warenkorb selectedWarenkorb;

        public Warenkorb SelectedWarenkorb
        {
            get { return selectedWarenkorb; }
            set
            {
                selectedWarenkorb = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand<Produkt> DeleteProdukt { get; set; }

        public RelayCommand<Warenkorb> DeleteAlleProdukte { get; set; }

        readonly Server serverConnection;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            if (IsInDesignMode)
            {
                   // WTF
            }
            else
            {
                Warenkoerbe = new ObservableCollection<Warenkorb>();

                serverConnection = new Server(GuiUpdater);

                DeleteProdukt = new RelayCommand<Produkt>(
                    (Produkt p) =>
                    {
                        foreach (Warenkorb warenkorb in Warenkoerbe)
                        {
                            foreach (Produkt produkt in warenkorb.Produkte)
                            {
                                if (produkt == p)
                                {
                                    if (produkt.Amount > 1)
                                    {
                                        produkt.Amount = produkt.Amount - 1;
                                    }
                                    else
                                    {
                                        warenkorb.Produkte.Remove(produkt);
                                    }
                                    UpdateProps();
                                    break;
                                }
                            }
                        }
                    });

                DeleteAlleProdukte = new RelayCommand<Warenkorb>(
                    (Warenkorb w) =>
                    {
                        System.Diagnostics.Debug.WriteLine("!!! DeleteAlleProdukte: " + w.Id.ToString());
                        foreach (Warenkorb warenkorb in Warenkoerbe)
                        {
                            if (selectedWarenkorb == warenkorb)
                            {
                                break;
                            }
                        }

                        UpdateProps();
                    });
            }

        }

        private void UpdateProps()
        {
            SumAmountProdukte = 0;

            SumPriceProdukte = 0;

            foreach (Warenkorb warenkorb in Warenkoerbe)
            {
                SumAmountProdukte += warenkorb.Produkte.Count;

                foreach (Produkt produkt in warenkorb.Produkte)
                {
                    SumPriceProdukte += produkt.Price;
                }
            }

            RaisePropertyChanged();
        }

        public void GuiUpdater(string message)
        {
            System.Diagnostics.Debug.WriteLine("!!! GuiUpdater MESSAGE: " + message);

            App.Current.Dispatcher.Invoke(
                () =>
                {

                    // Die Epfangenen Daten in die Einzelteile zerlegen:
                    string[] split = message.Split('@');

                    int newWarenkorbId = Int32.Parse(split[1].Substring(0, 4));
                    System.Diagnostics.Debug.WriteLine("!!! newWarenkorbId: " + newWarenkorbId.ToString());

                    int produkt1Id = Int32.Parse(split[2].Substring(0, 4));
                    System.Diagnostics.Debug.WriteLine("!!! produkt1Id: " + produkt1Id.ToString());

                    int produkt1Amount = Int32.Parse(split[3].Substring(0, 1));
                    System.Diagnostics.Debug.WriteLine("!!! produkt1Amount: " + produkt1Amount.ToString());

                    float produkt1Price = float.Parse(split[4].Substring(0, 4), CultureInfo.InvariantCulture);
                    System.Diagnostics.Debug.WriteLine("!!! produkt1Price: " + produkt1Price.ToString());

                    int produkt2Id = Int32.Parse(split[5].Substring(0, 4));
                    System.Diagnostics.Debug.WriteLine("!!! produkt2Id: " + produkt2Id.ToString());

                    int produkt2Amount = Int32.Parse(split[6].Substring(0, 1));
                    System.Diagnostics.Debug.WriteLine("!!! produkt2Amount: " + produkt2Amount.ToString());

                    float produkt2Price = float.Parse(split[7].Substring(0, 4), CultureInfo.InvariantCulture);
                    System.Diagnostics.Debug.WriteLine("!!! produkt2Price: " + produkt2Price.ToString());


                    Warenkorb newWarenKorb = new Warenkorb(newWarenkorbId);
                    newWarenKorb.Produkte.Add(new Produkt( produkt1Id, produkt1Amount, produkt1Price ));
                    newWarenKorb.Produkte.Add(new Produkt(produkt2Id, produkt2Amount, produkt2Price));

                    Warenkoerbe.Add(newWarenKorb);
                    UpdateProps();

                });
        }
    }
}