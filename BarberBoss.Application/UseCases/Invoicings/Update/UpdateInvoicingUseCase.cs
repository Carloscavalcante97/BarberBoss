using AutoMapper;
using BarberBoss.Communication.Request;
using BarberBoss.Domain.Repositories;
using BarberBoss.Domain.Repositories.Invoicings;
using BarberBoss.Exception;
using BarberBoss.Exception.ExceptionBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberBoss.Application.UseCases.Invoicings.Update
{
    public class UpdateInvoicingUseCase : IUpdateInvoicingUseCase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvoicingUpdateOnlyRepository _repository;

        public UpdateInvoicingUseCase(IMapper mapper, IUnitOfWork unitOfWork, IInvoicingUpdateOnlyRepository repository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public async Task Execute(long id, RequestInvoicingJson request)
        {
            Validate(request);
            var invoicing = await _repository.GetById(id);
            if (invoicing is null)
            {
                throw new NotFoundException(ResourceErrorMessages.INVOICING_NOT_FOUND);
            }
            invoicing = _mapper.Map(request, invoicing);
            _repository.Update(invoicing);
            await _unitOfWork.Commit();
        }
        private void Validate(RequestInvoicingJson request)
        {
            var Validator = new InvoicingValidator();
            var result = Validator.Validate(request);
            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
