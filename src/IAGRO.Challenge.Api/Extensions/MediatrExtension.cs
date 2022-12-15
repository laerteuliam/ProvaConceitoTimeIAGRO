using IAGRO.Challenge.Domain.Catalog.Handlers;
using IAGRO.Challenge.Domain.Shipping.Handlers;
using MediatR;
namespace IAGRO.Challenge.Api.Extensions
{
    public static class MediatrExtension
    {
        public static void AddMediatRApi(this IServiceCollection services)
        {
            services.AddMediatR(typeof(BookQueryHandler));
            services.AddMediatR(typeof(ShippingQueryHandler));
        }
    }
}
