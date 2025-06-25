using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace HA_ERP
{
    public static class HA_ERPValidationHelper
    {
        

        public static void ThrowIfExists(bool exists)
        {
            if (exists)
                throw new BusinessException(HA_ERPDomainErrorCodes.EntityAlreadyExists);
        }

        public static void ThrowIfNotFound(object entity)
        {
            if (entity == null)
                throw new BusinessException(HA_ERPDomainErrorCodes.EntityNotFound);
        }

    }
}
