namespace Mediator.Models
{
    using Interfaces;

    public class Airbus321 : Aircraft
    {
        public override int Ceiling => 41000;

        #region CONSTRUCTORS

        public Airbus321(string callSign, IAirTrafficControl atc) : base(callSign, atc) { }

        #endregion
    }
}