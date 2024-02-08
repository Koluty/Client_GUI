using System;

namespace Client_GUI
{
    internal class Calculate_value
    {
        double b;
        double c;
        public double B { get { return b; } set { b = value < 0 ? -Math.Pow(-value, 1.0 / 3.0) : Math.Pow(value, 1.0 / 3.0); } }
        public double C { get { return c; } set { c = Math.Cos(value * (Math.PI/8)); } }
    }
}
