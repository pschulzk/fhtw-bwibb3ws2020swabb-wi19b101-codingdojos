using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBB05App.ViewModel
{
    public class Warenkorb : ViewModelBase
    {
        public int Id { get; set; }

        public ObservableCollection<Produkt> Produkte { get; set; }

        private int mengeAllerProdukte = 0;
        public int MengeAllerProdukte { get { return mengeAllerProdukte; } }

        private float wertAllerProdukte = 0;
        public float WertAllerProdukte { get { return wertAllerProdukte; } }

        public Warenkorb(int id)
        {
            Id = id;
            Produkte = new ObservableCollection<Produkt>();
            UpdateProps();
            Produkte.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) => UpdateProps();
        }

        public void UpdateProps()
        {
            mengeAllerProdukte = 0;
            wertAllerProdukte = 0;

            if (Produkte.Count > 0)
            {
                foreach (Produkt p in Produkte)
                {
                    mengeAllerProdukte = mengeAllerProdukte + p.Amount;
                    wertAllerProdukte = wertAllerProdukte + p.Amount * p.Price;
                }
            }

            RaisePropertyChanged("Produkte");
            RaisePropertyChanged("MengeAllerProdukte");
            RaisePropertyChanged("WertAllerProdukte");
        }


    }
}
