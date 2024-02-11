using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Domain.Enums
{
    public enum ResponseMessages
    {
        DATA_RETRIEVED_SUCCESSFULLY,
        ALREADY_EXISTS,
        OPERATION_FAILED, 
        OPERATION_SUCCESS,
        ORDER_ITEM_NOT_FOUND,
        DATA_NOT_FOUND,
        SYSTEM_MESSAGE, INSUFFICIENT_STOCK
    }
}
