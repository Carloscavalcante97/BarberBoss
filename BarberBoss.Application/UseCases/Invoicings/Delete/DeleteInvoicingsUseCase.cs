using AutoMapper;
using BarberBoss.Domain.Repositories;
using BarberBoss.Domain.Repositories.Invoicings;
using BarberBoss.Exception;
using BarberBoss.Exception.ExceptionBase;

namespace BarberBoss.Application.UseCases.Invoicings.Delete
{
    public class DeleteInvoicingsUseCase : IDeleteInvoicingsUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvoicingWriteOnlyRepository _repository;
      
        public DeleteInvoicingsUseCase(IUnitOfWork unitOfWork, IInvoicingWriteOnlyRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task Execute(long id)
        {
            var result = await _repository.Delete(id);
            if(result is false)
            {
                throw new NotFoundException(ResourceErrorMessages.INVOICING_NOT_FOUND);
            }
            await _unitOfWork.Commit();
        }
    }
}
