using Boca.Bll.Services.TransactionServices.Abstract;
using Boca.Core.BaseEnums;
using Boca.Dal.Connected_Services.ExternalApiCalls.Payzee.Abstract;
using Boca.Dal.Connected_Services.ExternalApiCalls.Payzee.Concrete;
using Boca.Dal.Repositories.TransactionRepository.Abstract;
using Boca.Dtos.Payzee.Pay;
using Boca.Dtos.ResponseDtos;
using Boca.Dtos.TransactionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boca.Bll.Services.TransactionServices.Concrete
{
    public class TransactionService : ITransactionService
    {
        private readonly ILogin login;
        private readonly IPayment payment;
        private readonly ITransactionRepository transactionRepository;

        public TransactionService(ILogin login, IPayment payment, ITransactionRepository transactionRepository)
        {
            this.login = login;
            this.payment = payment;
            this.transactionRepository = transactionRepository;
        }

        
        public BaseResponseDto Pay(PayRequestDto dto)
        {
            try
            {
                //Token Al
                var token = login.PayzeeToken().Result;

                //Hash Üret
                dto.Hash = CreateHash(new VposRequestDto()
                {
                    ApiKey = dto.ApiKey,
                    TotalAmount = dto.TotalAmount,
                    CustomerId = dto.CustomerId,
                    UserCode = dto.UserCode,
                    OrderId = dto.OrderId,
                    Rnd = dto.Rnd,
                    TxnType = dto.TxnType
                });
                //Ödeme Yap
                var result = payment.Pay(dto, token).Result;

                var respMessageData = result.result;
                var respMessage = respMessageData.ToString();
                //Başarsa da fail olsa da kayıt at
                transactionRepository.Insert(new Entities.TransactionEntity()
                {
                    Amount = Convert.ToDecimal(dto.TotalAmount),
                    CreatedAt = DateTime.UtcNow,
                    CardPan = dto.CardNumber,
                    CustomerId=dto.CustomerId,
                    IsDeleted=false,
                    ResponseCode = Convert.ToInt32(result.statusCode),
                    ResponseMessage = respMessage,
                    OrderId=dto.OrderId,
                    TransactionId ="1",
                    UpdatedAt = DateTime.UtcNow,
                    StatusId = "1",
                    TypeId=TypeIdEnum.Sale                    
                });

                if (result.result.responseCode != "00")
                {
                    return new BaseResponseDto { Message = "Error", StatusCode = result.statusCode };
                }
                else
                {
                    return new BaseResponseDto { Message = "Success", StatusCode = 200 };
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public BaseResponseWithDataDto<List<GetTransactionDto>> GetTransactions()
        {
            try
            {               
                var list = new List<GetTransactionDto>();

                var data = transactionRepository.GetEntities();

                if(data != null)
                {
                    foreach (var x in data)
                    {
                        list.Add(new GetTransactionDto
                        {
                            Amount = Convert.ToDecimal(x.Amount),
                            CardPan = x.CardPan,
                            CustomerId = x.CustomerId,
                            ResponseCode = x.ResponseCode,
                            OrderId = x.OrderId,
                            ResponseMessage = x.ResponseMessage,
                            TransactionId = x.TransactionId,
                            TypeId = (int)x.TypeId
                        });
                    }
                }

                return new BaseResponseWithDataDto<List<GetTransactionDto>>
                {
                    Data = list,
                    StatusCode = 200,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        #region Helper
        public string CreateHash(VposRequestDto request)
        {

            var apiKey = request.ApiKey; // Bu bilgi size özel olup kayıtlı kullanıcınıza mail olarak gönderilmiştir.

            var hashString = $"{apiKey}{request.UserCode}{request.Rnd}{request.TxnType}{request.TotalAmount}{request.CustomerId}{request.OrderId}";

            System.Security.Cryptography.SHA512 s512 = System.Security.Cryptography.SHA512.Create();

            System.Text.UnicodeEncoding ByteConverter = new System.Text.UnicodeEncoding();

            byte[] bytes = s512.ComputeHash(ByteConverter.GetBytes(hashString));

            var hash = System.BitConverter.ToString(bytes).Replace("-", "");

            return hash;

        }
        #endregion

    }
}
