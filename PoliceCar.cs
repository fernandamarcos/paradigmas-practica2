namespace Practice1
{
    class PoliceCar : Vehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car"; 
        private bool isPatrolling;
        private SpeedRadar speedRadar;
        public PoliceStation policeStation {  get; set; }
        public bool persecution;
        public string infractorPlate;

        public PoliceCar(string plate) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            speedRadar = new SpeedRadar();
            persecution = false;
        }

        public void UseRadar(Vehicle vehicle)
        {
            if (isPatrolling)
            {
                speedRadar.TriggerRadar(vehicle);
                string meassurement = speedRadar.GetLastReading();
                Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
                persecution=true;
                ActivateAlarm(vehicle.GetPlate());
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
            Console.WriteLine(WriteMessage("Report radar speed history:"));
            foreach (float speed in speedRadar.SpeedHistory)
            {
                Console.WriteLine(speed);
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

        public void ActivateAlarm(string infractorPlate)
        {
            policeStation.alarm = true;
            this.infractorPlate = infractorPlate;
            policeStation.SendAlarm(infractorPlate, this);
        }
    }
}