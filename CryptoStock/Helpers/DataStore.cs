using CryptoStock.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CryptoStock.Helpers
{
    public class DataStore
    {
        private readonly ObservableCollection<Wallet> _wallets;
        public ObservableCollection<Wallet> Wallets
        {
            get { return _wallets; }
        }

        private readonly CustomLogger logger;

        public DataStore(CustomLogger logger)
        {
            this.logger = logger;
            _wallets = new ObservableCollection<Wallet>();

            logger.WriteLog("DataStore::CONSTRUCTOR");
        }

        public void AddWallet(Wallet newWallet)
        {
            _wallets.Add(newWallet);
            string jsonString = JsonSerializer.Serialize(_wallets);
            logger.WriteLog("!!! AddWallet -> " + jsonString);
        }

        public void RemoveWallet(Wallet wallet)
        {
            _wallets.Remove(wallet);
            string jsonString = JsonSerializer.Serialize(_wallets);
            logger.WriteLog("!!! RemoveWallet -> " + jsonString);
        }

        public ObservableCollection<Wallet> GetWalletsClone()
        {
            ObservableCollection<Wallet> retval = new ObservableCollection<Wallet>();
            {
                foreach (var item in _wallets)
                {
                    if (retval.IndexOf(item) < 0)
                    {
                        retval.Add(item);
                    }
                }
                return retval;
            }
        }
    }
}
