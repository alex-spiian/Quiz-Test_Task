using System;
using Card;
using UnityEngine;
using VContainer;

namespace Level
{
    public class LevelSpawner : MonoBehaviour
    {
        public Action LevelReset;
        [SerializeField]
        private LevelConfig[] _levelConfigs;
        
        private GameEndHandler _gameEndHandler;
        private AnswerHandler.AnswerHandler _answerHandler;
        private TaskGenerator _taskGenerator;
        private CardSpawner _cardSpawner;
        private PositionsGenerator.PositionsGenerator _positionsGenerator;
        private int _currentIndex;

        [Inject]
        public void Construct(TaskGenerator taskGenerator, CardSpawner cardSpawner,
            PositionsGenerator.PositionsGenerator positionsGenerator, AnswerHandler.AnswerHandler answerHandler,
            GameEndHandler gameEndHandler)
        {
            _gameEndHandler = gameEndHandler;
            _answerHandler = answerHandler;
            _taskGenerator = taskGenerator;
            _cardSpawner = cardSpawner;
            _positionsGenerator = positionsGenerator;
        }
        public void Spawn()
        {
            var rows = _levelConfigs[_currentIndex].RowsCount;
            var columns = _levelConfigs[_currentIndex].ColumnsCount;
            var spacing = _levelConfigs[_currentIndex].Spacing;
            
            var task = _taskGenerator.Generate(rows * columns);
            _answerHandler.Initialize(task.RightAnswer.Identifire, OnLevelCompleted);
            var positions = _positionsGenerator.Get(rows, columns, spacing, Vector3.one);
            
            _cardSpawner.Spawn(rows * columns, task, positions, _currentIndex == 0);
        }

        private void OnLevelCompleted()
        {
            _currentIndex++;
            if (_currentIndex == _levelConfigs.Length)
            {
                _gameEndHandler.OnGameCompleted();
                return;
            }
            
            Spawn();
        }

        public void Reset()
        {
            _currentIndex = 0;
            _cardSpawner.Reset();
            LevelReset?.Invoke();
        }
    }
}