using System;

namespace FN.WorkShopNetCoreAngular.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {
        public int Id { get; protected set; }
        public bool Equals(Entity other)
        {
            return other.Id == this.Id;
        }
    }
}