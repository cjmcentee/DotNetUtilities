using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtensions
{
    public struct Direction
    {
        public static readonly Direction ZERO   = new Direction(0, 0);
        public static readonly Direction ONE    = new Direction(1, 1);
        public static readonly Direction X_AXIS = new Direction(1, 0);
        public static readonly Direction Y_AXIS = new Direction(0, 1);

        public int X, Y;

        public double Length
        {
            get
            {
                return Math.Sqrt(X * X + Y * Y);
            }
        }

        public double LengthSquared
        {
            get
            {
                return X * X + Y * Y;
            }
        }

        public Direction(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Direction))
                return false;
            
            Direction direction = (Direction) obj;
            if (direction == null)
                return false;

            return this.X == direction.X && this.Y == direction.Y;
        }

        public bool Equals(Direction direction)
        {
            if (direction == null)
                return false;

            return this.X == direction.X && this.Y == direction.Y;
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public override string ToString()
        {
            return "{" + X + ", " + Y + "}";
        }

        public void Negate()
        {
            X = -X;
            Y = -Y;
        }

        public Direction Copy()
        {
            return new Direction(X, Y);
        }

        public Direction Parse(String s)
        {
            Point point = (Point)(new PointConverter()).ConvertFromString(s);
            return new Direction(point.X, point.Y);
        }

        public static Direction Add(Direction summand, Direction addend)
        {
            return new Direction(summand.X + addend.X, summand.Y + addend.Y);
        }

        public static Point Add(Point point, Direction direction)
        {
            return new Point(point.X + direction.X, point.Y + direction.Y);
        }

        public static Direction Subtract(Direction minuend, Direction subtrahend)
        {
            return new Direction(minuend.X - subtrahend.X, minuend.Y - subtrahend.Y);
        }

        public static Point Subtract(Point point, Direction direction)
        {
            return new Point(point.X - direction.X, point.Y - direction.Y);
        }

        public static Direction Multiply(Direction direction, double scalar)
        {
            return new Direction((int)(direction.X * scalar), (int)(direction.Y * scalar));
        }

        public static Direction Multiply(Direction direction, int scalar)
        {
            return new Direction(direction.X * scalar, direction.Y * scalar);
        }

        public static Direction Divide(Direction direction, double scalar)
        {
            return new Direction((int)(direction.X / scalar), (int)(direction.Y / scalar));
        }

        public static Direction Divide(Direction direction, int scalar)
        {
            return new Direction(direction.X / scalar, direction.Y / scalar);
        }

        public static Direction operator +(Direction summand, Direction addend)
        {
            return Add(summand, addend);
        }

        public static Point operator +(Point point, Direction direction)
        {
            return Add(point, direction);
        }

        public static Direction operator -(Direction minuend, Direction subtrahend)
        {
            return Subtract(minuend, subtrahend);
        }

        public static Point operator -(Point point, Direction direction)
        {
            return Subtract(point, direction);
        }

        public static Direction operator *(Direction direction, double scalar)
        {
            return Direction.Multiply(direction, scalar);
        }

        public static Direction operator *(Direction direction, int scalar)
        {
            return Direction.Multiply(direction, scalar);
        }

        public static Direction operator /(Direction direction, double scalar)
        {
            return Direction.Divide(direction, scalar);
        }

        public static Direction operator /(Direction direction, int scalar)
        {
            return Direction.Divide(direction, scalar);
        }

        public static bool operator ==(Direction direction1, Direction direction2)
        {
            if (System.Object.ReferenceEquals(direction1, direction2))
                return true;

            if (direction1 == null || direction2 == null)
                return false;

            return direction1.X == direction2.X && direction1.Y == direction2.Y;
        }

        public static bool operator !=(Direction direction1, Direction direction2)
        {
            return !(direction1 == direction2);
        }

        public static Direction operator -(Direction direction)
        {
            return new Direction(-direction.X, -direction.Y);
        }

        public static implicit operator Point(Direction direction)
        {
            return new Point(direction.X, direction.Y);
        }

        public static implicit operator Direction(Point point)
        {
            return new Direction(point.X, point.Y);
        }
    }
}
