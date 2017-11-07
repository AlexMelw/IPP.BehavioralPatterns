namespace Mediator.Models
{
    using Interfaces;

    public class Boeing737200 : Aircraft
    {
        public override int Ceiling => 35000;

        #region CONSTRUCTORS

        public Boeing737200(string callSign, IAirTrafficControl atc) : base(callSign, atc) { }

        #endregion
    }
}