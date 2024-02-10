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
        public T Paylod { get; set; }


        public ServiceDataResponse<T> CreateServiceResponse<T>(bool result, T payload, IResourceService resourceService)
        {
            var serviceResponse = new ServiceDataResponse<T>();
            if (result)
            {
                serviceResponse.Message = resourceService.GetResource("OPERATION_SUCCESS");
                serviceResponse.StatusCode = 200;
                serviceResponse.Success = true;
                serviceResponse.Paylod = payload;
                return serviceResponse;
            }
            else
            {
                serviceResponse.Message = resourceService.GetResource("OPERATION_FAILED");
                serviceResponse.StatusCode = 500;
                serviceResponse.Success = false;
                return serviceResponse;
            }
        }



        public ServiceDataResponse<T> CreateServiceResponse<T>(int statusCode, IResourceService resourceService, ResponseMessages ResponseMessages)
        {
            var serviceResponse = new ServiceDataResponse<T>();
            serviceResponse.Message = resourceService.GetResource(Enum.GetName<ResponseMessages>(ResponseMessages));
            serviceResponse.StatusCode = statusCode;
            serviceResponse.Success = false;
            return serviceResponse;
        }

        public ServiceDataResponse<T> CreateServiceResponse<T>(int statusCode,T paylod, IResourceService resourceService, ResponseMessages ResponseMessages)
        {
            var serviceResponse = new ServiceDataResponse<T>();
            serviceResponse.Message = resourceService.GetResource(Enum.GetName<ResponseMessages>(ResponseMessages));
            serviceResponse.StatusCode = statusCode;
            serviceResponse.Success = true;
            serviceResponse.Paylod=paylod;
            return serviceResponse;
        }
    }
}
