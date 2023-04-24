using System;
using System.Diagnostics.CodeAnalysis;

namespace Sat.Recruitment.Domain.Primitives
{
    public abstract class Entity : IEquatable<Entity>
    {
        protected Entity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }

        public bool Equals([AllowNull] Entity other)
        {
            if (other == null)
                return false;

            if (other.GetType() != GetType())
                return false;

            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() * 67;
        }
    }
}
