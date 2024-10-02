using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class PoliceStation : IMessageWritter
    {
        private int stationNumber;   
        private List<PoliceCar> PoliceCarList {  get; set; }
        private bool alarm; 
        private City city;

        public PoliceStation(int stationNumber, City city) 
        { 
            this.stationNumber= stationNumber;
            alarm = false;
            PoliceCarList = new List<PoliceCar>();
            this.city = city;

        }

        public void RegisterNewCar(PoliceCar car)
        {
            PoliceCarList.Add(car);
            car.SetPoliceStation(this);
            Console.WriteLine(car.WriteMessage($"registered in station {GetStationNumber()}"));
        }

        public void ActivateAlarm()
        {
            alarm = true;
        }

        public void SendAlarm(RegisteredVehicle infractor, PoliceCar policeWhoDetected)
        {
            Console.WriteLine(WriteMessage($"alarm activated by {policeWhoDetected.ToString()}. Infractor information: {infractor.ToString()}"));
            foreach (var car in PoliceCarList) 
            {
                if (car != policeWhoDetected && car.IsPatrolling()) 
                {
                    car.StartPersecution(infractor.GetPlate());
                }
                
            }

        }

        public int GetStationNumber()
        {
            return stationNumber;
        }
        
        public List<PoliceCar> GetPoliceCars()
        {
            return PoliceCarList;
        }

        public override string ToString()
        {
            return $"Police Station {GetStationNumber()}";
        }

        public string WriteMessage(string message)
        {
            return $"{this}: {message}";
        }


    }
}
