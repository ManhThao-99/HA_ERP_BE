using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace HA_ERP
{
    public static class HA_ERPValidationHelper
    {
        public static void ThrowIfExists(object entity)
        {
            if (entity != null)
                throw new BusinessException(HA_ERPDomainErrorCodes.EntityAlreadyExists);
        }

        public static void ThrowIfNotFound(object entity)
        {
            if (entity == null)
                throw new BusinessException(HA_ERPDomainErrorCodes.EntityNotFound);
        }

        public static async Task ThrowIfDuplicateAsync<TEntity, TKey>(
            IRepository<TEntity, TKey> repository,
            Expression<Func<TEntity, bool>> predicate,
            string errorCode
        )
            where TEntity : class, IEntity<TKey>
        {
            var exists = await repository.AnyAsync(predicate);
            if (exists)
                throw new BusinessException(errorCode);
        }
    }
}
