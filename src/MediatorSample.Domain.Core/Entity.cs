using System;

namespace MediatorSample.Domain.Core
{
    public class Entity
    {
        /// <summary>
        /// Unique Id property to current domain.
        /// </summary>
        /// <value></value>
        public Guid Id { get; private set; }

        /// <summary>
        ///  Creates the new id when an entity domain created.
        /// </summary>
        public void NewId()
        {
            Id = Guid.NewGuid();
        }
        /// <summary>
        /// Set a id for this current entity domain.
        /// </summary>
        /// <param name="id"></param>
        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}