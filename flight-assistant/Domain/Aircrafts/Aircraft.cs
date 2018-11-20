using Domain.Common;

namespace Domain.Aircrafts
{
    public class Aircraft : IEntity
    {
        public int Id { get; set; }

        public string ModelName { get; set; }

        public double ConsumptionOnTakeOff { get; set; }

        public double ConsumptionPerKm { get; set; }
    }
}   