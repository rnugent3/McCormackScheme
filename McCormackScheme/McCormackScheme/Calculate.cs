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

        public static double ManningsFrictionSlope(double depth, double bottomWidth, double bankSlopeHorizontalToOne, double velocity, double manningsN, double k)
        {
            double hydraulicRadius = TrapezoidalArea(depth, bottomWidth, bankSlopeHorizontalToOne) / TrapezoidalWettedPerimeter(bottomWidth, depth, bankSlopeHorizontalToOne);
            return (Math.Pow(velocity, 2) * Math.Pow(manningsN, 2)) / (Math.Pow(k, 2) * Math.Pow(hydraulicRadius, (4 / 3)));
        }

        public static double ManningsFrictionSlope(double velocity, double depth, double manningsN, double bankSlopeHorizontalToOne)
        {
            return (Math.Pow(velocity, 2) * Math.Pow(manningsN, 2)) / HydraulicRadius(depth, bankSlopeHorizontalToOne);
        }

        public static double HydraulicRadius(double depth, double bankSlopeHorizontalToOne)
        {
            return depth + bankSlopeHorizontalToOne * Math.Pow(depth, 2);
        }

        public static double TrapezoidalArea(double depthSolution, double bottomWidth, double bankSlopeHorizontalOnONe)
        {
            return depthSolution * bottomWidth + bankSlopeHorizontalOnONe * Math.Pow(depthSolution, 2);
        }

        public static double TrapezoidalWettedPerimeter(double bottomWidth, double depthSolution, double bankSlopeHorizontalOnONe)
        {
            double hypotenuse = Math.Pow(Math.Pow(depthSolution, 2) + Math.Pow(bankSlopeHorizontalOnONe * depthSolution, 2), 0.5);
            return bottomWidth + 2 * hypotenuse;
        }

        public static double TrapezoidalTopWidth(double depthSolution, double bottomWidth, double bankSlopeHorizontalOnONe)
        {
            return bottomWidth + 2 * bankSlopeHorizontalOnONe * depthSolution;
        }

        public static double VelocityFromDepthAndFlow(double normalDepth, double bottomWidth, double bankSlopeHorizontalToOne, double flowRate)
        {
            return flowRate / TrapezoidalArea(normalDepth, bottomWidth, bankSlopeHorizontalToOne);

        }

        public static double SpecificEnergy(double depth, double velocity, double gravity)
        {
            return depth + Math.Pow(velocity, 2) / gravity;
        }
    }
}