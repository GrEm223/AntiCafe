using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Interfaces;
using DAL.Entities;
using AutoMapper;

namespace BLL.Services
{
    public class RoomService : IRoomService
    {
        IUnitOfWork Database { get; set; }

        public RoomService (IUnitOfWork unitOfWork)
        {   
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            Database = unitOfWork;
        }
        public void CreateRoom(RoomDTO roomDTO)
        {
            if (roomDTO == null)
                throw new ArgumentNullException(nameof(roomDTO));
            if (roomDTO != null && Database.Rooms.Get(roomDTO.Id) != null)
                throw new ArgumentOutOfRangeException("I Find Same Room!");
            Database.Rooms.Create(Mapper.Map<RoomDTO, Room>(roomDTO));
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void EditRoom(RoomDTO roomDTO)
        {
            if (roomDTO == null)
                throw new ArgumentNullException(nameof(roomDTO));
            Room room = Database.Rooms.Get(roomDTO.Id);

            if (room == null)
               throw new ArgumentOutOfRangeException("I cant find room:(");

            room.Name = roomDTO.Name;
            room.Description = roomDTO.Description;

        }

        public void RemoveRoom(RoomDTO roomDTO)
        {
            if (roomDTO == null)
                throw new ArgumentNullException(nameof(roomDTO));
            if (Database.Rooms.Get(roomDTO.Id) == null)
                throw new ArgumentOutOfRangeException("Not found resume");

            Database.Rooms.Delete(roomDTO.Id);
            Database.Save();
        }
    }
}
