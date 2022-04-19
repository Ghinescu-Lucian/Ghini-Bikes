﻿using Domain.Enums;
using Domain.Models;
using Domain.Orders;

namespace WebAPI.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public List<OrderItem> Items { get; set; }

        public DateTime Date { get; set; }
        public double TotalCost { get; set; }
        public double FinalCost { get; set; }
        public User User { get; set; }

        public string TelephoneNr { get; set; }
        public string Address { get; set; }

        public Payment? Pay { get; set; }

        public Status? Status { get; set; }

        public ShippingCostContext ShippingCost;
    }
}
