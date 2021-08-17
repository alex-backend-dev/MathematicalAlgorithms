using System;

namespace MathematicalAlgorithms
{
    /// <summary>
    /// Generic class T type for storing square matrix data
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SquareMatrix<T>
    {
        public delegate void ChangeElement(int i, int j, T oldValue, T newValue);

        public event ChangeElement ChangeElementEvent;

        protected T[] _arraySquare;

        /// <summary>
        /// The method accepts four parameters, a wrapper for the ChangeElementEvent event
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        public void DoEvent(int i, int j, T oldValue, T newValue)
        {
            if (ChangeElementEvent != null && !newValue.Equals(oldValue))
            {
                ChangeElementEvent(i, j, oldValue, newValue);
            }
        }

        public int MatrixSize { get; }

        /// <summary>
        /// Constructor without initialization, allows to refer to the SquareMatrix constructor
        /// </summary>
        /// <param name="matrixSize"></param>
        public SquareMatrix(int matrixSize) : this(matrixSize, matrixSize)
        {
        }

        /// <summary>
        /// The constructor takes two parameters, initialize the dimension of the square matrix
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        protected SquareMatrix(int rows, int columns)
        {
            if (rows < 0 || columns < 0)
            {
                throw new ArgumentException("Ошибка! Размерность не может быть отрицательной!");
            }

            MatrixSize = columns;
            _arraySquare = new T[MatrixSize * MatrixSize];
        }

        /// <summary>
        /// The indexer takes two parameters, allows access to the array through the k index
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns> Returns an array variable, allows access to an array </returns>
        public virtual T this[int i, int j]
        {
            get
            {
                SetChecks(i, j);
                var k = ConvertIndexMatrixToArrayIndex(i, j);
                return _arraySquare[k];
            }

            set
            {

                SetChecks(i, j);
                var k = ConvertIndexMatrixToArrayIndex(i, j);

                var oldValue = _arraySquare[k];
                DoEvent(i, j, oldValue, value);
                _arraySquare[k] = value;
            }
        }

        /// <summary>
        /// The method takes two parameters, allows to calculate the required element of the array 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns> Returns the required element of the array </returns>
        private int ConvertIndexMatrixToArrayIndex(int i, int j)
        {
            return i * MatrixSize + j;
        }

        /// <summary>
        /// The method takes two parameters, implements a check for entering negative indices
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public virtual void SetChecks(int i, int j)
        {
            if (i < 0 || j < 0)
            {
                throw new IndexOutOfRangeException("Ошибка! Индексы не должны быть отрицательными!");
            }
        }
    }
}
