using Xunit;

namespace HA_ERP.EntityFrameworkCore;

[CollectionDefinition(HA_ERPTestConsts.CollectionDefinitionName)]
public class HA_ERPEntityFrameworkCoreCollection : ICollectionFixture<HA_ERPEntityFrameworkCoreFixture>
{

}
