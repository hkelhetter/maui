namespace puissance4.board;

public class Board
{
    public List<List<Cell>> Cells { get; init; }
    public int ColumnLenght { get; } = 6;
    public int RowLenght { get; } = 7;
    public Board()
    {
        Cells = new List<List<Cell>>();
        for (int i = 0; i < ColumnLenght; i++)
        {
            List<Cell> row = new List<Cell>();
            for (int j = 0; j < RowLenght; j++)
            {
                row.Add(new Cell());
            }
            Cells.Add(row);
        }
        this.Cells = Cells;
    }
    
    public bool PlaceToken(int column, char icon)
    {
        if(column < 0 || column > ColumnLenght - 1)
        {
            return false;
        }
        
        for (int i = 5; i >= 0; i--)
        {
            if (Cells[i][column].Value == '\0')
            {
                Cells[i][column].Value = icon;
                return true;
            }
        }

        return false;
    }

}