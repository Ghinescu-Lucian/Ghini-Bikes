using Application.Promotions.Commands.CreatePromotion;
using AutoMapper;
using Domain.Models;
using WebAPI.Dtos;

namespace WebAPI.Profiles
{
    public class PromotionProfile : Profile
    {
        public PromotionProfile()
        {
            CreateMap<PromotionDto, PromoPackage>()
               .ReverseMap(); 
            CreateMap<PromotionDto, CreatePromotionCommand>()
                .ReverseMap();
        }
    }
}
