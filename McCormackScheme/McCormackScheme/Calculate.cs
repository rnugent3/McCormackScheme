using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace McCormackScheme
{
    public class Calculate
    {

        internal static double ManningsFrictionSlope(double depth, double bottomWidth, double bankSlopeHorizontalToOne, double velocity, double manningsN, double k)
        {
            double hydraulicRadius = TrapezoidalArea(depth, bottomWidth, bankSlopeHorizontalToOne) / TrapezoidalWettedPerimeter(bottomWidth, depth, bankSlopeHorizontalToOne);
            return (Math.Pow(velocity, 2) * Math.Pow(manningsN, 2)) / (Math.Pow(k, 2) * Math.Pow(hydraulicRadius, (4 / 3)));

        }

        private static double TrapezoidalArea(double depthSolution, double bottomWidth, double bankSlopeHorizontalOnONe)
        {
            return depthSolution * bottomWidth + bankSlopeHorizontalOnONe * Math.Pow(depthSolution, 2);
        }

        private static double TrapezoidalWettedPerimeter(double bottomWidth, double depthSolution, double bankSlopeHorizontalOnONe)
        {
            double hypotenuse = Math.Pow(Math.Pow(depthSolution, 2) + Math.Pow(bankSlopeHorizontalOnONe * depthSolution, 2), 0.5);
            return bottomWidth + 2 * hypotenuse;
        }

        private static double TrapezoidalTopWidth(double depthSolution, double bottomWidth, double bankSlopeHorizontalOnONe)
        {
            return bottomWidth + 2 * bankSlopeHorizontalOnONe * depthSolution;
        }

        internal static double VelocityFromDepthAndFlow(double normalDepth, double bottomWidth, double bankSlopeHorizontalToOne, double flowRate)
        {
            return flowRate / TrapezoidalArea(normalDepth, bottomWidth, bankSlopeHorizontalToOne);

        }

        internal static double SpecificEnergy(double depth, double velocity, double gravity)
        {
            return depth + Math.Pow(velocity, 2) / gravity;
        }
    }
}