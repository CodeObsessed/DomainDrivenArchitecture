using System;

namespace Drumble.DomainDrivenArchitecture.Domain.Models
{
    public interface IValueObject<T> : IEquatable<T>
    { }
}