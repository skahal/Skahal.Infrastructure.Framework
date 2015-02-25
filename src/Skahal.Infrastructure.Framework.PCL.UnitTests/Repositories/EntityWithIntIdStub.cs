using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Skahal.Infrastructure.Framework.PCL.Domain;

namespace Skahal.Infrastructure.Framework.PCL.UnitTests.Repositories
{
    public class EntityWithIntIdStub : EntityWithIdBase<int>, IAggregateRoot
    {
    }
}
