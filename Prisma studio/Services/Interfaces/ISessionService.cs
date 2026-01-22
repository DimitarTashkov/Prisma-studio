using Prisma_studio.Data.Models;
using Prisma_studio.Data.Models;
using System;
using System.Collections.Generic;

namespace Prisma_studio.Services.Interfaces
{
    public interface ISessionService
    {
        bool BookSession(Guid userId, Guid serviceId, DateTime date, TimeSpan time, string notes); // serviceId -> Guid
        List<PhotoSession> GetUserSessions(Guid userId);
        List<TimeSpan> GetAvailableSlots(DateTime date, int serviceDurationMinutes);
        List<PhotoSession> GetAllUpcomingSessions();
        void CancelSession(Guid sessionId); // sessionId -> Guid
    }
}