using HA_ERP.Samples;
using Xunit;

namespace HA_ERP.EntityFrameworkCore.Applications;

[Collection(HA_ERPTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<HA_ERPEntityFrameworkCoreTestModule>
{

}
