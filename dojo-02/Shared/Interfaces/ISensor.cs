using dojo_02.Shared.Interfaces;
using Shared.BaseModels;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface ISensor : IItemBase
    {

        Type SensorValueType { get; }
        object SensorValue { get; set; }
        SensorModeType SensorMode { get; set; }



    }
}
