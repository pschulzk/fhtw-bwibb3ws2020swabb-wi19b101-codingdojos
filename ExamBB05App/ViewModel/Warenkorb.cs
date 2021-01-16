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
        public Warenkorb(int id)
        {
            Id = id;
            Produkte = new ObservableCollection<Produkt>();
        }

        public int Id { get; set; }

        public ObservableCollection<Produkt> Produkte { get; set; }

    }
}
