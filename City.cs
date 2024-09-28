using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class City
    {
        private string cityName;
        private List<PoliceStation> StationsList;
        private List<string> TaxiPlateList;

        private City(string cityName, List<PoliceStation> stationsList, List<string> taxiPlateList)
        {
            this.cityName = cityName;
            StationsList = stationsList;
            TaxiPlateList = taxiPlateList;
        }

        public void RegisterTaxiLicense(Taxi taxi)
        {
            TaxiPlateList.Add(taxi.GetPlate());
            taxi.SetIsLicensed();
        }

        public void RemoveTaxiLicense(Taxi taxi)
        {
            TaxiPlateList.Remove(taxi.GetPlate());    
            taxi.RemoveLicense();
        }
    }
}
