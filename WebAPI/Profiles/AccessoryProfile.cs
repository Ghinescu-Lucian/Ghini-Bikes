using Application.Products.Accessories.Commands.CreateAccessoryCommand;
using AutoMapper;
using Domain.Products;
using WebAPI.Dtos;

namespace WebAPI.Profiles
{
    public class AccessoryProfile : Profile
    {
        public AccessoryProfile()
        {
            CreateMap<AccessoryDto, CreateAccessoryCommand>()
                 .ForMember(b => b.Manufacturer, opt => opt.MapFrom(s => s.Manufacturer))
                 .ForMember(b => b.Model, opt => opt.MapFrom(s => s.Model))
                 .ForMember(b => b.Images, opt => opt.MapFrom(s => s.Images))
                 .ForMember(b => b.Description, opt => opt.MapFrom(s => s.Description))
                 .ForMember(b => b.Quantity, opt => opt.MapFrom(s => s.Quantity))
                 .ForMember(b => b.Price, opt => opt.MapFrom(s => s.Price))
                 .ReverseMap();

            CreateMap<UpdateAccessoryDTO, CreateAccessoryCommand>()
                .ForMember(b => b.Manufacturer, opt => opt.MapFrom(s => s.Manufacturer))
                .ForMember(b => b.Model, opt => opt.MapFrom(s => s.Model))
                .ForMember(b => b.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(b => b.Quantity, opt => opt.MapFrom(s => s.Quantity))
                .ForMember(b => b.Price, opt => opt.MapFrom(s => s.Price))
                .ReverseMap(); 

            CreateMap<AccessoryDto, Accessory>()
                .ReverseMap();
            CreateMap<UpdateAccessoryDTO, Accessory>()
                .ReverseMap();
        }
    }

}
