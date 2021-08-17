using System;

namespace MathematicalAlgorithms
{
    /// <summary>
    /// Generic class T type for storing diagonal matrix data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        private const int ROWS = 1;

        /// <summary>
        /// The indexer takes two parameters, allows access to the array through the i index
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public override T this[int i, int j]
        {
            get
            {
                SetChecks(i, j);
                return _arraySquare[i];
            }

            set
            {
                SetChecks(i, j);
                var oldValue = _arraySquare[i];

                DoEvent(i, j, oldValue, value);
                _arraySquare[i] = value;
            }
        }

        /// <summary>
        /// A constructor without initialization, allows you to access the constructor of the base class. Passing the dimension of the diagonal matrix
        /// </summary>
        /// <param name="matrixSize"></param>
        public DiagonalMatrix(int matrixSize) : base(ROWS, matrixSize)
        {
        }

        /// <summary>
        /// The method takes two parameters, implements a check for inequality i and j indices
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public override void SetChecks(int i, int j)
        {
            base.SetChecks(i, j);

            if (i != j)
            {
                throw new ArgumentException("Ошибка! Индексы должны быть равны между собой!");
            }
        }
    }
}
