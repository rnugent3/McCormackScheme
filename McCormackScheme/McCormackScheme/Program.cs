using System;
internal class WSPCalculator
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the McCormack Scheme Console App");

        Console.WriteLine("What is the bed slope?");
        double bedSlope = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("What is Manning's N?");
        double n = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("What is the initial velocity?");
        double initialVelocity = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("What is the channel bottom width?");
        double bottomWidth = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("What is the bank slope?");
        double bankSlope = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("What is the initial Depth?");
        double initialDepth = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("What is the gravitational constant?");
        double g = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("What is the time step?");
        int timeStep = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("What is the computational interval of distance?");
        double distanceStep = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("What is the simulation time period?");
        double totalTime = Convert.ToDouble(Console.ReadLine());

        WSPCalculator calculator = new WSPCalculator(initialVelocity, n, bedSlope, bankSlope, bottomWidth, initialDepth, g, timeStep, distanceStep, totalTime);

        Console.WriteLine("Done.");
    }

    #region Fields 
    #endregion

    #region Properties
    double InitialVelocity { get; }
    double ManningsN { get; }
    double BedSlope { get; }
    double BankSlopeHorizontalToOne { get; }
    double BottomWidth { get; }
    double InitialDepth { get; }
    double GravitationalConstant { get; }
    int TimeStep { get; }
    double DistanceStep { get; }
    double TotalTime { get; }

    #endregion

    #region Constructor 

    public WSPCalculator(double velocity, double manningsN, double bedSlope, double horizontalToONe, double bottomWidth, double initialDepth, double g, int timeStep, double distanceStep, double totalTime)
    {
        InitialVelocity = velocity;
        ManningsN = manningsN;
        BedSlope = bedSlope;
        BankSlopeHorizontalToOne = horizontalToONe;
        BottomWidth = bottomWidth;
        InitialDepth = initialDepth;
        GravitationalConstant = g;
        TimeStep = timeStep;
        DistanceStep = distanceStep;
        TotalTime = totalTime;
    }

    #endregion

    #region Methods
    public void ComputeWSPs()
    {

    }

    #endregion
}