using System;
using System.Collections.ObjectModel;
using CryptoStock.Models;
using CryptoStock.ViewModel;

namespace CryptoStock.Helpers
{
    class MessageConverter
    {

        public Wallet Convert(string message)
        {
            //ID@Name@Balance
            string[] temp = message.Split('@');
            Wallet wallet = new Wallet
            (
                Int32.Parse(temp[0]),
                temp[1]
            );
            return wallet;
        }
    }
}
