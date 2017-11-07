namespace Mediator.Models
{
    using Interfaces;

    public class Embraer190 : Aircraft
    {
        public override int Ceiling => 41000;

        #region CONSTRUCTORS

        public Embraer190(string callSign, IAirTrafficControl atc) : base(callSign, atc) { }

        #endregion
    }
}