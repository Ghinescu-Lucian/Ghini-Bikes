using Domain.Models;
using MediatR;

namespace Application.Promotions.Commands.CreatePromotion
{
    public class CreatePromotionCommandHandler : IRequestHandler<CreatePromotionCommand, PromoPackage>
    {
        private IPromotionRepository _promotionRepository;
        private IBikeRepository _bikeRepository;
        private IAccessoryRepository _accessoryRepository;
        private IPartRepository _partRepository;

        public CreatePromotionCommandHandler(IPromotionRepository promotionRepository, IBikeRepository bikeRepository,
                                             IAccessoryRepository accessoryRepository, IPartRepository partRepository)
        {
            _promotionRepository = promotionRepository;
            _bikeRepository = bikeRepository;
            _accessoryRepository = accessoryRepository;
            _partRepository = partRepository;
        }

        public Task<PromoPackage> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
        {
            var package = new PromoPackage
            {
                Name = request.Name,
                // Items = request.Items
            };
            package.Items = new List<PromoItem>();
            if (request.Items != null)
            {
                foreach (var item in request.Items)
                {
                    if (item._Product.Category <= 3)
                    {
                        var bike = _bikeRepository.GetBikeById(item._Product.ProductId);
                        var promoItem = new PromoItem { _Product = bike, Quantity = item.Quantity, Discount = item.Discount, ProductId = bike.ProductId };
                        promoItem.ProductCategory = item._Product.Category;
                        package.Items.Add(promoItem);
                    }
                    else if (item._Product.Category == 4)
                    {
                        var part = _partRepository.GetPartById(item._Product.ProductId);
                        var promoItem = new PromoItem { _Product = part, Quantity = item.Quantity, Discount = item.Discount, ProductId = part.ProductId };
                        promoItem.ProductCategory = item._Product.Category;
                        package.Items.Add(promoItem);
                    }
                    else
                    {
                        var accessory = _accessoryRepository.GetAccessoryById(item._Product.ProductId);
                        var promoItem = new PromoItem { _Product = accessory, Quantity = item.Quantity, Discount = item.Discount , ProductId = accessory.ProductId };
                        promoItem.ProductCategory = item._Product.Category;
                        package.Items.Add(promoItem);
                    }
                }
            }
            package.Image = request.Image;
            _promotionRepository.CreatePromotion(package);
            return Task.FromResult(package);
        }
    }
}
