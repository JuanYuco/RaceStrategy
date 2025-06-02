using RaceStrategy.Application.DTOs.Driver;
using RaceStrategy.Application.Interfaces;
using RaceStrategy.Domain.Ports;

namespace RaceStrategy.Application.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            this._driverRepository = driverRepository;
        }

        /// <summary>
        /// Método que consulta los pilotos en BD utilizando el respositorio
        /// </summary>
        /// <param name="request">el request viene vacío en este caso</param>
        public async Task<DriverCollectionResponseDTO> GetAll(DriverRequestDTO request)
        {
            var result = new DriverCollectionResponseDTO() { Successful = false };
            try
            {
                List<DriverDTO> driverDTOCollection = new List<DriverDTO>();
                var driverCollection = await _driverRepository.GetAll();
                if (driverCollection != null && driverCollection.Count > 0)
                {
                    foreach (var driver in driverCollection)
                    {
                        driverDTOCollection.Add(new DriverDTO()
                        {
                            Id = driver.Id,
                            Name = driver.Name
                        });
                    }
                }

                result.EntityCollection = driverDTOCollection;
                result.Successful = true;
            } catch(Exception ex)
            {
                result.UserMessage = "Ocurrió un error consultando los pilotos, por favor intente más tarde.";
                result.InternalErrorMessage = ex.Message;
                result.HttpCode = 500;
            }

            return result;
        }
    }
}
