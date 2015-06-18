Purpose

DomainDrivenArchitecture.Domain is intended to provide an infrastructure-ignorant and standardised platform to implementing the principles and concepts established in Domain Driven Design.​​​​​​

Motivation behind the 4.0.0 rework

This package (along with others) is intended to replace the DomainDrivenArchitecture 3.X.X implementation. One of primary aims behind version 4.0.0 is for all the pieces to be highly modular.  There will be separate infrastructural module for an Entity Framework implementation, a separate one for DocumentDb, etc.  Not only will developers now only need to include what they need, but it will also allow for these modules to evolve and iterate independently from each other.  In addition, version 3.X.X introduced unavoidable infrastructural dependencies in the domain layers (such as Entity Framework).  We now have a separate package (this package!) for just domain-related interfaces and implementations. The Entity Framework implementation from 3.X.X also attempted to provide too much underlying "boilerplate" code and was found to be inflexible and restrictive in certain situations.


Implementation

Domain Entities​​​
​Domain entities should inherit from the abstract DomainEntity<T> class. This class provides a standardised mechanism to provide identity to entities. Example:

public class Agency : DomainEntity<Guid>, IAggregateRoot
{
    public string Name { get; private set; }

    public Agency(string name)
        : base(Guid.NewGuid())
    {
        if (String.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException("name");
        }

        Name = name;
    }
}​

Value Objects

Value objects should implement IValueObject<T>. This will ensure that value object equality is defined. Example:

public class SomeValueObject: IValueObject<SomeValueObject>
{
    public int SomeValue { get; private set; }

    public bool Equals(SomeValueObject other)
    {
        return this.SomeValue == other.SomeValue;
    }
}​​

Aggregate Roots

The root entities of an aggregate must implement the empty IAggregateRoot interface. This is required by the repositories.

Repositories

The framework provides the following repository interfaces:
