using System;
using Skahal.Infrastructure.Framework.Repositories;

namespace Skahal.Infrastructure.Framework.People
{
	/// <summary>
	/// Defines a interface for user repository.
	/// </summary>
	public interface IUserRepository : IRepository<User, string>
	{
	}
}