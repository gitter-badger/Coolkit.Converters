using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

using FluentAssertions;

using Xunit;

using static System.Windows.Visibility;

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
        public void SutDerivesFromMarkupExtension()
        {
            // arrange
            var sut = new BooleanToVisibilityConverter();

            // act && assert
            sut.Should().BeAssignableTo<MarkupExtension>();
        }

        [Fact]
        public void Convert_WithFalse_ShouldReturnCollapse()
        {
            // arrange
            var input = false;
            var expectedResult = Collapsed;

            var sut = new BooleanToVisibilityConverter();

            // act
            var result = sut.Convert(input, typeof(Visibility), null, null);

            //assert
            result.Should().Be(expectedResult);
        }

        [Fact]
        public void Convert_WithTrue_ShouldReturnVisible()
        {
            // arrange
            var input = true;
            var expectedResult = Visible;

            var sut = new BooleanToVisibilityConverter();

            // act
            var result = sut.Convert(input, typeof(Visibility), null, null);

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
            var result = sut.Convert(null, typeof(Visibility), null, null);

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
            var result = sut.Convert(input, typeof(Visibility), null, null);

            //assert
            result.Should().Be(expectedResult);
        }

        [Fact]
        public void Convert_WithWrongTargetType_ShouldReturnUnset()
        {
            // arrange
            var input = true;
            var requestedTargetType = typeof(int);
            var expectedResult = DependencyProperty.UnsetValue;

            var sut = new BooleanToVisibilityConverter();

            // act
            var result = sut.Convert(input, requestedTargetType, null, null);

            //assert
            result.Should().Be(expectedResult);
        }

        [Fact]
        public void ConvertBack_Always_ReturnsUnset()
        {
            // arrange
            var input = string.Empty;
            var expectedResult = DependencyProperty.UnsetValue;

            var sut = new BooleanToVisibilityConverter();

            // act
            var result = sut.ConvertBack(input, null, null, null);

            //assert
            result.Should().Be(expectedResult);
        }


        [Fact]
        public void ConverterAsMarkupExtension_ShouldReturnItself()
        {
            // arrange
            var sut = new BooleanToVisibilityConverter();

            // act
            var result = sut.ProvideValue(null);

            //assert
            result.Should().BeSameAs(sut);
        }
    }
}