using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HA_ERP.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;


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

       
        [Authorize(HA_ERPPermissions.Staffs.Update)]
        public async Task UpdateAsync(int id, UpdateStaffDto input)
        {
            var staff = await _staffManager.GetStaffOrThrowAsync(id);

            await _staffManager.CheckStaffNameExistsAsync(input.Name, id);

            ObjectMapper.Map(input, staff);

            await _staffRepository.UpdateAsync(staff);
        }

        public async Task<PagedResultDto<StaffSimpleDto>> GetListByOrganizationAsync(int id, PagedAndSortedResultRequestDto input)
        {
            var staffs = await _staffRepository.GetStaffsWithManagerRoleAsync();

            var filtered = staffs.Where(x => x.OrganizationId == id);

            var totalCount = filtered.Count();

            var items = filtered
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .Select(x => new StaffSimpleDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();

            return new PagedResultDto<StaffSimpleDto>(totalCount, items);
        }


    }
}
