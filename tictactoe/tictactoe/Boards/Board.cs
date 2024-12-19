﻿using TicTacToe.Display;
using TicTacToe.Players;

namespace TicTacToe.Boards;

public class Board
{
    private readonly IDisplay display;
    private readonly List<Cell> grid;

    public Board(IDisplay display)
    {
        grid = EmptyGrid;
        this.display = display;
    }

    private List<Cell> EmptyGrid =>
        new()
        {
            Cell.EmptyCell(1, 1),
            Cell.EmptyCell(1, 2),
            Cell.EmptyCell(1, 3),
            Cell.EmptyCell(2, 1),
            Cell.EmptyCell(2, 2),
            Cell.EmptyCell(2, 3),
            Cell.EmptyCell(3, 1),
            Cell.EmptyCell(3, 2),
            Cell.EmptyCell(3, 3)
        };

    public bool PlayMoveOnBoard(RandomPlayerMove randomPlayerMoves, char currentPlayerIcon)
    {
        var cell = GetCell(randomPlayerMoves.Row, randomPlayerMoves.Column);

        if (cell == null || cell.Value == PlayerConstants.PlayerOneIcon || cell.Value == PlayerConstants.PlayerTwoIcon)
            return false;

        cell.UpdateValue(currentPlayerIcon);
        return true;
    }

    public GameResult IsGameOver()
    {
        if (IsGameBoardWin()) return GameResult.WIN;
        if (IsGameBoardFull()) return GameResult.DRAW;

        return GameResult.NONE;
    }

    public void DisplayGameBoard()
    {
        display.Clear();
        DisplayHeader();
        DisplayBoard();
    }

    private void DisplayHeader()
    {
        display.WriteLine(new string('=', display.Width));
        display.WriteLine(".NET M2I".PadLeft(display.Width / 2));
        display.WriteLine(new string('=', display.Width));
    }

    private void DisplayBoard()
    {
        display.WriteLine("|-----|-----|-----|");
        DisplayGameBoardLine(1);
        display.WriteLine("|-----|-----|-----|");
        DisplayGameBoardLine(2);
        display.WriteLine("|-----|-----|-----|");
        DisplayGameBoardLine(3);
        display.WriteLine("|-----|-----|-----|");
    }

    private void DisplayGameBoardLine(int row)
    {
        display.WriteLine($"|  {GetCellContent(row, 1)}  |  {GetCellContent(row, 2)}  |  {GetCellContent(row, 3)}  |");
    }

    private char GetCellContent(int row, int column)
    {
        return GetCell(row, column)?.Value ?? ' ';
    }

    private Cell? GetCell(int row, int column)
    {
        return grid
            .Where(cell => cell.Row == row)
            .Where(cell => cell.Column == column)
            .FirstOrDefault();
    }

    private bool IsGameBoardWin()
    {
        var rows = grid
            .GroupBy(cell => cell.Row);

        if (rows.Any(row =>
                row.All(cell => cell.Value == PlayerConstants.PlayerOneIcon) ||
                row.All(cell => cell.Value == PlayerConstants.PlayerTwoIcon)))
            return true;

        var columns = grid
            .GroupBy(cell => cell.Column);

        if (columns.Any(column =>
                column.All(cell => cell.Value == PlayerConstants.PlayerOneIcon) ||
                column.All(cell => cell.Value == PlayerConstants.PlayerTwoIcon)))
            return true;

        var firstDiagonal = grid.Where(c => c.Row == c.Column);
        var secondDiagonal = grid.Where(c => c.Row + c.Column == 4);

        var diagonals = new List<IEnumerable<Cell>>
        {
            firstDiagonal,
            secondDiagonal
        };

        if (diagonals.Any(diagonal =>
                diagonal.All(cell => cell.Value == PlayerConstants.PlayerOneIcon) ||
                diagonal.All(cell => cell.Value == PlayerConstants.PlayerTwoIcon)))
            return true;

        return false;
    }

    private bool IsGameBoardFull()
    {
        return grid.All(cell => cell.Value.HasValue);
    }
}