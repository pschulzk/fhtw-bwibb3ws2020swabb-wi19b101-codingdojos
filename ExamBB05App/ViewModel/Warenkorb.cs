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
        public string MengeAllerProdukte
        {
            get
            {
                int summe = 0;
                foreach (Produkt p in Produkte)
                {
                    summe = summe + p.Amount;
                }
                return summe.ToString();
            }
        }

        public string WertAllerProdukte
        {
            get
            {
                float summe = 0;
                foreach (Produkt p in Produkte)
                {
                    summe = summe + p.Price;
                }
                return summe.ToString() + " €";
            }
        }

        public Warenkorb(int id)
        {
            Id = id;
            Produkte = new ObservableCollection<Produkt>();
        }

        public int Id { get; set; }

        public ObservableCollection<Produkt> Produkte { get; set; }

    }
}
