using System;

namespace MathExtensions
{
    public class GridLocation
    {
        public readonly int NumberRows, NumberColumns, CurrentRow, CurrentColumn;

        ////////////////////////////////////////////////
        //               Constructors
        ////////////////////////////////////////////////
        public GridLocation(int numberRows, int numberColumns, int currentRow, int currentColumn) {
            if (currentRow >= numberRows)
                throw new IndexOutOfRangeException(String.Format(
                    "Current row ({0}) greater than max number of rows ({1}).",
                    currentRow, numberRows
                    ));
            if (currentColumn >= numberColumns)
                throw new IndexOutOfRangeException(String.Format(
                    "Current column ({0}) greater than max number of columns ({1}).",
                    currentColumn, numberColumns
                    ));

            this.NumberRows = numberRows;
            this.NumberColumns = numberColumns;
            this.CurrentRow = currentRow;
            this.CurrentColumn = currentColumn;
        }

        public override string ToString() {
            return String.Format("[{1}/{0}, {3}/{2}]", NumberRows, CurrentRow, NumberColumns, CurrentColumn);
        }
    }
}
