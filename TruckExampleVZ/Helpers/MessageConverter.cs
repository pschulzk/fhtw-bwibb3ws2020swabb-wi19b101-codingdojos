using System.Collections.ObjectModel;
using TruckExampleVZ.ViewModel;

namespace TruckExampleVZ.Helpers
{
    class MessageConverter
    {
        string message;
        public MessageConverter(string msg)
        {
            message = msg;
        }

        public TruckVm Convert()
        {
            //ID@Abfahrtsort@Ladungsbez@Menge@Gewicht
            string[] temp = message.Split('@');
            TruckVm truck = new TruckVm()
            {
                Id = temp[0],
                Source = temp[1],
                Loads = new ObservableCollection<LoadVm>()
            };
            for (int i = 2; i < temp.Length; i = i + 3)
            {
                truck.Loads.Add(new LoadVm()
                {
                    Description = temp[i],
                    Amount = int.Parse(temp[i + 1]),
                    Weight = int.Parse(temp[i + 2])
                });
            }
            return truck;
        }
    }
}
