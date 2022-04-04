﻿using Domain.Bikes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Accessories.Commands.DeleteAccessoryCommand
{
    public class DeleteAccessoryCommandHandler : IRequestHandler<DeleteAccessoryCommand, Accessory>
    {
        private readonly IAccessoryRepository _repository;

        public DeleteAccessoryCommandHandler(IAccessoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Accessory> Handle(DeleteAccessoryCommand request, CancellationToken cancellationToken)
        {
            var accessory = new Accessory()
            {
                Manufacturer = request.Manufacturer,
                Model = request.Model,
                Year = request.Year,
            };

            _repository.DeleteAccessory(accessory);

            return accessory;

        }

       
    }
}
