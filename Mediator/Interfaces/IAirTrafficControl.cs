namespace Mediator.Interfaces
{
    using Models;

    public interface IAirTrafficControl
    {
        void ReceiveAircraftLocation(Aircraft location);
        void RegisterAircraftUnderGuidance(Aircraft aircraft);
    }
}