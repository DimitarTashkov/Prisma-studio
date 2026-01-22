using HotelOazis.DTOs.Reservation;
using HotelOazis.DTOs.Room;
using HotelOazis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOazis.Services.Interfaces
{
    public interface IRoomService : IValidateModel
    {
        Task<List<RoomViewModel>> GetRoomsAsync();

        Task<bool> ReserveRoomAsync(ReservationInputModel reservationModel);

        Task<bool> DeleteRoomAsync(Guid roomId);

        Task<bool> AddRoomAsync(RoomInputModel newRoom);

        Task<bool> EditRoomAsync(EditRoomInputModel updatedRoom);
        public Task<bool> IsRoomNumberUnique(int roomNumber);
        public Task<int> GenerateUniqueRoomNumber();
        public Task<List<ReservationsViewModel>> GetReservationsAsync();
        public Task<bool> CancelReservationAsync(Guid reservationId);
        public Task<bool> IsRoomReservedBetweenDatesAsync(Guid roomId, DateTime startDate, DateTime endDate);


    }
}
