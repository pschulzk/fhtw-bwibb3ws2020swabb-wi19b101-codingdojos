using System.Collections.ObjectModel;

namespace TruckExampleVZ.ViewModel
{
    public class TruckVm
    {
        public string Id { get; set; }
        public string Source { get; set; }
        public ObservableCollection<LoadVm> Loads { get; set; }


        public int SumWeight
        {
            get
            {
                int sumWeight = 0;
                foreach (var item in Loads)
                {
                    sumWeight += item.Weight;
                }
                return sumWeight;
            }
        }

        public int SumOfPieces
        {
            get
            {
                int sumPieces = 0;
                foreach (var item in Loads)
                {
                    sumPieces += item.Amount;
                }
                return sumPieces;
            }
        }
    }
}
