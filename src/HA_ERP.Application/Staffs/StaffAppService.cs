using HA_ERP.Organizations;
using HA_ERP.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace HA_ERP.Staffs
{
    [Authorize(HA_ERPPermissions.Staffs.Default)]
    public class StaffAppService : HA_ERPAppService, IStaffAppService
    {
        private readonly IOrganizationAppService _organizationAppService;

        private readonly IStaffRepository _staffRepository;

        public StaffAppService(IOrganizationAppService organizationAppService, IStaffRepository staffRepository)
        {
            _organizationAppService = organizationAppService;
            _staffRepository = staffRepository;
        }

        [Authorize(HA_ERPPermissions.Staffs.Create)]
        public async Task<StaffDto> CreateAsync(CreateStaffDto input)
        {
            var staff = new Staff
            {
                OrganizationId = input.OrganizationId,
                ManagerId = input.ManagerId,
                Code = input.Code,

                Name = input.Name,
                Mobile = input.Mobile,
                Email = input.Email,

                Address = input.Address,
                BankAccountName = input.BankAccountName,
                BankAccountNo = input.BankAccountNo,

                BankName = input.BankName,
                BankAddress = input.BankAddress

            };
            await _staffRepository.InsertAsync(staff);

            return ObjectMapper.Map<Staff, StaffDto>(staff);
        }


        [Authorize(HA_ERPPermissions.Staffs.Delete)]
        public async Task DeleteAsync(int id)
        {
            await _staffRepository.DeleteAsync(id);
        }

        public async Task<StaffDto> GetAsync(int id)
        {
            var staff = await _staffRepository.GetAsync(id);  
            return ObjectMapper.Map<Staff, StaffDto>(staff);

        }

        public async Task<PagedResultDto<StaffDto>> GetListAsync()
        {
            var staffList = await _staffRepository.GetListAsync();
            var staffDtoList = ObjectMapper.Map<List<Staff>, List<StaffDto>>(staffList);

            var totalCount = staffDtoList.Count;

            return new PagedResultDto<StaffDto>(
                totalCount,
                staffDtoList
            );
        }

        [Authorize(HA_ERPPermissions.Staffs.Update)]
        public async Task UpdateAsync(int id, UpdateStaffDto input)
        {
            var staff = await _staffRepository.GetAsync(id);

            var exists = await _staffRepository.AnyAsync(
                x => x.Name == input.Name && x.Id != id
            );
            if (exists)
            {
                throw new UserFriendlyException("Tên nhân viên đã tồn tại!");
            }

            staff.OrganizationId = input.OrganizationId;
            staff.ManagerId = input.ManagerId;
            staff.Code = input.Code;
            staff.Name = input.Name;
            staff.Mobile = input.Mobile;
            staff.Email = input.Email;
            staff.Address = input.Address;
            staff.BankAccountName = input.BankAccountName;
            staff.BankAccountNo = input.BankAccountNo;
            staff.BankName = input.BankName;
            staff.BankAddress = input.BankAddress;

            await _staffRepository.UpdateAsync(staff);
        }

    }
}
