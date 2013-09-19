using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Skahal.Infrastructure.Framework.Domain;

namespace Skahal.Infrastructure.Framework.UnitTests.Repositories
{
    public class EntityWithIntIdStub : EntityWithIdBase<int>, IAggregateRoot
    {
    }
}
