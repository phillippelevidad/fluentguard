using Shouldly;
using System;
using Xunit;

namespace FluentGuard.UnitTests
{
    public class NotDefaultValueTests
    {
        [Fact]
        public void NonDefaultValues_WithNotDefault_CauseNoErrors()
        {
            Guard.With("", "string").NotDefault().ThrowIfError();
            Guard.With(1, "int").NotDefault().ThrowIfError();
            Guard.With(Guid.NewGuid(), "guid").NotDefault().ThrowIfError();
            Guard.With(DateTime.Now, "datetime").NotDefault().ThrowIfError();
            Guard.With(new Object(), "object").NotDefault().ThrowIfError();
        }

        [Fact]
        public void DefaultValues_WithNotDefault_CauseErrors()
        {
            Should.Throw<ArgumentException>(() => Guard.With(default(string), "string").NotDefault().ThrowIfError());
            Should.Throw<ArgumentException>(() => Guard.With(default(int), "int").NotDefault().ThrowIfError());
            Should.Throw<ArgumentException>(() => Guard.With(default(Guid), "guid").NotDefault().ThrowIfError());
            Should.Throw<ArgumentException>(() => Guard.With(default(DateTime), "datetime").NotDefault().ThrowIfError());
            Should.Throw<ArgumentException>(() => Guard.With(default(object), "object").NotDefault().ThrowIfError());
        }
    }
}
