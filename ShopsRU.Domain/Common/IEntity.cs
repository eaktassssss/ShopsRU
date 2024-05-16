using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Domain.Common
{
    public interface IEntity
    {
    }
    public interface IEntity<out Key> : IEntity where Key : IEquatable<Key>
    {
        public Key Id { get; }
    }
}
