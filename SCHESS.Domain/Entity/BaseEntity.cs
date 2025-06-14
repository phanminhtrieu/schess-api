using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCHESS.Domain.Entity
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }

        /// <summary>
        /// True if domain entity has an identity 
        /// </summary>
        /// <returns></returns>
        public bool IsTransient()
        {
            return Id.Equals(default(T));
        }
    }
}
