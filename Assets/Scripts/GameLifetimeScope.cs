using AnswerHandler;
using Cell;
using Level;
using Provider;
using Task;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private TaskGenerator _taskGenerator;
    [SerializeField] private CellSpawner _cellSpawner;
    [SerializeField] private ColorProvider _colorProvider;
    [SerializeField] private RightAnswerView _rightAnswerView;
    [SerializeField] private LevelSpawner _levelSpawner;
    [SerializeField] private GameEndHandler _gameEndHandler;

    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<CellFactory>(Lifetime.Singleton);
        builder.Register<PositionsGenerator.PositionsGenerator>(Lifetime.Singleton);
        builder.Register<AnswerHandler.AnswerHandler>(Lifetime.Singleton);

        builder.RegisterInstance(_taskGenerator);
        builder.RegisterInstance(_cellSpawner);
        builder.RegisterInstance(_colorProvider);
        builder.RegisterInstance(_rightAnswerView);
        builder.RegisterInstance(_levelSpawner);
        builder.RegisterInstance(_gameEndHandler);
    }
}
