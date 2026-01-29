using Core_HomeService.Domain.Core._common;
using Core_HomeService.Domain.Core.UserAgg.Contracts.AppServiceContracts.CustomerContract;
using Core_HomeService.Domain.Core.UserAgg.Contracts.ServiceContracts.CustomerContract;
using Core_HomeService.Domain.Core.UserAgg.Contracts.ServiceContracts.ApplicationUserContract;
using Core_HomeService.Domain.Core.UserAgg.DTOs.CustomerDTOs;
using Core_HomeService.Domain.Core.UserAgg.DTOs.UserDTOs;

namespace AppService_HomeService.Domain.AppService.AppServices
{
    public class CustomerAppService(ICustomerService customerService, IApplicationUserService applicationUserService) : ICustomerAppService
    {
        public async Task<Result<CustomerDto?>> GetById(int id, CancellationToken cancellationToken)
        {
            var customer = await customerService.GetById(id, cancellationToken);
            if (customer == null)
                return Result<CustomerDto?>.Failure("مشتری یافت نشد.");

            return Result<CustomerDto?>.Success("مشتری دریافت شد.", customer);
        }

        public async Task<Result<PaginationResult<CustomerDto>>> GetAllPaged(int page, int pageSize, CancellationToken cancellationToken)
        {
            var result = await customerService.GetAllPaged(page, pageSize, cancellationToken);
            return Result<PaginationResult<CustomerDto>>.Success("لیست مشتریان دریافت شد.", result);
        }

        public async Task<Result<bool>> Update(int id, CustomerUpdateDto customerDto, ApplicationUserUpdateDto userDto, CancellationToken cancellationToken)
        {
            
            var customerUpdated = await customerService.Update(id, customerDto, cancellationToken);
            if (!customerUpdated)
                return Result<bool>.Failure("بروزرسانی اطلاعات مشتری ناموفق بود.");


            var userUpdated = await applicationUserService.Update(id, userDto, cancellationToken);
            if (!userUpdated)
                return Result<bool>.Failure("بروزرسانی اطلاعات کاربری ناموفق بود.");

            return Result<bool>.Success("اطلاعات مشتری با موفقیت بروزرسانی شد.", true);
        }

        public async Task<Result<bool>> Delete(int id, CancellationToken cancellationToken)
        {
            var ok = await customerService.Delete(id, cancellationToken);
            if (!ok)
                return Result<bool>.Failure("حذف مشتری ناموفق بود.");

            return Result<bool>.Success("مشتری حذف شد.", true);
        }
    }
}
