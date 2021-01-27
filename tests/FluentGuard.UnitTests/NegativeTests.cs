using Shouldly;
using System;
using Xunit;

namespace FluentGuard.UnitTests
{
    public class NegativeTests
    {
        [Fact]
        public void NegativeValues_WithNegative_CauseNoErrors()
        {
            Guard.With(-1, "int").Negative();
            Guard.With(-1L, "long").Negative();
            Guard.With(-1M, "decimal").Negative();
            Guard.With(-1F, "float").Negative();
            Guard.With(-1D, "double").Negative();
        }

        [Fact]
        public void ZeroValues_WithNegative_CauseErrors()
        {
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(0, "int").Negative().ThrowIfError());
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(0L, "long").Negative().ThrowIfError());
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(0M, "decimal").Negative().ThrowIfError());
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(0F, "float").Negative().ThrowIfError());
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(0D, "double").Negative().ThrowIfError());
        }
    }
}
