using AutoMapper;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Repositories.Invoicings;

namespace BarberBoss.Application.UseCases.Invoicings.Get
{
    public class GetInvoicingUseCase : IGetInvoicingUseCase
    {
        private readonly IInvoicingReadOnlyRepository _repository;
        private readonly IMapper _mapper;
        public GetInvoicingUseCase(IInvoicingReadOnlyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<RequestInvoicingsJson> Execute()
        {
            var result = await _repository.Get();
            return new RequestInvoicingsJson
            {
                Invoicings = _mapper.Map<List<ResponseShortInvoicingJson>>(result)
            };
        }
    }
}
