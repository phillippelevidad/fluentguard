using Shouldly;
using System;
using Xunit;

namespace FluentGuard.UnitTests
{
    public class MustNotTests
    {
        [Fact]
        public void Input_WithFalsePredicate_CausesNoErrors()
        {
            Guard.With("123", "string").MustNot(s => s.Equals("abc")).ThrowIfError();
        }

        [Fact]
        public void Input_WithFalsePredicate_CausesErrors()
        {
            Should.Throw<ArgumentException>(() => Guard.With("123", "string").MustNot(s => s.Equals("123")).ThrowIfError());
        }
    }
}
