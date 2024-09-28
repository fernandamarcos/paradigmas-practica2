namespace Practice1
{
    class PoliceCar : Vehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car"; 
        private bool isPatrolling;
        private SpeedRadar? speedRadar;
        private PoliceStation? policeStation;
        private bool persecution;
        private string? infractorPlate;

        public PoliceCar(string plate, SpeedRadar? speedRadar = null) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            this.speedRadar = speedRadar;
            persecution = false;
        }

        public void UseRadar(Taxi taxi)
        {
            if (isPatrolling && speedRadar!= null)
            {
                speedRadar.TriggerRadar(taxi);
                string meassurement = speedRadar.GetLastReading();
                Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
                persecution = true;
                ActivateStationAlarm(taxi);
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no active radar."));
            }
        }

        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                Console.WriteLine(WriteMessage("stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("was not patrolling."));
            }
        }

        public void PrintRadarHistory()
        {
            if (speedRadar!= null)
            {
                Console.WriteLine(WriteMessage("Report radar speed history:"));
                foreach (float speed in speedRadar.SpeedHistory)
                {
                    Console.WriteLine(speed);
                }

            }
            else
            {
                Console.WriteLine(WriteMessage($"has no active radar."));
            }
            
        }

        public void StartPersecution(string infractorPlate)
        { 
            persecution = true; 
            this.infractorPlate = infractorPlate;
        }


        public void SetPoliceStation(PoliceStation policeStation)
        {
            this.policeStation = policeStation;
        }

        public void ActivateStationAlarm(Taxi infractor)
        {
            if (policeStation != null)
            {
                policeStation.ActivateAlarm();
                infractorPlate = infractor.GetPlate();
                policeStation.SendAlarm(infractor, this);
            }
            
        }
    }
}