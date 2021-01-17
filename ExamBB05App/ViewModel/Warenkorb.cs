using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBB05App.ViewModel
{
    public class Warenkorb : ViewModelBase
    {
        public int Id { get; set; }

        public ObservableCollection<Produkt> Produkte { get; set; }

        public int MengeAllerProdukte
        {
            get
            {
                int summe = 0;
                foreach (Produkt p in Produkte)
                {
                    summe = summe + p.Amount;
                }
                return summe;
            }
        }

        public float WertAllerProdukte
        {
            get
            {
                float summe = 0;
                foreach (Produkt p in Produkte)
                {
                    summe = summe + p.Price;
                }
                return summe;
            }
        }

        public Warenkorb(int id)
        {
            Id = id;
            Produkte = new ObservableCollection<Produkt>();
        }
        

    }
}
