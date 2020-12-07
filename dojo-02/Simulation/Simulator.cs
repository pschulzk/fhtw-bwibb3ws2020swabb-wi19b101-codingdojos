using CodingDojo2.ViewModel;
using dojo_02.Shared.Interfaces;
using Shared.BaseModels;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodingDojo2.DataSimulation
{
    public class Simulator<T> where T : IItemBase
    {
        public ObservableCollection<T> Items;
        private static Random rand = new Random(5);

        /// <summary>
        /// Generates Demo Data (Sensors and Actuators and Starts manipulating the Values every 3 Secs.
        /// Light is only changed if Mode=auto!
        /// </summary>
        public Simulator(ObservableCollection<T> Items)
        {
            GenerateDemoData(Items as ObservableCollection<ItemBase>);
            ThreadPool.QueueUserWorkItem(StartGeneratingDemoData);
        }



        private void GenerateDemoData(ObservableCollection<ItemBase> Items)
        {
            Items = new ObservableCollection<ItemBase>
            {
                //Sensors
                new Switch("0.01", "TA Wohnzimmer", "WZ", 1),
                new Switch("0.02", "TA Wohnzimmer", "WZ", 2),
                new Switch("0.03", "TA Badezimmer", "Bad", 3),
                new DoorContact("0.04", "Haustüre", "Garderobe", 4),
                new MotionDedector("1.100", "IR Haustüre", "Garderobe", 5),
                new MotionDedector("1.101", "IR Wohnzimmer", "WZ", 6),
                new Temperature("0.10", "Temp Badezimmer", "Bad", 7),
                new Temperature("0.11", "Temp Wohnimmer", "WZ", 8),
                new Temperature("0.12", "Temp Aussen Nord", "Garten", 9),
                new TwilightSwitch("0.20", "Dämmerungssensor Nord", "Garten", 10),
                //Actors
                new Light("2.00", "Licht Wohnzimmer", "WZ", 100),
                new Light("2.01", "Licht Aussen", "Garten", 101),
                new Light("2.02", "Licht Badezimmer", "Bad", 102),
                new PowerJack("2.03", "Dose Badezimmer", "Bad", 103),
                new PowerJack("2.04", "Dose Wohnzimmer", "WZ", 104),
                new PowerJack("2.05", "Dose Wohnzimmer", "WZ", 105)
            };
        }

        private void StartGeneratingDemoData(object o)
        {
            while (Items != null)
            {
                try
                {
                    (Items[0] as Switch).SensorValue = RandNo();
                    (Items[1] as Switch).SensorValue = RandNo();
                    (Items[2] as Switch).SensorValue = RandNo();

                    (Items[3] as DoorContact).SensorValue = rand.Next(0, 3);
                    (Items[3] as DoorContact).ActuatorValue = rand.Next(0, 3);

                    (Items[4] as MotionDedector).SensorValue = RandNo();
                    (Items[5] as MotionDedector).SensorValue = RandNo();

                    (Items[6] as Temperature).SensorValue = (rand.Next(0, 110) - 50) / 1.2;
                    (Items[7] as Temperature).SensorValue = (rand.Next(0, 40)) / 1.1;
                    (Items[8] as Temperature).SensorValue = (rand.Next(0, 100) / 2.2);

                    (Items[9] as TwilightSwitch).SensorValue = (rand.Next(0, 1000));


                    if ((Items[10] as Light).ActuatorMode.Equals(ModeType.Auto))
                        (Items[10] as Light).ActuatorValue = RandNo();
                    if ((Items[11] as Light).ActuatorMode.Equals(ModeType.Auto))
                        (Items[11] as Light).ActuatorValue = RandNo();
                    if ((Items[12] as Light).ActuatorMode.Equals(ModeType.Auto))
                        (Items[12] as Light).ActuatorValue = RandNo();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.GetType().FullName);
                    Console.WriteLine(e.Message);
                }

                Thread.Sleep(3000);
            }
        }
        private int RandNo()
        {
            if (rand.Next(1, 100) > 50) return 1;
            else return 0;

        }
    }
}
