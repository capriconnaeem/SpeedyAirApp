using SpeedyAir.Entities.Common;
using SpeedyAir.Entities.Flight;

namespace SpeedyAir.BusinessLogic.Area.Services
{
    /// <summary>
    /// Interface for managing flights and scheduling orders.
    /// </summary>
    public interface IFlightService
    {
        Task<BusinessResultWithData<IEnumerable<Flight>>> GetFlightsInformation();
    }
}
