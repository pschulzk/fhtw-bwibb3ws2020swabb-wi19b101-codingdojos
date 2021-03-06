﻿using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBB05App.ViewModel
{
    public class Produkt : ViewModelBase
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public float Price { get; set; }

        public Produkt(int id, int amount, float price)
        {
            this.Id = id;
            this.Amount = amount;
            this.Price = price;
        }

        public void Reduce()
        {
            if (Amount < 2) return;
            Amount = Amount - 1;
            RaisePropertyChanged("Amount");
        }


    }
}
