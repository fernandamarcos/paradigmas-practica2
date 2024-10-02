using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    abstract class UnregisteredVehicle : Vehicle
    {

        public UnregisteredVehicle(string typeOfVehicle) : base(typeOfVehicle)
        {

        }
        public override string ToString()
        {
            return $"{GetTypeOfVehicle()}";
        }
    }
}