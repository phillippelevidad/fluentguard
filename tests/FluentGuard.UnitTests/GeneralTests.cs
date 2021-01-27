using Shouldly;
using System;
using Xunit;

namespace FluentGuard.UnitTests
{
    public class GeneralTests
    {
        [Fact]
        public void CreatePersonOnSucceed_WithValidParameters_Works()
        {
            var id = Guid.NewGuid();
            var firstName = "John";
            var lastName = "Doe";
            var age = 30;

            var result = Guard
                .With(id, "Id").NotDefault()
                .With(firstName, "First name").NotNull().Length(3, 30)
                .With(lastName, "Last name").NotNull().Length(3, 30)
                .With(age, "Age").GreaterThanOrEqualTo(18)
                .ThrowIfError()
                .OnSuccess(() => new Person(id, firstName, lastName, age));

            var person = result.Value;

            result.IsSuccess.ShouldBeTrue();
            person.Id.ShouldBe(id);
            person.FirstName.ShouldBe(firstName);
            person.LastName.ShouldBe(lastName);
            person.Age.ShouldBe(30);
        }
    }

    public class Person
    {
        public Person(Guid id, string firstName, string lastName, int age)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }
    }
}
