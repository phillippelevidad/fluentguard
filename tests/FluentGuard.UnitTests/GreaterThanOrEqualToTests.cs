using Shouldly;
using System;
using Xunit;

namespace FluentGuard.UnitTests
{
    public class GreaterThanOrEqualToTests
    {
        [Fact]
        public void GreaterValues_WithGreaterThanOrEqualTo_CauseNoErrors()
        {
            Guard.With(2, "int").GreaterThanOrEqualTo(1);
            Guard.With(2L, "long").GreaterThanOrEqualTo(1L);
            Guard.With(2M, "decimal").GreaterThanOrEqualTo(1M);
            Guard.With(2F, "float").GreaterThanOrEqualTo(1F);
            Guard.With(2D, "double").GreaterThanOrEqualTo(1D);
            Guard.With(new DateTime(1992, 1, 1), "datetime").GreaterThanOrEqualTo(new DateTime(1991, 1, 1));
        }

        [Fact]
        public void EqualValues_WithGreaterThanOrEqualTo_CauseNoErrors()
        {
            Guard.With(1, "int").GreaterThanOrEqualTo(1);
            Guard.With(1L, "long").GreaterThanOrEqualTo(1L);
            Guard.With(1M, "decimal").GreaterThanOrEqualTo(1M);
            Guard.With(1F, "float").GreaterThanOrEqualTo(1F);
            Guard.With(1D, "double").GreaterThanOrEqualTo(1D);
            Guard.With(new DateTime(1991, 1, 1), "datetime").GreaterThanOrEqualTo(new DateTime(1991, 1, 1));
        }

        [Fact]
        public void LesserValues_WithGreaterThanOrEqualTo_CauseErrors()
        {
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(0, "int").GreaterThanOrEqualTo(1).ThrowIfError());
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(0L, "long").GreaterThanOrEqualTo(1L).ThrowIfError());
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(0M, "decimal").GreaterThanOrEqualTo(1M).ThrowIfError());
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(0F, "float").GreaterThanOrEqualTo(1F).ThrowIfError());
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(0D, "double").GreaterThanOrEqualTo(1D).ThrowIfError());
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(new DateTime(1990, 1, 1), "datetime").GreaterThanOrEqualTo(new DateTime(1991, 1, 1)).ThrowIfError());
        }
    }
}
