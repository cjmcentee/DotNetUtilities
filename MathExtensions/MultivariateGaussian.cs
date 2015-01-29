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
        public readonly int Dimensions;
        private List<double[]> points;

        public double[] Mean       { get; private set; } // dimensions            in length, vector
        public double[] Covariance { get; private set; } // dimensions*dimensions in length, matrix

        public MultivariateGaussian(int dimensions) {
            this.Dimensions = dimensions;
            this.points = new List<double[]>();

            Mean = new double[dimensions];
            Covariance = new double[dimensions*dimensions];
        }

        public MultivariateGaussian(IEnumerable<double[]> points) {
            this.Dimensions = points.First().Count();
            AddPointsToModel(points);
        }

        public double CalculateDensityOf(double[] value) {
            if (value.Count() != Dimensions)
                throw new IncorrectDimensionsException(value.Count(), this.Dimensions);

            var valueVector = new DenseVector(value);
            var meanVector = new DenseVector(Mean.ToArray());
            var covarianceMatrix = new DenseMatrix(Dimensions, Dimensions, Covariance);
            
            double covarianceDeterminant = covarianceMatrix.Determinant();
            double dofFactor = 1 / Math.Sqrt(Math.Pow(2*Math.PI, Dimensions) * covarianceDeterminant);

            var meanDifference = valueVector.Subtract(meanVector);
            var inverseCovarianceMatrix = covarianceMatrix.Inverse();
            var meanDistanceMeasure = -0.5 * inverseCovarianceMatrix.Multiply(meanDifference).DotProduct(meanDifference);

            return dofFactor * Math.Exp(meanDistanceMeasure);
        }

        public void AddPointToModel(double[] point) {
            if (point.Count() != Dimensions)
                throw new IncorrectDimensionsException(point.Count(), this.Dimensions);

            points.Add(point);
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
            this.points.AddRange(points);
            RecalculateMean();
            RecalculateCovariance();
        }

        private void RecalculateMean() {
            Mean = AveragePoints(this.points);
        }

        private void RecalculateCovariance() {
            for (int i = 0; i < Dimensions; i++) {
                double ithMean = DimensionAverage(i, points);
                for (int j = 0; j < Dimensions; j++) {
                    double jthMean = DimensionAverage(j, points);
                    Covariance[i * Dimensions + j] = CalculateCovariance(ithMean, i, jthMean, j, this.points);
                }
            }
        }

        private static double DimensionAverage(int dimension, IEnumerable<double[]> points) {
            double sum = points.Aggregate(0.0, (acc, p) => acc + p[dimension]);
            double average = sum / points.Count();
            return average;
        }

        private static double CalculateCovariance(double ithMean, int ithDimension, double jthMean, int jthDimension, IEnumerable<double[]> points) {
            var ithDifferenceFromMean = points.Select(p => p[ithDimension] - ithMean);
            double ithDifferenceSum = ithDifferenceFromMean.Sum();

            var jthDifferenceFromMean = points.Select(p => p[jthDimension] - jthMean);
            double jthDifferenceSum = jthDifferenceFromMean.Sum();

            double ijCovariance = ithDifferenceSum * jthDifferenceSum / points.Count();
            return ijCovariance;
        }

        private static double[] AveragePoints(IEnumerable<double[]> points) {
            int dimensions = points.First().Count();
            
            // Do the average operation
            double[] average = new double[dimensions];
            // Sum the vectors up
            foreach (double[] point in points)
                for (int j = 0; j < average.Count(); j++)
                    average[j] += point[j];
            // Divide each entry of the vector sum by the length for the average
            for (int i = 0; i < average.Count(); i++)
                average[i] /= points.Count();
            return average;
        }
    }
}
