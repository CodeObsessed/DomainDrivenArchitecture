using System;

namespace Drumble.DomainDrivenArchitecture.Domain.Models
{
    [Serializable]
    public abstract class DomainEntity<TIdentity>
    {
        private TIdentity uniqueId;

        public TIdentity Id
        {
            get
            {
                return uniqueId;
            }
        }

        protected DomainEntity(TIdentity id)
        {
            uniqueId = id;
        }

        public override bool Equals(object obj)
        {
            var entity = obj as DomainEntity<TIdentity>;

            if (entity == null)
            {
                return false;
            }
            else
            {
                return uniqueId.Equals(entity.Id);
            }
        }

        public override int GetHashCode()
        {
            return uniqueId.GetHashCode();
        }
    }
}