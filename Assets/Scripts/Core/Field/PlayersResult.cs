using System.Collections.Generic;
using UnityEngine;

namespace Core.Field
{
    public class PlayersResult
    {
        private readonly int _fieldSize;
        public readonly int _playersCount;
        private List<int[]> rowContainers;
        private List<int[]> columnsContainers;
        private List<int[]> diagonalContainers;
        private List<int[]> oppositeDiagonalContainers;
        

        public PlayersResult(int fieldSize, int playersCount)
        {
            _fieldSize = fieldSize;
            _playersCount = playersCount;

            rowContainers = new List<int[]>();
            for (int i = 0; i < _playersCount; i++)
            {
                rowContainers.Add(new int[_fieldSize]);
            }
            
            columnsContainers = new List<int[]>();
            for (int i = 0; i < _playersCount; i++)
            {
                columnsContainers.Add(new int[_fieldSize]);
            }
            
            diagonalContainers = new List<int[]>();
            for (int i = 0; i < _playersCount; i++)
            {
                diagonalContainers.Add(new int[_fieldSize]);
            }
            
            oppositeDiagonalContainers = new List<int[]>();
            for (int i = 0; i < _playersCount; i++)
            {
                oppositeDiagonalContainers.Add(new int[_fieldSize]);
            }
        }

        public void MakeMark(int column, int row, int currentPlayer)
        {
            rowContainers[currentPlayer][row] += 1;
            columnsContainers[currentPlayer][column] += 1;
            
            if (row == column)
            {
                diagonalContainers[currentPlayer][row] += 1;
            }
    
            if (row + column + 1 == _fieldSize)
            {
                oppositeDiagonalContainers[currentPlayer][row] += 1;
            }

            CheckWin(column, row, currentPlayer);
        }

        private void CheckWin(int column, int row, int currentPlayer)
        {
            
            if (rowContainers[currentPlayer][row] == _fieldSize)
            {
                Debug.Log("WIN PLAYER " + currentPlayer);
            }
            
            if (columnsContainers[currentPlayer][column] == _fieldSize)
            {
                Debug.Log("WIN PLAYER " + currentPlayer);
            }

            var sumForRegularDiagonalElements = 0;
            var sumForOppositeDiagonalElements = 0;

            for (int i = 0; i < diagonalContainers[currentPlayer].Length; i++)
            {
                sumForRegularDiagonalElements += diagonalContainers[currentPlayer][i];
            }

            if (sumForRegularDiagonalElements == _fieldSize)
            {
                Debug.Log("WIN PLAYER " + currentPlayer);
            }
            
            for (int i = 0; i < oppositeDiagonalContainers[currentPlayer].Length; i++)
            {
                sumForOppositeDiagonalElements += oppositeDiagonalContainers[currentPlayer][i];
            }

            if (sumForOppositeDiagonalElements == _fieldSize)
            {
                Debug.Log("WIN PLAYER " + currentPlayer);
            }
        }
    }
}