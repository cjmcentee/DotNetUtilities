using System;
using System.Windows.Forms;

namespace StandardLibraryExtensions
{
    public static class KeysExtensions
    {
        public static Keys KeyFromString(string s)
        {
            s = s.ToLower();

            if (s.Equals("a"))          return Keys.A;
            if (s.Equals("b"))          return Keys.B;
            if (s.Equals("c"))          return Keys.C;
            if (s.Equals("d"))          return Keys.D;
            if (s.Equals("e"))          return Keys.E;
            if (s.Equals("f"))          return Keys.F;
            if (s.Equals("g"))          return Keys.G;
            if (s.Equals("h"))          return Keys.H;
            if (s.Equals("i"))          return Keys.I;
            if (s.Equals("j"))          return Keys.J;
            if (s.Equals("k"))          return Keys.K;
            if (s.Equals("l"))          return Keys.L;
            if (s.Equals("m"))          return Keys.M;
            if (s.Equals("n"))          return Keys.N;
            if (s.Equals("o"))          return Keys.O;
            if (s.Equals("p"))          return Keys.P;
            if (s.Equals("q"))          return Keys.Q;
            if (s.Equals("r"))          return Keys.R;
            if (s.Equals("s"))          return Keys.S;
            if (s.Equals("t"))          return Keys.T;
            if (s.Equals("u"))          return Keys.U;
            if (s.Equals("v"))          return Keys.V;
            if (s.Equals("w"))          return Keys.W;
            if (s.Equals("x"))          return Keys.X;
            if (s.Equals("y"))          return Keys.Y;
            if (s.Equals("z"))          return Keys.Z;
            if (s.Equals("0"))          return Keys.D0;
            if (s.Equals("1"))          return Keys.D1;
            if (s.Equals("2"))          return Keys.D2;
            if (s.Equals("3"))          return Keys.D3;
            if (s.Equals("4"))          return Keys.D4;
            if (s.Equals("5"))          return Keys.D5;
            if (s.Equals("6"))          return Keys.D6;
            if (s.Equals("7"))          return Keys.D7;
            if (s.Equals("8"))          return Keys.D8;
            if (s.Equals("9"))          return Keys.D9;

            throw new ArgumentException("The value " + s + " is not a recognized Key.");
        }
    }
}
