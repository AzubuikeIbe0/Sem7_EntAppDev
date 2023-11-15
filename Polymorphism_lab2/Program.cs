using System;
using System.Runtime.CompilerServices;

namespace Polymorphism_lab2
{

    public class Vertex
    {
        public int y;
        public int x;

        public Vertex(int y, int x)
        {
            this.y = y;
            this.x = x;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public override string ToString()
        {
            return $"Y-Axis: {Y} X-Axis: {X}";
        }
    }

    public enum Colors 
    {   
        red, 
        green, 
        blue
    }

    public abstract class Shape
    {
        private Colors color;


        protected Shape(Colors color)
        {
              this.color = color;
        }

        public Colors Color
        {
            get { return color; }
            set { color = value; }
        }

        public abstract void Translate(Vertex amount);
        
        public override string ToString()
        {
            return $"A {color} shape";
        }
    }

    public class Line: Shape
    {
        private readonly Vertex v1, v2;

        public Line(int x1, int y1, int x2, int y2, Colors c) : base(c)
        {
            this.v1 = new Vertex(x1, y1);
            this.v2 = new Vertex(x1, y2);
        }

        public int X1
        {
            get 
            { 
                return this.v1.X; 
            }
            set 
            { 
                this.v1.X = value; 
            }
        }

        public int X2
        {
            get
            {
                return this.v2.X;
            }
            set 
            { 
                this.v2.X = value; 
            }
        }

        public int Y2
        {
            get
            {
                return this.v2.Y;
            }
            set
            {
                this.v2.Y = value;
            }
        }

        public int Y1
        {
            get
            {
                return this.v1.Y;
            }
            set
            {
                this.v1.Y = value;
            }
        }

        public override string ToString()
        {
            return $"A {Color} Line from ({X1}, {Y1}, to ({X2}, {Y2}))";
        }

        public override void Translate(Vertex amount)
        {
            v1.X += amount.X;
            v2.X += amount.X;
            v1.Y += amount.Y;
            v2.Y += amount.Y;
        }
    }


    public class Circle: Shape
    {
        private Vertex v1;
        private double radius;

        public Circle(int x, int y, double radius, Colors c) : base(c)
        {
            this.radius = radius;
            this.v1 = new Vertex(x, y);
        }

        public int X
        {
            get
            {
                return this.v1.X;
            }
            set
            {
                this.v1.X = value;
            }
        }

        public int Y
        {
            get
            {
                return this.v1.Y;
            }
            set
            {
                this.v1.Y = value;
            }
        }

        public override string ToString()
        {
            return $"A {Color} Circle of Radius: {radius}, from {v1}";
        }

        public override void Translate(Vertex amount)
        {
            v1.X += amount.X;
            v1.Y += amount.Y;
        }

        public double Area()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

    }

    
}