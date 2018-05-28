using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
   public interface IRoomService
    {
        void CreateRoom(RoomDTO roomDTO);
        void EditRoom(RoomDTO roomDTO);
        void RemoveRoom(RoomDTO roomDTO);
        void Dispose();
    }
}
