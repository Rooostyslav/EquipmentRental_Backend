using EquipmentRental.DAL.EF;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using EquipmentRental.DAL.UnitOfWork;
using EquipmentRental.BLL.Services;
using EquipmentRental.BLL.Services.Implementation;
using AutoMapper;

namespace EquipmentRental.BLL.Infrastructure
{
	public static class ProviderExtensions
	{
		public static void AddContext(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<EquipmentRentalContext>(options =>
				options.UseSqlServer(connectionString),
				ServiceLifetime.Transient);
		}

		public static void AddAutoMapper(this IServiceCollection services)
		{
			var mapperConfig = new MapperConfiguration(config =>
			{
				config.AddProfile(new MappingProfile());
			});

			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);
		}

		public static void AddServices(this IServiceCollection services)
		{
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			services.AddScoped<IEquipmentService, EquipmentService>();
			services.AddScoped<IOrderService, OrderService>();
			services.AddScoped<IPaymentService, PaymentService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IRoleService, RoleService>();
		}
	}
}
