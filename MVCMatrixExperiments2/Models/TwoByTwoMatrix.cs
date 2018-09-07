using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCMatrixExperiments2.Models
{
    public class TwoByTwoMatrix
    {
        private double _element00;
        private double _element01;
        private double _element10;
        private double _element11;

        public TwoByTwoMatrix() : this(0, 0, 0, 0)
        {
        }

        public TwoByTwoMatrix(double element00, double element01,
                                double element10, double element11)
        {
            _element00 = element00;
            _element01 = element01;
            _element10 = element10;
            _element11 = element11;
        }

        [Required(ErrorMessage = "A value for Element00 is required.")]
        public double Element00 { get { return _element00; } set { _element00 = value; } }
        [Required(ErrorMessage = "A value for Element01 is required.")]
        public double Element01 { get { return _element01; } set { _element01 = value; } }
        [Required(ErrorMessage = "A value for Element10 is required.")]
        public double Element10 { get { return _element10; } set { _element10 = value; } }
        [Required(ErrorMessage = "A value for Element11 is required.")]
        public double Element11 { get { return _element11; } set { _element11 = value; } }

        public double GetDeterminant()
        {
            double determinant = (Element00 * Element11) - (Element01 * Element10);
            return determinant;
        }

        public TwoByTwoMatrix GetInverse()
        {
            double determinant = this.GetDeterminant();

            // Matrix with determinant 0 does not have an inverse matrix
            if (determinant == 0)
            {
                return null;
            }

            var inverseMatrix = new TwoByTwoMatrix(this.Element11 / determinant, 
                -this.Element01 / determinant, -this.Element10 / determinant, this.Element00 / determinant);
            return inverseMatrix;
        }

        public TwoByTwoMatrix Add(TwoByTwoMatrix secondMatrix)
        {
            var resultMatrix = new TwoByTwoMatrix(this.Element00 + secondMatrix.Element00,
                this.Element01 + secondMatrix.Element01, this.Element10 + secondMatrix.Element10,
                this.Element11 + secondMatrix.Element11);
            return resultMatrix;
        }

        public TwoByTwoMatrix Subtract(TwoByTwoMatrix secondMatrix)
        {
            var resultMatrix = new TwoByTwoMatrix(this.Element00 - secondMatrix.Element00,
                this.Element01 - secondMatrix.Element01, this.Element10 - secondMatrix.Element10,
                this.Element11 - secondMatrix.Element11);
            return resultMatrix;
        }

        public TwoByTwoMatrix Multiply(TwoByTwoMatrix secondMatrix)
        {
            double resultElement00 = (this.Element00 * secondMatrix.Element00) + (this.Element01 * secondMatrix.Element10);
            double resultElement01 = (this.Element00 * secondMatrix.Element01) + (this.Element01 * secondMatrix.Element11);
            double resultElement10 = (this.Element10 * secondMatrix.Element00) + (this.Element11 * secondMatrix.Element10);
            double resultElement11 = (this.Element10 * secondMatrix.Element01) + (this.Element11 * secondMatrix.Element11);

            var resultMatrix = new TwoByTwoMatrix(resultElement00, resultElement01,
                resultElement10, resultElement11);
            return resultMatrix;
        }
    }
}