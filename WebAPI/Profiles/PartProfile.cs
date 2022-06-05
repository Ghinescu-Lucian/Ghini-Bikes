using Application.Products.Parts.Commands.CreatePartCommand;
using AutoMapper;
using Domain.Products;
using WebAPI.Dtos;

namespace WebAPI.Profiles
{
    public class PartProfile : Profile
    {
        public PartProfile()
        {
            CreateMap<PartDto, CreatePartCommand>()
                 .ForMember(b => b.Manufacturer, opt => opt.MapFrom(s => s.Manufacturer))
                 .ForMember(b => b.Model, opt => opt.MapFrom(s => s.Model))
                 .ForMember(b => b.Images, opt => opt.MapFrom(s => s.Images))
                 .ForMember(b => b.Description, opt => opt.MapFrom(s => s.Description))
                 .ForMember(b => b.Quantity, opt => opt.MapFrom(s => s.Quantity))
                 .ForMember(b => b.Price, opt => opt.MapFrom(s => s.Price))
                 .ForMember(b => b.Compatibilities, opt => opt.MapFrom(s => s.Compatibilities))
                 .ReverseMap();
            CreateMap<UpdatePartDTO, CreatePartCommand>()
                .ForMember(b => b.Manufacturer, opt => opt.MapFrom(s => s.Manufacturer))
                .ForMember(b => b.Model, opt => opt.MapFrom(s => s.Model))
                .ForMember(b => b.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(b => b.Quantity, opt => opt.MapFrom(s => s.Quantity))
                .ForMember(b => b.Price, opt => opt.MapFrom(s => s.Price))
                .ReverseMap();

            CreateMap<PartDto, Part>()
                .ReverseMap();
            CreateMap<UpdatePartDTO, Part>()
                .ReverseMap();
        }
    }
}
