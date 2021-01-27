using Shouldly;
using System;
using Xunit;

namespace FluentGuard.UnitTests
{
    public class GreaterThanTests
    {
        [Fact]
        public void GreaterValues_WithGreaterThan_CauseNoErrors()
        {
            Guard.With(2, "int").GreaterThan(1);
            Guard.With(2L, "long").GreaterThan(1L);
            Guard.With(2M, "decimal").GreaterThan(1M);
            Guard.With(2F, "float").GreaterThan(1F);
            Guard.With(2D, "double").GreaterThan(1D);
            Guard.With(new DateTime(1992, 1, 1), "datetime").GreaterThan(new DateTime(1991, 1, 1));
        }

        [Fact]
        public void EqualValues_WithGreaterThan_CauseErrors()
        {
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(1, "int").GreaterThan(1).ThrowIfError());
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(1L, "long").GreaterThan(1L).ThrowIfError());
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(1M, "decimal").GreaterThan(1M).ThrowIfError());
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(1F, "float").GreaterThan(1F).ThrowIfError());
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(1D, "double").GreaterThan(1D).ThrowIfError());
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(new DateTime(1991, 1, 1), "datetime").GreaterThan(new DateTime(1991, 1, 1)).ThrowIfError());
        }

        [Fact]
        public void LesserValues_WithGreaterThan_CauseErrors()
        {
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(0, "int").GreaterThan(1).ThrowIfError());
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(0L, "long").GreaterThan(1L).ThrowIfError());
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(0M, "decimal").GreaterThan(1M).ThrowIfError());
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(0F, "float").GreaterThan(1F).ThrowIfError());
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(0D, "double").GreaterThan(1D).ThrowIfError());
            Should.Throw<ArgumentOutOfRangeException>(() => Guard.With(new DateTime(1990, 1, 1), "datetime").GreaterThan(new DateTime(1991, 1, 1)).ThrowIfError());
        }
    }
}
