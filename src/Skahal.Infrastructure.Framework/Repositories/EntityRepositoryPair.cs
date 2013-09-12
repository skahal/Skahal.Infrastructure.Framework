using System;
using Skahal.Infrastructure.Framework.Domain;

namespace Skahal.Infrastructure.Framework.Repositories
{
	/// <summary>
	/// Entity repository pair.
	/// </summary>
	internal class EntityRepositoryPair<TKey>
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="Skahal.Infrastructure.Framework.Repositories.EntityRepositoryPair&lt;TKey&gt;"/> class.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="repository">Repository.</param>
		public EntityRepositoryPair (IAggregateRoot<TKey> entity, IUnitOfWorkRepository<TKey> repository)
		{
			Entity = entity;
			Repository = repository;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets or sets the entity.
		/// </summary>
		/// <value>The entity.</value>
		public IAggregateRoot<TKey> Entity { get; set; }

		/// <summary>
		/// Gets or sets the repository.
		/// </summary>
		/// <value>The repository.</value>
		public IUnitOfWorkRepository<TKey> Repository { get; set; }
		#endregion
	}
}