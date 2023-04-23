using System;

namespace Sat.Recruitment.Domain.Entities
{
    internal abstract class Entity : IEquatable<Entity>
    {
        protected Entity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }

        public static bool operator ==(Entity a, Entity b)
        {
            return a != null && b != null && a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public bool Equals(Entity other)
        {
            if (other == null)
                return false;

            if (other.GetType() != GetType())
                return false;

            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Entity userIdObj = obj as Entity;
            if (userIdObj == null)
                return false;
            else
                return Equals(obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() * 67;
        }
    }
}
