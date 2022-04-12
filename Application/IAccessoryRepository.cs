﻿using Domain.Bikes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IAccessoryRepository 
    {
        void CreateAccessory(Accessory accessory);
        IEnumerable<Product> GetAccessories();
        void DeleteAccessory(Accessory accessory);
        Product GetAccessoryById(int accessoryId);
        void UpdateAccessory(int accessoryId, Accessory accessory);
    }
}
