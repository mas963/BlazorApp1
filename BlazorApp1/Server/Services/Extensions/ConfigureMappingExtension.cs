using AutoMapper;
using BlazorApp1.Server.Data.Models;
using BlazorApp1.Shared.DTO;
using BlazorApp1.Shared.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorApp1.Server.Services.Extensions
{
    public static class ConfigureMappingExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AllowNullDestinationValues = true;
            AllowNullCollections = true;

            CreateMap<Supplier, SupplierDto>().ReverseMap();

            CreateMap<User, UserDto>();

            CreateMap<UserDto, User>().ForMember(x => x.Password, y => y.MapFrom(z => PasswordEncrypter.Encrypt(z.Password)));

            CreateMap<Order, OrderDto>()
                .ForMember(x => x.SupplierName, y => y.MapFrom(z => z.Supplier.Name))
                .ForMember(x => x.CreatedUserFullName, y => y.MapFrom(z => z.CreatedUser.FirstName + " " + z.CreatedUser.LastName));

            CreateMap<OrderDto, Order>();

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(x => x.CreatedUserFullName, y => y.MapFrom(z => z.CreatedUser.FirstName + " " + z.CreatedUser.LastName))
                .ForMember(x => x.OrderName, y => y.MapFrom(z => z.Order.Name == ""));

            CreateMap<OrderItemDto, OrderItem>();
        }
    }
}
