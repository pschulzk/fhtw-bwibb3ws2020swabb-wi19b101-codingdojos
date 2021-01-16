using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoStock.Models
{
    public class Wallet
    {
        public bool Active { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }

        public Wallet(int id, string name, int balance = 0)
        {
            Active = true;
            Id = id;
            Name = name;
            Balance = balance;
        }
    }
}
