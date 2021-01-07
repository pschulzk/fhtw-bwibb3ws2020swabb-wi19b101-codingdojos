using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoStock.Models
{
    class Wallet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }

        public Wallet(int id, string name, int balance = 0)
        {
            Id = id;
            Name = name;
            Balance = balance;
        }
    }
}
