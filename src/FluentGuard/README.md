# FluentGuard

FluentGuard is a validation framework with a fluent interface.

It's meant to be quick and easy to validate multiple properties on a model with as little code as possible.

But it's also meant to be flexible and powerful, giving you the option to throw exceptions on error, perform an action upon success or simply return the result object, that can latter be converted into `ModelState`, `BadRequest` and `ProblemDetails` in APIs and so much more.

## Basic usage

``` csharp
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
```

## IGuardResult<T> and Errors

With the `IGuardResult<T>` interface, you have the option to inspect the results after all validations have taken place an take further action, instead of throwing an exception right away.

``` csharp
public interface IGuardResult<T>
{
    bool IsFailure { get; }
    bool IsSuccess { get; }
    Errors Errors { get; }
    T Value { get }
}
```

Upon failure, each guard clause stores its error both as a simple string and a full exception with the parameter name, making it easy to return a friendly message to the user, bubble exceptions or convert the errors to another object type.

``` csharp
public class Errors : List<KeyValuePair<string, Exception>>
{
    public string[] GetMessages();
    public Exception[] GetExceptions();
}
```

## Easily extensible via extension methods

``` csharp
public static class MyGuardClauseExtensions
{
    public static IGuardClauseWithInput<Uri> MustBeAbsolute<Uri>(this IGuardClauseWithInput<Uri> guardClause)
    {
        if (!guardClause.Input.IsAbsolute)
        {
            guardClause.Errors.Add(new ArgumentException(
                guardClause.ParameterName, "The URI must be absolute"));
        }

        return guardClause;
    } 
}
```

Though you can always do it with a simple lambda:

``` csharp
var uri = new Uri("http://github.com");
Guard.With(uri, "Website").Must(value => value.IsAbsolute).ThrowIfError();
Guard.With(uri, "Website").MustNot(value => value.IsRelative).ThrowIfError();
```