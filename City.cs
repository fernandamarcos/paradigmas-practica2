using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class City : IMessageWritter
    {
        private string cityName;
        private List<PoliceStation> StationsList;
        private List<string> TaxiPlateList;

        public City(string cityName)
        {
            this.cityName = cityName;
            this.StationsList = new List<PoliceStation>();
            this.TaxiPlateList = new List<string>();

        }

        public void AddPoliceStation(PoliceStation policeStation)
        {
            StationsList.Add(policeStation);
            Console.WriteLine(WriteMessage($"{policeStation.WriteMessage("registered station.")}"));
        }

        public void RemovePoliceStation(PoliceStation policeStation)
        {
            StationsList.Remove(policeStation);
            Console.WriteLine(WriteMessage($"{policeStation.WriteMessage("removed station.")}"));
        }

        public void RegisterTaxiLicense(Taxi taxi)
        {
            TaxiPlateList.Add(taxi.GetPlate());
            taxi.SetIsLicensed();
            Console.WriteLine(WriteMessage($"{taxi.WriteMessage("registered taxi.")}"));
        }

        public void RemoveTaxiLicense(Taxi taxi)
        {
            TaxiPlateList.Remove(taxi.GetPlate());   
            taxi.RemoveLicense();
            Console.WriteLine(WriteMessage($"{taxi.WriteMessage("license removed.")}"));
        }

        public string GetCityName()
        {
            return cityName;
        }
        public override string ToString()
        {
            return $"City {GetCityName()}";
        }

        public string WriteMessage(string message)
        {
            return $"{this}: {message}";
        }
    }
}
