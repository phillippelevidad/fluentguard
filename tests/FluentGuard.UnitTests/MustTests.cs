using Shouldly;
using System;
using Xunit;

namespace FluentGuard.UnitTests
{
    public class MustTests
    {
        [Fact]
        public void Input_WithTruePredicate_CausesNoErrors()
        {
            Guard.With("123", "string").Must(s => s.Length == 3).ThrowIfError();
        }

        [Fact]
        public void Input_WithFalsePredicate_CausesErrors()
        {
            Should.Throw<ArgumentException>(() => Guard.With("123", "string").Must(s => s.Length != 3).ThrowIfError());
        }
    }
}
