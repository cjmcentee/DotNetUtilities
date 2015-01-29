using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtensions
{
    public class IncorrectDimensionsException : ArgumentException
    {
        public IncorrectDimensionsException(int dimension1, int dimension2)
            : base("Dimensions of input vectors not consistent. Conflicting dimensions: " + dimension1 + " vs. " + dimension2) {}
    }

    [Serializable]
    public class MultivariateGaussian
    {
        private readonly int dimensions;
        private List<Vector<double>> points;

        public Vector<double> Mean { get; private set; }
        public Matrix<double> Covariance { get; private set; }

        public MultivariateGaussian(int dimensions) {
            this.dimensions = dimensions;
            this.points = new List<Vector<double>>();

            Mean = new DenseVector(dimensions);
            Covariance = new DenseMatrix(dimensions, dimensions);
        }

        public MultivariateGaussian(IEnumerable<double[]> points) {
            this.dimensions = points.First().Count();
            AddPointsToModel(points);
        }

        public double CalculateDensityOf(double[] value) {
            if (value.Count() != dimensions)
                throw new IncorrectDimensionsException(value.Count(), this.dimensions);

            var meanAsMatrix = new DenseMatrix(1, dimensions, Mean.ToArray());
            var columnCovariance = new DenseMatrix(1, 1, new double[]{1});
            var distribution = new MatrixNormal(meanAsMatrix, Covariance, columnCovariance);

            var valueAsMatrix = new DenseMatrix(1, dimensions, value);
            double density = distribution.Density(valueAsMatrix);
            
            return density;
        }

        public void AddPointToModel(double[] point) {
            if (point.Count() != dimensions)
                throw new IncorrectDimensionsException(point.Count(), this.dimensions);

            points.Add(new DenseVector(point));
            RecalculateMean();
            RecalculateCovariance();
        }

        public void AddPointsToModel(IEnumerable<double[]> points) {
            // Verify the vectors are all the same length
            int? dimensions = null;
            foreach (double[] point in points) {
                int currentDimension = point.Count();
                
                if ( ! dimensions.HasValue)
                    dimensions = currentDimension;

                if (dimensions.Value != currentDimension)
                    throw new IncorrectDimensionsException(dimensions.Value, currentDimension);
                dimensions = currentDimension;
            }

            // Update the model
            var vectorPoints = points.Select(p => new DenseVector(p));
            this.points.AddRange(vectorPoints);
            RecalculateMean();
            RecalculateCovariance();
        }

        private void RecalculateMean() {
            Mean = AveragePoints(this.points);
        }

        private void RecalculateCovariance() {
            for (int i = 0; i < dimensions; i++) {
                double ithMean = DimensionAverage(i, points);
                for (int j = 0; j < dimensions; j++) {
                    double jthMean = DimensionAverage(j, points);
                    Covariance[i, j] = CalculateCovariance(ithMean, i, jthMean, j, this.points);
                }
            }
        }

        private static double DimensionAverage(int dimension, IEnumerable<Vector<double>> points) {
            double sum = points.Aggregate(0.0, (acc, p) => acc + p[dimension]);
            double average = sum / points.Count();
            return average;
        }

        private static double CalculateCovariance(double ithMean, int ithDimension, double jthMean, int jthDimension, IEnumerable<Vector<double>> points) {
            var ithDifferenceFromMean = points.Select(p => p[ithDimension] - ithMean);
            double ithDifferenceSum = ithDifferenceFromMean.Sum();

            var jthDifferenceFromMean = points.Select(p => p[jthDimension] - jthMean);
            double jthDifferenceSum = jthDifferenceFromMean.Sum();

            double ijCovariance = ithDifferenceSum * jthDifferenceSum / points.Count();
            return ijCovariance;
        }

        private static Vector<double> AveragePoints(IEnumerable<Vector<double>> points) {
            Vector<double> sum = points.Aggregate((acc, p) => acc.Add(p));
            Vector<double> average = sum.Divide(points.Count());
            return average;
        }
    }
}
