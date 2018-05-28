using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
    public class AMConfig
    {
        public static void Configure(IMapperConfigurationExpression config)
        {
            config.CreateMap<Room, RoomDTO>();
            config.CreateMap<Order, OrderDTO>();

        }
    }
}
