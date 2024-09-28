using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class Scooter : Vehicle
    {
        private static string typeOfVehicle = "Scooter";
        private float speed;
        public Scooter() : base (typeOfVehicle, null)
        {
            speed = 20f;
        }

    }
}
