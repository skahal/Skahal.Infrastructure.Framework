using Skahal.Infrastructure.Framework.Domain;

namespace Skahal.Infrastructure.Framework.Repositories
{
    /// <summary>
    /// The states of an entity inside the Unit Of Work.
    /// </summary>
    public enum UnitOfWorkEntityState
    {
        /// <summary>
        /// The entity has been register to be added.
        /// </summary>
        Added,

        /// <summary>
        /// The entity has been register to be changed.
        /// </summary>
        Changed,

        /// <summary>
        /// The entity has been register to be removed.
        /// </summary>
        Removed
    }

    /// <summary>
    /// Represents a entity inside an Unit Of Work.
    /// </summary>
    public class UnitOfWorkEntity
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkEntity"/> class.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="state">The state.</param>
        public UnitOfWorkEntity(IAggregateRoot entity, UnitOfWorkEntityState state)
        {
            Entity = entity;
            State = state;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        public IAggregateRoot Entity { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public UnitOfWorkEntityState State { get; set; }
        #endregion
    }
}