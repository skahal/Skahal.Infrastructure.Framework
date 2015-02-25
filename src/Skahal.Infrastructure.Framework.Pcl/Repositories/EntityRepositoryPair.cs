using System;
using Skahal.Infrastructure.Framework.Domain;

namespace Skahal.Infrastructure.Framework.Repositories
{
	/// <summary>
	/// Entity repository pair.
	/// </summary>
	public class EntityRepositoryPair
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="Skahal.Infrastructure.Framework.Repositories.EntityRepositoryPair&lt;TKey&gt;"/> class.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="repository">Repository.</param>
		public EntityRepositoryPair (UnitOfWorkEntity entity, IUnitOfWorkRepository repository)
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
        public UnitOfWorkEntity Entity { get; set; }

		/// <summary>
		/// Gets or sets the repository.
		/// </summary>
		/// <value>The repository.</value>
		public IUnitOfWorkRepository Repository { get; set; }
		#endregion
	}
}