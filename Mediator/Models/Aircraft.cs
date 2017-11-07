namespace Mediator.Models
{
    using System;
    using Interfaces;

    public abstract class Aircraft
    {
        private readonly IAirTrafficControl _atc;
        private int _currentAltitude;

        public abstract int Ceiling { get; }

        public string CallSign { get; }

        public int Altitude
        {
            get => _currentAltitude;
            set {
                if (_currentAltitude == value) return;

                Console.Out.Write(
                    $"Aircraft {CallSign} is {(value - _currentAltitude > 0 ? "climbing" : "getting down")}!");

                Console.Out.WriteLine($" Altitude is changing from [{_currentAltitude}] to [{value}]");


                _currentAltitude = value;

                _atc.ReceiveAircraftLocation(this);
            }
        }

        #region CONSTRUCTORS

        protected Aircraft(string callSign, IAirTrafficControl atc)
        {
            _atc = atc;
            CallSign = callSign;
            _atc.RegisterAircraftUnderGuidance(this);
        }

        #endregion

        public void Climb(int heightToClimb) => Altitude += heightToClimb;

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (GetType() != obj.GetType()) return false;

            return CallSign.Equals((obj as Aircraft)?.CallSign);
        }

        public override int GetHashCode() => CallSign.GetHashCode();

        public void WarnOfAirspaceIntrusionBy(Aircraft reportingAircraft)
        {
            Console.Out.WriteLine($"Aircraft {CallSign} replays: Roger! My current altitude is [{_currentAltitude}]");
        }
    }
}