﻿using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(OrderDTO orderDTO);
        void EditOrder(OrderDTO orderDTO);
        void RemuveOrder(OrderDTO orderDTO);
        void Dispose();
    }
}
