using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBB05App.ViewModel
{
    public class Produkt : ViewModelBase
    {
        public Produkt(int id, int amount, float price)
        {
            this.Id = id;
            this.Amount = amount;
            this.Price = price;
        }

        public int Id { get; set; }

        public int Amount { get; set; }

        public float Price { get; set; }
    }
}
