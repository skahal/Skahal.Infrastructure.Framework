using System;
using Skahal.Infrastructure.Framework.Commons;
using Skahal.Infrastructure.Framework.Repositories;

namespace Skahal.Infrastructure.Framework.Domain
{
	/// <summary>
	/// A domain service base class.
	/// </summary>
	public abstract class ServiceBase<TEntity, TMainRepository, TUnitOfWork>
		where TMainRepository : IRepository<TEntity>
		where TUnitOfWork : IUnitOfWork
		where TEntity : IAggregateRoot
	{
		#region Constructors 
		/// <summary>
		/// Initializes a new instance of the Skahal.Infrastructure.Framework.Domain.ServiceBase/> class.
		/// </summary>
		protected ServiceBase() 
			: this(DependencyService.Create<TMainRepository>(), DependencyService.Create<TUnitOfWork>())
		{
		} 

		/// <summary>
		/// Initializes a new instance of the Skahal.Infrastructure.Framework.Domain.ServiceBase/> class.
		/// </summary>
		/// <param name="eventRepository">Event repository.</param>
		/// <param name="unitOfWork">Unit of work.</param>
		protected ServiceBase(TMainRepository eventRepository, TUnitOfWork unitOfWork)
		{
			MainRepository = eventRepository; 
			UnitOfWork = unitOfWork;
			MainRepository.SetUnitOfWork (UnitOfWork);
		}
		#endregion

		#region Fields	 
		/// <summary>
		/// Gets the main repository.
		/// </summary>
		/// <value>The main repository.</value>
		protected TMainRepository MainRepository { get; private set; }

		/// <summary>
		/// Gets the unit of work.
		/// </summary>
		/// <value>The unit of work.</value>
		protected TUnitOfWork UnitOfWork { get; private set; }
		#endregion 

	}
}