using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        public void ShouldParseLongitude(string line, double expected)
        {
            //       DONE
            //       TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange
            var longParse = new TacoParser();
            //Act
            var actual = longParse.Parse(line);
            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }


        //TODO: Create a test ShouldParseLatitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        public void ShouldParseLatitude (string line, double expected)
        {
            var longParse = new TacoParser();

            var actual = longParse.Parse(line);

            Assert.Equal(expected, actual.Location.Latitude);
        }
        [Theory]
        [InlineData(1609.34, 1)]
        [InlineData(3218.68, 2)]
        [InlineData(4023.36, 2.5)]
        public void ShouldConvert (double distance, double expected)
        {
            
            var actual = TacoParser.ConvertToMiles(distance);
            Assert.Equal(expected, actual);
        }
    
    }

}
