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
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            Database = unitOfWork;
        }

        public void CreateOrder(OrderDTO orderDTO)
        {
            if (orderDTO == null)
                throw new ArgumentNullException(nameof(orderDTO));
            if (orderDTO != null && Database.Orders.Get(orderDTO.Id) != null)
                throw new ArgumentOutOfRangeException("I Find Same Order!");
            Database.Orders.Create(Mapper.Map<OrderDTO, Order>(orderDTO));
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void EditOrder(OrderDTO orderDTO)
        {
            if (orderDTO == null)
                throw new ArgumentNullException(nameof(orderDTO));
            Order order = Database.Orders.Get(orderDTO.Id);

            if (order == null)
                throw new ArgumentOutOfRangeException("I cant find order:(");

            order.ClientName = orderDTO.ClientName;
            order.ClientPhone = orderDTO.ClientPhone;
            order.Comment = orderDTO.Comment;
            order.DateBeggin = orderDTO.DateBeggin;
            order.DateEnd = orderDTO.DateEnd;
            order.OrderDate = orderDTO.OrderDate;
        }

        public void RemuveOrder(OrderDTO orderDTO)
        {
            if (orderDTO == null)
                throw new ArgumentNullException(nameof(orderDTO));
            if (Database.Orders.Get(orderDTO.Id) == null)
                throw new ArgumentOutOfRangeException("Not found order");

            Database.Orders.Delete(orderDTO.Id);
            Database.Save();
        }
    }
}
