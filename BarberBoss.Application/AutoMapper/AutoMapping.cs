using BarberBoss.Communication.Request;
using BarberBoss.Domain.Entities;
using AutoMapper;
using BarberBoss.Communication.Responses;
namespace BarberBoss.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping() {
           RequestToEntity();
            EntityToResponse();
        }   
        private void RequestToEntity()
        {
            CreateMap<RequestInvoicingJson,Invoicing>();
        }
        private void EntityToResponse()
        {
            CreateMap<Invoicing, ResponseInvoicingJson>();
        }
    }
}
