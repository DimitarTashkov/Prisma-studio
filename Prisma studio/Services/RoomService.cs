using HotelOazis.DTOs.Room;
using HotelOazis.Models.DbConfiguration;
using HotelOazis.Models;
using HotelOazis.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using HotelOazis.Services;
using HotelOazis.DTOs.Reservation;

public class RoomService : BaseService, IRoomService
{
    private readonly HotelContext context;
    private readonly IUserService userService;

    public RoomService(HotelContext context, IUserService userService)
    {
        this.context = context;
        this.userService = userService;
    }

    public async Task<List<RoomViewModel>> GetRoomsAsync()
    {
        return await context.Rooms
            .Select(r => new RoomViewModel
            {
                Id = r.Id,
                RoomNumber = r.Number,
                Type = r.Type,
                IsAvailable = r.IsAvailable,
                PictureLocation = r.Picture,
                Price = r.Price,
                Description = r.Description,
            })
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> ReserveRoomAsync(ReservationInputModel reservationModel)
    {
        if (reservationModel == null) return false;

        var reservationExists = await context.Reservations.AnyAsync(r =>
            r.RoomId == reservationModel.RoomId &&
            ((r.CheckInDate <= reservationModel.CheckOutDate && r.CheckInDate >= reservationModel.CheckInDate) ||
             (r.CheckOutDate >= reservationModel.CheckInDate && r.CheckOutDate <= reservationModel.CheckOutDate)));

        if (!reservationExists)
        {
            var reservation = new Reservation
            {
                Id = Guid.NewGuid(),
                UserId = reservationModel.UserId,
                RoomId = reservationModel.RoomId,
                CheckInDate = reservationModel.CheckInDate,
                CheckOutDate = reservationModel.CheckOutDate
            };

            context.Reservations.Add(reservation);
            await context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<bool> DeleteRoomAsync(Guid roomId)
    {
        var room = await context.Rooms.FirstOrDefaultAsync(r => r.Id == roomId);
        if (room != null)
        {
            context.Rooms.Remove(room);
            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> AddRoomAsync(RoomInputModel newRoom)
    {
        if (newRoom == null) return false;

        var room = new Room
        {
            Id = Guid.NewGuid(),
            Number = newRoom.RoomNumber,
            Type = newRoom.Type,
            Price = newRoom.Price,
            Picture = newRoom.PictureLocation,
            Description = newRoom.Description,
            IsAvailable = true,
        };

        context.Rooms.Add(room);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> EditRoomAsync(EditRoomInputModel updatedRoom)
    {
        var room = await context.Rooms.FirstOrDefaultAsync(r => r.Id == updatedRoom.Id);
        if (room != null)
        {
            room.Type = updatedRoom.Type;
            room.Number = updatedRoom.RoomNumber;
            room.IsAvailable = updatedRoom.IsAvailable;
            room.Picture = updatedRoom.PictureLocation;
            room.Price = updatedRoom.Price;
            room.Description = updatedRoom.Description;

            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }
    public async Task<bool> IsRoomNumberUnique(int roomNumber)
    {

        return !context.Rooms.Any(r => r.Number == roomNumber);
    }
    public async Task<int> GenerateUniqueRoomNumber()
    {
        int newRoomNumber = 1;

        while (!await IsRoomNumberUnique(newRoomNumber))
        {
            newRoomNumber++;
        }

        return newRoomNumber;
    }
    public async Task<List<ReservationsViewModel>> GetReservationsAsync()
    {
        User loggedInUser = userService.GetLoggedInUserAsync();
        if (loggedInUser == null)
        {
            throw new InvalidOperationException("No user is currently logged in.");
        }

        bool isAdmin = await userService.IsUserAdminAsync(loggedInUser.Id);

        var query = isAdmin
            ? context.Reservations.Include(r => r.User).Include(r => r.Room) 
            : context.Reservations.Include(r => r.User).Include(r => r.Room).Where(r => r.UserId == loggedInUser.Id);

        var reservations = await query.Select(r => new ReservationsViewModel
        {
            Id = r.Id,
            Username = r.User.Username,
            PictureLocation = r.User.AvatarUrl,
            RoomNumber = r.Room.Number,
            RoomType = r.Room.Type,
            PricePerNight = r.Room.Price,
            TotalPrice = r.Room.Price * (r.CheckOutDate - r.CheckInDate).Days,
            CheckInDate = r.CheckInDate,
            CheckOutDate = r.CheckOutDate
        }).ToListAsync();

        return reservations;
    }
    public async Task<bool> CancelReservationAsync(Guid reservationId)
    {

        var reservation = await context.Reservations.FirstOrDefaultAsync(r => r.Id == reservationId);
        if (reservation == null)
        {
            return false; 
        }

        context.Reservations.Remove(reservation);
        await context.SaveChangesAsync();

        return true; 

    }
    public async Task<bool> IsRoomReservedBetweenDatesAsync(Guid roomId, DateTime startDate, DateTime endDate)
    {
        return await context.Reservations
            .AnyAsync(r => r.RoomId == roomId &&
                          !(r.CheckOutDate <= startDate || r.CheckInDate >= endDate));
    }
}