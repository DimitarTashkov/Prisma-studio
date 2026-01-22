using HotelOazis.DTOs.Room;
using HotelOazis.DTOs.Service;
using HotelOazis.Models;
using HotelOazis.Models.DbConfiguration;
using HotelOazis.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOazis.Services
{
    public class FacilityService : BaseService,IFacilityService
    {
        private readonly HotelContext context;
        public FacilityService(HotelContext context)
        {
            this.context = context;
        }
        public async Task<bool> AddServiceAsync(ServiceInputModel newService)
        {
            if (newService == null) return false;

            var service = new Service
            {
                Id = Guid.NewGuid(),
                Name = newService.Name,
                Description = newService.Description,

            };

            context.Services.Add(service);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteServiceAsync(Guid serviceId)
        {
            var service = await context.Services.FirstOrDefaultAsync(r => r.Id == serviceId);
            if (service != null)
            {
                context.Services.Remove(service);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> EditServiceAsync(EditServiceInputModel updatedService)
        {
            var service = await context.Services.FirstOrDefaultAsync(r => r.Id == updatedService.Id);
            if (service != null)
            {
                service.Name = updatedService.Name;
                service.Description = updatedService.Description;


                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<ServiceViewModel>> GetServicesAsync()
        {
            return await context.Services
           .Select(r => new ServiceViewModel
           {
               Id = r.Id,
               Name = r.Name,
               Description = r.Description
               
           })
           .AsNoTracking()
           .ToListAsync();
        }


    }
}
