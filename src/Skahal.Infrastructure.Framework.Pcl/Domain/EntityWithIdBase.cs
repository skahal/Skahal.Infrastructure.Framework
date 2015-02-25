
using System;
namespace Skahal.Infrastructure.Framework.Domain
{
    /// <summary>
    /// A domain entity base class that use a strong Id property instead object Key as entity key.
    /// </summary>
    public class EntityWithIdBase<TId> : IEntity
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityWithIdBase{TId}"/> class.
        /// </summary>
        protected EntityWithIdBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityWithIdBase{TId}"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        protected EntityWithIdBase(TId id)
        {
            Id = id;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public virtual TId Id { get; set; }

        /// <summary>
        /// Gets the id.
        /// </summary>
        object IEntity.Key
        {
            get
            {
                return Id;
            }
            set
            {
                Id = (TId)value;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is EntityWithIdBase<TId>))
            {
                return false;
            }

            return this == (EntityWithIdBase<TId>)obj;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            if (((IEntity)this).Key == null)
            {
                return 0;
            }

            return ((IEntity)this).Key.GetHashCode();
        }
        #endregion

        #region Operators
        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="base1">The base1.</param>
        /// <param name="base2">The base2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(EntityWithIdBase<TId> base1, EntityWithIdBase<TId> base2)
        {
            // Check for both null (need this casts to object or will run in a recursive loop).
            if ((object)base1 == null && (object)base2 == null)
            {
                return true;
            }

            if ((object)base1 == null || (object)base2 == null)
            {
                return false;
            }

            if (((IEntity)base1).Key == null && ((IEntity)base2).Key == null)
            {
                return object.ReferenceEquals(base1, base2);
            }

            if (((IEntity)base1).Key == null || ((IEntity)base2).Key == null)
            {
                return false;
            }

            // Id value is the default one, so it can compare the entities by key.
            var defaultIdValue = default(TId);

            if (base1.Id.Equals(defaultIdValue) && base2.Id.Equals(defaultIdValue))
            {
                return object.ReferenceEquals(base1, base2);
            }

            return ((IEntity)base1).Key.Equals(((IEntity)base2).Key);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="base1">The base1.</param>
        /// <param name="base2">The base2.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(EntityWithIdBase<TId> base1, EntityWithIdBase<TId> base2)
        {
            return !(base1 == base2);
        }
        #endregion
    }
}
