using Core.Field;
using UnityEngine;
using Zenject;

public class GameCore : MonoBehaviour
{
    private GameField _gameField;
    
    [Inject]
    public void Construct(GameField gameField)
    {
        _gameField = gameField;
    }
    
    private void Start()
    {
        _gameField.GenerateGameField();
    }
}
