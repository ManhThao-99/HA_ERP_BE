using HA_ERP.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.ObjectMapping;


namespace HA_ERP.Staffs
{
    [Authorize(HA_ERPPermissions.Staffs.Default)]
    public class StaffAppService : HA_ERPAppService, IStaffAppService
    {
        
        private readonly StaffManager _staffManager;

        private readonly IStaffRepository _staffRepository;


        public StaffAppService(StaffManager staffManager, IStaffRepository staffRepository) 
        {
            this._staffManager = staffManager;
            _staffRepository = staffRepository;
        }

        [Authorize(HA_ERPPermissions.Staffs.Create)]
        public async Task<StaffDto> CreateAsync(CreateStaffDto input)
        {
            await _staffManager.CheckDuplicateFieldAsync(input.Name, "Name");
            await _staffManager.CheckDuplicateFieldAsync(input.Code, "Code");
            await _staffManager.CheckDuplicateFieldAsync(input.Email, "Email");
            var staff = ObjectMapper.Map<CreateStaffDto, Staff>(input);
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
            var staff = await _staffManager.GetStaffOrThrowAsync(id);
            return ObjectMapper.Map<Staff, StaffDto>(staff);
        }

        public async Task<PagedResultDto<StaffDto>> GetListAsync()
        {
            var staffList = await _staffRepository.GetListAsync();
            var staffDtoList = ObjectMapper.Map<List<Staff>, List<StaffDto>>(staffList);

            var totalCount = staffDtoList.Count;

            return new PagedResultDto<StaffDto>(totalCount, staffDtoList);
        }

        public async Task<PagedResultDto<StaffDto>> GetListByOrganizationAsync(Guid id, PagedAndSortedResultRequestDto input)
        {
            var staffList = await _staffRepository.GetListAsync(a => a.OrganizationUnitId == id);
            
            var staffDtoList = ObjectMapper.Map<List<Staff>, List<StaffDto>>(staffList);

            var totalCount = staffDtoList.Count;

            return new PagedResultDto<StaffDto>(totalCount, staffDtoList);
        }

       
        public async Task<List<StaffSimpleDto>> GetManager(Guid id)
        {
            var staffs = await _staffRepository.GetStaffsWithManagerRoleAsync(id);

            return ObjectMapper.Map<List<Staff>, List<StaffSimpleDto>>(staffs);
        }

        [Authorize(HA_ERPPermissions.Staffs.Update)]
        public async Task UpdateAsync(int id, UpdateStaffDto input)
        {
            var staff = await _staffManager.GetStaffOrThrowAsync(id);
            await _staffManager.CheckDuplicateFieldAsync(input.Name, "Name",id);
            await _staffManager.CheckDuplicateFieldAsync(input.Code, "Code",id);
            await _staffManager.CheckDuplicateFieldAsync(input.Email, "Email", id);


            ObjectMapper.Map(input, staff);

            await _staffRepository.UpdateAsync(staff);
        }

      

    }
}
