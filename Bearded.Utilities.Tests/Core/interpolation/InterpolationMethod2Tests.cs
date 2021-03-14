using Bearded.Utilities.Tests.Generators;
using FluentAssertions;
using FsCheck.Xunit;

namespace Bearded.Utilities.Tests
{
    public abstract class InterpolationMethod2Tests
    {
        protected abstract IInterpolationMethod2 Interpolation { get; }

        [Property(Arbitrary = new[] {typeof(DoubleGenerators.NonInfiniteNonNaN)})]
        public void ReturnsValue00At00(double value00, double value10, double value01, double value11)
        {
            Interpolation.Interpolate(value00, value10, value01, value11, 0, 0)
                .Should().BeApproximately(value00, double.Epsilon);
        }

        [Property(Arbitrary = new[] {typeof(DoubleGenerators.NonInfiniteNonNaN)})]
        public void ReturnsValue10At10(double value00, double value10, double value01, double value11)
        {
            Interpolation.Interpolate(value00, value10, value01, value11, 1, 0)
                .Should().BeApproximately(value10, double.Epsilon);
        }

        [Property(Arbitrary = new[] {typeof(DoubleGenerators.NonInfiniteNonNaN)})]
        public void ReturnsValue01At01(double value00, double value10, double value01, double value11)
        {
            Interpolation.Interpolate(value00, value10, value01, value11, 0, 1)
                .Should().BeApproximately(value01, double.Epsilon);
        }

        [Property(Arbitrary = new[] {typeof(DoubleGenerators.NonInfiniteNonNaN)})]
        public void ReturnsValue11At11(double value00, double value10, double value01, double value11)
        {
            Interpolation.Interpolate(value00, value10, value01, value11, 1, 1)
                .Should().BeApproximately(value11, double.Epsilon);
        }

        [Property(Arbitrary = new[] {typeof(DoubleGenerators.UnitIntervalBoundsInclusive)})]
        public void ReturnsValuesBetweenValues(double u, double v)
        {
            Interpolation.Interpolate(0, 0, 1, 1, u, v).Should().BeInRange(0, 1);
        }
    }
}
