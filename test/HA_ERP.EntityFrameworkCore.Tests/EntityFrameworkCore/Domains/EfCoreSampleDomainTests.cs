using HA_ERP.Samples;
using Xunit;

namespace HA_ERP.EntityFrameworkCore.Domains;

[Collection(HA_ERPTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<HA_ERPEntityFrameworkCoreTestModule>
{

}
