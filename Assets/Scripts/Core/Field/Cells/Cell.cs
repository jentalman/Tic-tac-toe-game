using System;
using UnityEngine;

namespace Core.Field.Cells
{
    public class Cell : MonoBehaviour
    {
        public int Index { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public event Action<int, int, int> OnClick;
        
        private bool _isClicked;
        
        public void DrawFigure(int playerNum)
        {
            var childCount = gameObject.transform.childCount;
            if (childCount <= playerNum)
            {
                throw new Exception("Нет картинки для игрока");
            }
            var figure = gameObject.transform.GetChild(playerNum);
            figure.gameObject.SetActive(true);
        }
        
        private void OnMouseDown()
        {
            if (_isClicked) 
                return;

            _isClicked = true;
            OnClick?.Invoke(Column, Row, Index);
        }
    }
}
