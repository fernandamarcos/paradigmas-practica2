using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class PoliceStation
    {
        public int stationNumber;   
        private List<PoliceCar> PoliceCarList {  get; set; }
        public bool alarm; 

        public PoliceStation(int stationNumber) 
        { 
            this.stationNumber= stationNumber;
            alarm = false;
            PoliceCarList = new List<PoliceCar>();
        }

        public void RegisterNewCar(PoliceCar car)
        {
            PoliceCarList.Add(car);
            
        }

    }
}
