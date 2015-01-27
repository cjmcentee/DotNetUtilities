using MathNet.Numerics.Distributions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtensions
{
    [Serializable]
    public class GaussianDistribution
    {
        private List<double> points;

        public double Mean { get; private set; }
        public double StandardDeviation { get; private set; }

        public GaussianDistribution()
            : this(new List<double>()) { }

        public GaussianDistribution(IEnumerable<double> points) {
            this.points = points.ToList();
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
