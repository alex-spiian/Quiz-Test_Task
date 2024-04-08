using AnswerHandler;
using Card;
using Level;
using Provider;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private TaskGenerator _taskGenerator;
    [FormerlySerializedAs("_cellSpawner")] [SerializeField] private CardSpawner cardSpawner;
    [SerializeField] private ColorProvider _colorProvider;
    [SerializeField] private RightAnswerView _rightAnswerView;
    [SerializeField] private LevelSpawner _levelSpawner;
    [SerializeField] private GameEndHandler _gameEndHandler;

    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<CardFactory>(Lifetime.Singleton);
        builder.Register<PositionsGenerator.PositionsGenerator>(Lifetime.Singleton);
        builder.Register<AnswerHandler.AnswerHandler>(Lifetime.Singleton);

        builder.RegisterInstance(_taskGenerator);
        builder.RegisterInstance(cardSpawner);
        builder.RegisterInstance(_colorProvider);
        builder.RegisterInstance(_rightAnswerView);
        builder.RegisterInstance(_levelSpawner);
        builder.RegisterInstance(_gameEndHandler);
    }
}
