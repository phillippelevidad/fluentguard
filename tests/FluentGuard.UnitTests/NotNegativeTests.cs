using Shouldly;
using System;
using Xunit;

namespace FluentGuard.UnitTests
{
    public class NotNegativeTests
    {
        [Fact]
        public void ZeroValues_WithNotNegative_CauseNoErrors()
        {
            Guard.With(0, "int").NotNegative();
            Guard.With(0L, "long").NotNegative();
            Guard.With(0M, "decimal").NotNegative();
            Guard.With(0F, "float").NotNegative();
            Guard.With(0D, "double").NotNegative();
        }

        [Fact]
        public void PositiveValues_WithNotNegative_CauseNoErrors()
        {
            Guard.With(1, "int").NotNegative();
            Guard.With(1L, "long").NotNegative();
            Guard.With(1M, "decimal").NotNegative();
            Guard.With(1F, "float").NotNegative();
            Guard.With(1D, "double").NotNegative();
        }

        [Fact]
        public void NegativeValues_WithNotNegative_CauseErrors()
        {
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(-1, "int").NotNegative().ThrowIfError());
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(-1L, "long").NotNegative().ThrowIfError());
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(-1M, "decimal").NotNegative().ThrowIfError());
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(-1F, "float").NotNegative().ThrowIfError());
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(-1D, "double").NotNegative().ThrowIfError());
        }
    }
}
