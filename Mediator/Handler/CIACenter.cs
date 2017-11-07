namespace Mediator.Handler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Models;

    public class CIACenter : IAirTrafficControl
    {
        private readonly IList<Aircraft> _aircraftUnderGuidance = new List<Aircraft>();

        #region Implement IAirTrafficControl

        public void ReceiveAircraftLocation(Aircraft reportingAircraft)
        {
            foreach (var currentAircraftUnderGuidance in _aircraftUnderGuidance.Where(x => x != reportingAircraft))
            {
                if (Math.Abs(currentAircraftUnderGuidance.Altitude - reportingAircraft.Altitude) < 1000)
                {
                    Console.Out.WriteLine("Air Conflict Detected!");

                    reportingAircraft.Climb(1000);

                    currentAircraftUnderGuidance.WarnOfAirspaceIntrusionBy(reportingAircraft);
                }
            }
        }

        public void RegisterAircraftUnderGuidance(Aircraft aircraft)
        {
            if (!_aircraftUnderGuidance.Contains(aircraft))
            {
                _aircraftUnderGuidance.Add(aircraft);
            }
        }

        #endregion
    }
}