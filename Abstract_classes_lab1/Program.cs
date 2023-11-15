using System;

namespace Abstract_classes_lab1
{
    public abstract class ThreeDs
    {
        private string type;


        protected ThreeDs(string type)
        {
            this.type = type;
        }


        public string Type { get { return type; } }


        public abstract double CalcVol();

        public override string ToString()
        {
            return $"A {type} shape";
        }


    }

    public class Sphere : ThreeDs
    {
        private double radius;

        public Sphere(double radius) : base("Sphere")
        {
            this.radius = radius;
        }

        public Sphere() : this(0) { }

        public double Radius { 
            get 
            { 
                if(radius <= 0)
                {
                    throw new ArgumentException("Radius cannot be 0");
                }
                return radius;
            } 
        }

        public override double CalcVol()
        {
            double volume = (4 / 3) * Math.PI * Math.Pow(radius, 3);
            return Math.Round(volume, 2);
        }


        public override string ToString()
        {
            return base.ToString() + $"\nRadius: {radius}\nVolume: {CalcVol()}";
        }
    }
}