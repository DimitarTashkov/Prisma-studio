using HotelOazis.DTOs.Room;
using HotelOazis.DTOs.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOazis.Services.Interfaces
{
    public interface IFacilityService : IValidateModel
    {
        Task<List<ServiceViewModel>> GetServicesAsync();
        Task<bool> DeleteServiceAsync(Guid serviceId);

        Task<bool> AddServiceAsync(ServiceInputModel newService);

        Task<bool> EditServiceAsync(EditServiceInputModel updatedService);
    }
}
