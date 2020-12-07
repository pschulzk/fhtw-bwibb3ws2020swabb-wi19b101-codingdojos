using dojo_02.Shared.Interfaces;
using Dojo3Help.ViewModel;
using GalaSoft.MvvmLight;
using Shared.BaseModels;
using Shared.Interfaces;
using Shared.Models;
using System;

namespace CodingDojo2.ViewModel
{
    public class ItemVm : ItemBase
    {
        private ItemBase baseItem;

        public ItemVm(string name, string description, string room, int id) : base(name, description, room, id)
        {
            Description = description;
            Name = name;
            Room = room;
        }

        public ItemVm(ISensor sensor, string name = null, string description = null, string room = null, int id = 0) : base(name, description, room, id)
        {
            baseItem = sensor as ItemBase;
        }

        public ItemVm(IActuator actuator, string name = null, string description = null, string room = null, int id = 0) : base(name, description, room, id)
        {
            baseItem = actuator as ItemBase;
        }




        public new int Id
        {
            get { return baseItem.Id; }
        }

        public new string Description
        {
            get { return baseItem.Description; }
            set { baseItem.Description = value; RaisePropertyChanged(); }
        }

        public new string Name
        {
            get { return baseItem.Name; }
            set { baseItem.Name = value; RaisePropertyChanged(); }
        }

        public new string Room
        {
            get { return baseItem.Room; }
            set { baseItem.Room = value; RaisePropertyChanged(); }
        }

        public new int PosX
        {
            get { return baseItem.PosX; }
            set { baseItem.PosX = value; RaisePropertyChanged(); }
        }

        public new int PosY
        {
            get { return baseItem.PosY; }
            set { baseItem.PosY = value; RaisePropertyChanged(); }
        }

        public string ValueType
        {
            get
            {
                if (baseItem is ISensor)
                    return (baseItem as BaseSensor).SensorValueType.Name;
                else if (baseItem is IActuator)
                    return (baseItem as BaseActuator).ActuatorValueType.Name;
                else
                    throw new NotImplementedException();
            }

        }


        public Type ItemType
        {
            get
            {
                if (baseItem is ISensor) return typeof(ISensor);
                else if (baseItem is IActuator) return typeof(IActuator);
                else throw new NotImplementedException();
            }
        }


        public string Mode
        {
            get
            {
                if (baseItem is ISensor) return (baseItem as BaseSensor).SensorMode.ToString();
                if (baseItem is IActuator) return (baseItem as BaseActuator).ActuatorMode.ToString();
                else return null;
            }
            set
            {
                if (baseItem is ISensor)
                    (baseItem as BaseSensor).SensorMode = (SensorModeType)Enum.Parse(typeof(SensorModeType), value, false);
                if (baseItem is IActuator)
                    (baseItem as BaseActuator).ActuatorMode = (ModeType)Enum.Parse(typeof(ModeType), value, false);

                RaisePropertyChanged();
            }
        }

        public object Value
        {
            get
            {
                if (baseItem is ISensor)
                    return (baseItem as BaseSensor).SensorValue;
                else if (baseItem is IActuator)
                    return (baseItem as BaseActuator).ActuatorValue;
                else
                    throw new NotImplementedException();
            }

            set
            {
                if (baseItem is ISensor) (baseItem as BaseSensor).SensorValue = value;
                else if (baseItem is IActuator) (baseItem as BaseActuator).ActuatorValue = value;
                else
                    throw new NotImplementedException();
                RaisePropertyChanged();

            }
        }


    }
}