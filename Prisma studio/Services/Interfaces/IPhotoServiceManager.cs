using Prisma_studio.Data.Models;
using Prisma_studio.Data.Models;
using System;
using System.Collections.Generic;

namespace Prisma_studio.Services.Interfaces
{
    public interface IPhotoServiceManager
    {
        List<PhotoService> GetAllServices();
        PhotoService GetServiceById(Guid id); // int -> Guid
        void CreateService(string name, string description, decimal price, int durationMinutes, string imageUrl);
        void EditService(Guid id, string name, string description, decimal price, int durationMinutes, string imageUrl); // int -> Guid
        void DeleteService(Guid id);
        void AddService(PhotoService service);
        void UpdateService(PhotoService service);
    }
}