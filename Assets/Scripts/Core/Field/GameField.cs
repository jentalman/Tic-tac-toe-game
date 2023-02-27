using Core.Field.Cells;
using UnityEngine;
using Zenject;

namespace Core.Field
{
    public class GameField : MonoBehaviour
    {
        private GameSettings _gameSettings;
        private PlayersResult _playersResult;
        private Cell[] _field;
        private int _currentPlayer;

        [Inject]
        public void Construct(GameSettings gameSettings, PlayersResult playersResult)
        {
            _gameSettings = gameSettings;
            _playersResult = playersResult;
            _field = new Cell[_gameSettings.Size];
        }

        public void GenerateGameField()
        {
            var startPos = _gameSettings.StartPos;
            int column = 0;
            int row = 0;

            for (int i = 0; i < _gameSettings.Size; i++)
            {
                var cell = Instantiate(_gameSettings.CellPrefab, startPos, Quaternion.identity, this.transform);

                cell.Index = i;
                cell.Row = row;
                cell.Column = column;
                cell.OnClick += MakeMark;
                _field[i] = cell;

                startPos.x -= _gameSettings.XOffset;
                row++;

                if (row == _gameSettings.Row)
                {
                    row = 0;
                    column++;
                    startPos.x = _gameSettings.StartPos.x;
                    startPos.y += _gameSettings.YOffset;
                }
            }
        }

        private void MakeMark(int column, int row, int cellIndex)
        {
            _playersResult.MakeMark(column, row, _currentPlayer);
            DrawFigureInCell(cellIndex);
            
            _currentPlayer++;
            
            if (_currentPlayer == _playersResult._playersCount)
            {
                _currentPlayer = 0;
            }
            
        }

        private void DrawFigureInCell(int cellIndex)
        {
            _field[cellIndex].DrawFigure(_currentPlayer);
        }

        private void OnDisable()
        {
            foreach (var cell in _field)
            {
                cell.OnClick -= MakeMark;
            }
        }
    }
}
