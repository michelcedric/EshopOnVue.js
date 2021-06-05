namespace EshopOnVue.js.Core.Entities
{
    /// <summary>
    /// Base entity definition
    /// </summary>
    public abstract class BaseEntity<TKey>
    {
        /// <summary>
        /// The unique identifier of an entity
        /// Put as virtual to let it mockable if necessary
        /// </summary>
        public virtual TKey Id { get; protected set; }
    }
}
