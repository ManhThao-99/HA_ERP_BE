using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HA_ERP.OrganizationUnits;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.ObjectMapping;

public class OrganizationUnitAppService
    : CrudAppService<
        OrganizationUnit,
        OrganizationUnitDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateOrganizationUnitDto,
        UpdateOrganizationUnitDto
    >
{
    private readonly IRepository<OrganizationUnit, Guid> _repository;
    private readonly OrganizationUnitManager _manager;

    public OrganizationUnitAppService(IRepository<OrganizationUnit, Guid> repository)
        : base(repository)
    {
        _repository = repository;
    }

    public OrganizationUnitAppService(
        IRepository<OrganizationUnit, Guid> repository,
        OrganizationUnitManager manager
    )
        : this(repository)
    {
        _manager = manager;
    }

    public async Task<List<OrganizationUnitTreeDto>> GetTreeAsync()
    {
        var allUnits = await _repository.GetListAsync();
        if (allUnits == null)
            throw new Exception("allUnits is null!");

        var dtos = ObjectMapper.Map<List<OrganizationUnit>, List<OrganizationUnitTreeDto>>(
            allUnits
        );
        if (dtos == null)
            throw new Exception("Mapping failed! Check AutoMapper configuration.");
        // Build tree
        var lookup = dtos.ToDictionary(x => x.Id);
        List<OrganizationUnitTreeDto> roots = new List<OrganizationUnitTreeDto>();

        foreach (var node in dtos)
        {
            if (node.ParentId != null && lookup.ContainsKey(node.ParentId.Value))
            {
                lookup[node.ParentId.Value].Children.Add(node);
            }
            else
            {
                roots.Add(node);
            }
        }

        return roots;
    }

    public override async Task<OrganizationUnitDto> CreateAsync(CreateOrganizationUnitDto input)
    {
        var orgUnit = new OrganizationUnit(
            GuidGenerator.Create(),
            input.DisplayName,
            input.ParentId
        );

        await _manager.CreateAsync(orgUnit);

        return ObjectMapper.Map<OrganizationUnit, OrganizationUnitDto>(orgUnit);
    }
}
