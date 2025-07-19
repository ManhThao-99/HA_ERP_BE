using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace HA_ERP.Staffs
{
    public class StaffManager : DomainService
    {
        private readonly IStaffRepository _staffRepository;

        public StaffManager(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        public async Task<Staff> GetStaffOrThrowAsync(int id)
        {
            var staff = await _staffRepository.FindAsync(id);
            if (staff == null)
            {
                HA_ERPValidationHelper.ThrowIfNotFound(staff);
            }
            return staff;
        }

        public async Task CheckStaffNameExistsAsync(string name, int exceptId = 0)
        {
            var exists = await _staffRepository.AnyAsync(x => x.Name == name && x.Id != exceptId);
            if (exists)
            {
                HA_ERPValidationHelper.ThrowIfExists(exists);
            }
        }
        //dùng Expression Tree
        public async Task CheckDuplicateFieldAsync(object value, string field, object exceptId = null)
        {
            // Nếu value là null thì không cần check trùng
            if (value == null)
                return;

            var propInfo = typeof(Staff).GetProperty(field);
            if (propInfo == null)
                throw new ArgumentException($"Property '{field}' not found on Staff.");

            object convertedValue = Convert.ChangeType(value, propInfo.PropertyType);

            var idProp = typeof(Staff).GetProperty("Id");
            if (idProp == null)
                throw new ArgumentException("Property 'Id' not found on Staff.");

            object convertedExceptId = exceptId != null ? Convert.ChangeType(exceptId, idProp.PropertyType) : null;

            var param = Expression.Parameter(typeof(Staff), "x");
            var left = Expression.Property(param, propInfo);
            var right = Expression.Constant(convertedValue, propInfo.PropertyType);
            var equalField = Expression.Equal(left, right);

            Expression predicateBody = equalField;
            if (convertedExceptId != null)
            {
                var idLeft = Expression.Property(param, idProp);
                var idRight = Expression.Constant(convertedExceptId, idProp.PropertyType);
                var notEqualId = Expression.NotEqual(idLeft, idRight);
                predicateBody = Expression.AndAlso(equalField, notEqualId);
            }

            var lambda = Expression.Lambda<Func<Staff, bool>>(predicateBody, param);

            await HA_ERPValidationHelper.ThrowIfDuplicateAsync(
                _staffRepository,
                lambda,
                HA_ERPDomainErrorCodes.EntityAlreadyExists
            );
        }
    }
}
