using Core.Field.Cells;
using UnityEngine;

namespace Core.Field
{
    public class GameSettings
    {
        public float XOffset{ get; }
        public float YOffset { get; }
        public int Column { get; }
        public int Row { get; }
        public Vector2 StartPos { get; }
        public Cell CellPrefab { get; }

        public int Size => Row * Column;

        public GameSettings(float xOffset, float yOffset, int column, int row, Cell cellPrefab, Vector2 startPos)
        {
            XOffset = xOffset;
            YOffset = yOffset;
            Column = column;
            Row = row;
            StartPos = startPos;
            CellPrefab = cellPrefab;
        }
    }
}