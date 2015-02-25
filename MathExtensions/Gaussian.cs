using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Distributions;

namespace MathExtensions
{
    [Serializable]
    public class Gaussian
    {
        public List<double> points;

        public double Mean { get; set; }
        public double StandardDeviation { get; set; }

        public Gaussian() {
            points = new List<double>();
        }

        public Gaussian(IEnumerable<double> points) {
            points = new List<double>(points.Count());
            foreach (double point in points)
                AddPointToModel(point);
        }

        public double CalculatePValueOf(double value) {
            var normal = new Normal(Mean, StandardDeviation);
            double cumulativeLeft  = normal.CumulativeDistribution(value);
            double cumulativeRight = 1 - cumulativeLeft;
            double pValue = 2 * Math.Min(cumulativeLeft, cumulativeRight);

            return pValue;
        }

        public void AddPointToModel(double point) {
            points.Add(point);
            RecalculateMean();
            RecalculateStandardDevation();
        }

        private void RecalculateMean() {
            Mean = points.Average();
        }

        private void RecalculateStandardDevation() {
            var differenceFromMean =
                from point in points
                select Math.Abs(Mean - point);

            StandardDeviation = differenceFromMean.Average();
        }
    }
}
