using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McCormackScheme
{
    internal class McCormack
    {
        public static (double[], double[], double[]) Scheme(double[] depths, double[] velocities, double[] flows, int nx, double dx, double dt, double g, double manningsN, double bankSlope)
        {
            double[] depthsPredictor = new double[nx];
            double[] velocitiesPredictor = new double[nx];
            double[] flowsPredictor = new double[nx];

            //Predictor Step 
            for (int i = 1; i < nx - 1; i++)
            {
                flowsPredictor[i] = velocities[i]*depths[i];
                depthsPredictor[i] = depths[i] - dt * (flows[i+1] - flows[i])/dx;
                velocitiesPredictor[i] = velocities[i] - dt * g * (depths[i] - depths[i-1])/dx - dt * g * Calculate.ManningsFrictionSlope(velocities[i], depths[i], manningsN, bankSlope);
            }

            //Corrector Step
            for (int i = 1; i < nx - 1; i++)
            {
                depths[i] = 0.5 * (depths[i] + depthsPredictor[i]);
                velocities[i] = 0.5 * (velocities[i] + velocitiesPredictor[i]);
                flows[i] = depths[i] * velocities[i];
            }

            return (depths,  velocities, flows);

        }
    }
}
