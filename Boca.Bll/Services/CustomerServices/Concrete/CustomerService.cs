using Boca.Bll.Services.CustomerServices.Abstract;
using Boca.Dal.Repositories.CustomerRepository.Abstract;
using Boca.Dal.Repositories.KpsRepository.Abstract;
using Boca.Dtos.Customer;
using Boca.Dtos.EnumDtos;
using Boca.Dtos.Kps;
using Boca.Dtos.ResponseDtos;
using Boca.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Bll.Services.CustomerServices.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IKpsRepository kpsRepository;

        public CustomerService(ICustomerRepository customerRepository, IKpsRepository kpsRepository)
        {
            this.customerRepository = customerRepository;
            this.kpsRepository = kpsRepository;
        }

        public BaseResponseDto InsertCustomer(InsertCustomerDto dto)
        {
            try
            {
                //check the customer from db
                var isExist = GetCustomerEntityByTckn(dto.IdentityNo);
                if (isExist != null)
                    return new BaseResponseDto() { StatusCode = 409, Message = CustomerErrorEnum.E409.ToString() };

                customerRepository.Insert(new CustomerEntity
                {
                    CreatedAt = DateTime.UtcNow,
                    CustomerId = new Random().Next(10000, 99999).ToString(),
                    BirthDate = dto.BirthDate,
                    IdentityNo = dto.IdentityNo,
                    IdentityVerified = false,
                    IsDeleted = false,
                    Surname = dto.Surname,
                    Name = dto.Name,
                    StatusId = "1",
                    UpdatedAt = DateTime.MinValue
                });

                return new BaseResponseDto()
                {
                    StatusCode = 200,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public BaseResponseWithDataDto<GetCustomerDto> GetCustomerByTc(long tcNo)
        {
            try
            {
                var data = GetCustomerEntityByTckn(tcNo);

                if (data is null)
                {
                    return new BaseResponseWithDataDto<GetCustomerDto>() { StatusCode = 404, Message = CustomerErrorEnum.E404.ToString() };
                }

                return new BaseResponseWithDataDto<GetCustomerDto>()
                {
                    Data = new GetCustomerDto
                    {
                        Id = data.Id,
                        Name = data.Name,
                        Surname = data.Surname,
                        BirhDate = data.BirthDate,
                        IdentityNo = data.IdentityNo,
                        IdentityVerified = data.IdentityVerified
                    },
                    Message = "Success",
                    StatusCode = 200
                };

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public BaseResponseDto VerifyTckn(VerifyTcknDto dto)
        {
            try
            {
                //get customer
                var customer = GetCustomerEntityByTckn(dto.Tckn);
                if (customer is null)
                    return new BaseResponseDto { StatusCode = 404, Message = CustomerErrorEnum.E404.ToString() };

                //verify tckn
                var isVerified = kpsRepository.CheckTckn(dto.Tckn, dto.Name, dto.Surname, dto.BirthYear);
                if (isVerified)
                {
                    customer.IdentityVerified = true;
                    customer.UpdatedAt = DateTime.Now;
                    //update customer
                    customerRepository.Update(customer);

                    return new BaseResponseDto() { StatusCode = 200, Message = "Success" };
                }
                else
                {
                    return new BaseResponseDto { StatusCode = 304, Message = CustomerErrorEnum.E304.ToString() };
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        #region Helpers
        private CustomerEntity GetCustomerEntityByTckn(long tckn)
        {
            var customer = customerRepository.GetEntityByExpression(x => x.IdentityNo == tckn && x.IsDeleted == false);
            return customer;
        }
        #endregion
    }
}
