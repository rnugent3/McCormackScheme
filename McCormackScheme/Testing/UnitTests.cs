namespace Testing
{
    public class UnitTests
    {
        /// <summary>
        /// This is the typical format of a unit test
        /// </summary>
        /// <param name="depth"></param>
        /// <param name="bankSlope"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData(10, 1.5, 160)]
        public void HydraulicRadius(double depth, double bankSlope, double expected)
        {
            double actual = McCormackScheme.Calculate.HydraulicRadius(depth, bankSlope);
            Assert.Equal(expected, actual);
        }
    }
}