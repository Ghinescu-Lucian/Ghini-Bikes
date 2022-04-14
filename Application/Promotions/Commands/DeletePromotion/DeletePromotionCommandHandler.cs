using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Promotions.Commands.DeletePromotion
{
    public class DeletePromotionCommandHandler : IRequestHandler<DeletePromotionCommand,PromoPackage>
    {
        private IPromotionRepository _promotionRepository;

        public DeletePromotionCommandHandler(IPromotionRepository repository)
        {
            _promotionRepository = repository;
        }

        public Task<PromoPackage> Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
        {

           var package= _promotionRepository.DeletePromotion(request.Id);
            return Task.FromResult(package);
        }
    }
}
