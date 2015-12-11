using System.Windows;
using System.Windows.Data;

using FluentAssertions;

using Xunit;

namespace Coolkit.Converters.UnitTests
{
    public class BooleanToVisibilityConverterFacts
    {
        [Fact]
        public void SutImplementsInterface()
        {
            // arrange
            var sut = new BooleanToVisibilityConverter();

            // act && assert
            sut.Should().BeAssignableTo<IValueConverter>();
        }

        [Fact]
        public void Convert_WithFalse_ShouldReturnCollapse()
        {
            // arrange
            var input = false;
            var expectedResult = Visibility.Collapsed;

            var sut = new BooleanToVisibilityConverter();

            // act
            var result = sut.Convert(input, null, null, null);

            //assert
            result.Should().Be(expectedResult);
        }

        [Fact]
        public void Convert_WithTrue_ShouldReturnVisible()
        {
            // arrange
            var input = true;
            var expectedResult = Visibility.Visible;

            var sut = new BooleanToVisibilityConverter();

            // act
            var result = sut.Convert(input, null, null, null);

            //assert
            result.Should().Be(expectedResult);
        }

        [Fact]
        public void Convert_WithNull_ShouldReturnUnset()
        {
            // arrange
            var expectedResult = DependencyProperty.UnsetValue;

            var sut = new BooleanToVisibilityConverter();

            // act
            var result = sut.Convert(null, null, null, null);

            //assert
            result.Should().Be(expectedResult);
        }

        [Fact]
        public void Convert_WithOtherType_ShouldReturnUnset()
        {
            // arrange
            var input = string.Empty;
            var expectedResult = DependencyProperty.UnsetValue;

            var sut = new BooleanToVisibilityConverter();

            // act
            var result = sut.Convert(input, null, null, null);

            //assert
            result.Should().Be(expectedResult);
        }
    }
}