using Microsoft.Extensions.DependencyInjection;
using ShopsRU.Application.Interfaces.Services;
using ShopsRU.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Wrappers
{
    public class ServiceDataResponse<T> : ServiceResponse
    {
        public T Payload { get; set; }
        public static ServiceDataResponse<T> CreateServiceResponse(IResourceService resourceService, T payload, ResponseMessages responseMessage)
        {
            var serviceResponse = new ServiceDataResponse<T>
            {
                Payload = payload
            };
            var key = Enum.GetName(typeof(ResponseMessages), responseMessage);
            if (key != null)
            {
                serviceResponse.Message = resourceService.GetResource(key);
            }
            SetResponseDetails(serviceResponse, responseMessage);
            return serviceResponse;
        }
        public static int GetStatusCode(ResponseMessages responseMessages)
        {
            return responseMessages switch
            {
                ResponseMessages.OPERATION_SUCCESS => 200,
                ResponseMessages.DATA_RETRIEVED_SUCCESSFULLY => 200,
                ResponseMessages.ALREADY_EXISTS => 409,
                ResponseMessages.ORDER_ITEM_NOT_FOUND => 404,
                ResponseMessages.OPERATION_FAILED => 500,
                ResponseMessages.DATA_NOT_FOUND => 404,
                _ => 500,
            };
        }
        private static void SetResponseDetails(ServiceDataResponse<T> response, ResponseMessages responseMessage)
        {

            response.StatusCode = GetStatusCode(responseMessage);
            switch (responseMessage)
            {
                case ResponseMessages.OPERATION_SUCCESS:
                    response.Success = true;
                    break;
                case ResponseMessages.DATA_RETRIEVED_SUCCESSFULLY:
                    response.Success = true;
                    break;
                case ResponseMessages.ALREADY_EXISTS:
                    response.Success = true;
                    break;

                case ResponseMessages.ORDER_ITEM_NOT_FOUND:
                    response.Success = false;
                    break;
                case ResponseMessages.OPERATION_FAILED:
                    response.Success = false;
                    break;
                case ResponseMessages.DATA_NOT_FOUND:
                    response.Success = false;
                    break;
                default:
                    response.Success = false;
                    response.StatusCode = 500;
                    break;
            }
        }



        public static ServiceDataResponse<T> CreateServiceResponse(IResourceService resourceService, ResponseMessages responseMessage)
        {
            var serviceResponse = new ServiceDataResponse<T>
            {
                Payload = default(T),
            };
            var key = Enum.GetName(typeof(ResponseMessages), responseMessage);
            if (key != null)
            {
                serviceResponse.Message = resourceService.GetResource(key);
            }
            SetResponseDetails(serviceResponse, responseMessage);
            return serviceResponse;
        }
    }
}
