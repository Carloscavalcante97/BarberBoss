using AutoMapper;
using BarberBoss.Communication.Request;
using BarberBoss.Communication.Responses;
using BarberBoss.Domain.Entities;
using BarberBoss.Domain.Repositories;
using BarberBoss.Domain.Repositories.Invoicings;
using BarberBoss.Exception.ExceptionBase;
using System.ComponentModel.DataAnnotations;

namespace BarberBoss.Application.UseCases.Invoicings.Register
{
    public class RegisterInvoicingUseCase : IRegisterInvoicingUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvoicingWriteOnlyRepository _repository;
        private readonly IMapper _mapper;
        public RegisterInvoicingUseCase(IUnitOfWork unitOfWork, IInvoicingWriteOnlyRepository repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ResponseInvoicingJson> Execute(RequestInvoicingJson request)
        {
            validate(request);
            var entity = _mapper.Map<Invoicing>(request);
            await _repository.Add(entity);
            await _unitOfWork.Commit();
            return _mapper.Map<ResponseInvoicingJson>(entity);
        }
        private void validate(RequestInvoicingJson request)
        {
            var validator = new InvoicingValidator();
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                var errorMessage = result.Errors.Select(error => error.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessage);
            }
        }
    }
}
