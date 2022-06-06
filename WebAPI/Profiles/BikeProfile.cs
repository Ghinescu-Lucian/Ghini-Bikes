using Application.Products.Bikes.Commands.CreateBikeCommand;
using Application.Products.Bikes.Commands.UpdateBikeCommand;
using AutoMapper;
using Domain.Products;
using WebAPI.Dtos;

namespace WebAPI.Profiles
{
    public class BikeProfile : Profile
    {
        public BikeProfile()
        {
            CreateMap<BikeDto, CreateBikeCommand>()
                .ForMember(b => b.Manufacturer, opt => opt.MapFrom(s => s.Manufacturer))
                .ForMember(b => b.Model, opt => opt.MapFrom(s => s.Model))
                .ForMember(b => b.Images, opt => opt.MapFrom(s => s.Images))
                .ForMember(b => b.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(b => b.Quantity, opt => opt.MapFrom(s => s.Quantity))
                .ForMember(b => b.Price, opt => opt.MapFrom(s => s.Price))
                .ForMember(b => b.Weight, opt => opt.MapFrom(s => s.Weight))
                .ForMember(b => b.WarrantyMonths, opt => opt.MapFrom(s => s.WarrantyMonths))
                .ReverseMap();

            CreateMap<BikeUpdateDto, Bike>()
                .ForMember(b => b.Manufacturer, opt => opt.MapFrom(s => s.Manufacturer))
                .ForMember(b => b.Model, opt => opt.MapFrom(s => s.Model))
                .ForMember(b => b.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(b => b.Quantity, opt => opt.MapFrom(s => s.Quantity))
                .ForMember(b => b.Price, opt => opt.MapFrom(s => s.Price))
                .ForMember(b => b.Weight, opt => opt.MapFrom(s => s.Weigth))
                .ForMember(b => b.WarrantyMonths, opt => opt.MapFrom(s => s.WarrantyMonths))
                .ReverseMap();

            CreateMap<BikeDto, Bike>()
                .ReverseMap();
        }
    }
}
