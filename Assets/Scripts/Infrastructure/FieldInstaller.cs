using Core.Field;
using Core.Field.Cells;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class FieldInstaller: MonoInstaller
    {
        [SerializeField] private float xOffset;
        [SerializeField] private float yOffset;
        [SerializeField] private int size;
        [SerializeField] private int playersCount;
        [SerializeField] private Vector2 startPos;
        [SerializeField] private Cell cellPrefab;
        [SerializeField] private GameField gameField;

        private PlayersResult _playersResult;

        public override void InstallBindings()
        {
            BindFieldGenerator();
            BindFieldSettings();
            BindPlayersResult();
        }

        private void BindPlayersResult()
        {
            Container
                .Bind<PlayersResult>()
                .FromNew()
                .AsSingle()
                .WithArguments(size, playersCount);
        }

        private void BindFieldGenerator()
        {
            Container
                .Bind<GameField>()
                .FromInstance(gameField)
                .AsSingle();
        }

        private void BindFieldSettings()
        {
            Container
                .Bind<GameSettings>()
                .FromNew()
                .AsSingle()
                .WithArguments(xOffset, yOffset, size, size, startPos, cellPrefab);
        }
    }
}