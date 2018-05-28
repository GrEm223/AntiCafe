using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
   public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime DateBeggin { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime OrderDate { get; set; }
        public string ClientName { get; set; }
        public int ClientPhone { get; set; }
        public string Comment { get; set; }

        public int? RoomId { get; set; }
        public virtual RoomDTO Room { get; set; }
    }
}
