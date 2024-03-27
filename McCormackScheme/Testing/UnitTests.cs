namespace Testing
{
    public class UnitTests
    {
        [Theory]
        [InlineData(10, 1.5, 160)]
        public void HydraulicRadius(double depth, double bankSlope, double expected)
        {
            double actual = McCormackScheme.Calculate.HydraulicRadius(depth, bankSlope);
            Assert.Equal(expected, actual);
        }
    }
}