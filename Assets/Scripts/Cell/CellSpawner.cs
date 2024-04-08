using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace Cell
{
    public class CellSpawner : MonoBehaviour
    {
        [SerializeField] private CellConfig _cellConfig;
        
        private CellFactory _cellFactory;
        private readonly List<Cell> _spawnedCells = new List<Cell>();

        [Inject]
        public void Construct(CellFactory cellFactory)
        {
            _cellFactory = cellFactory;
        }
        
        public void Spawn(int count, Task.Task task, List<Vector3> positions, bool isFirstLevel)
        {
            var neededCellsCount = 0;
            var spawnedCellsCount = _spawnedCells.Count;
            
            if (count > spawnedCellsCount)
            {
                neededCellsCount = count - spawnedCellsCount;
            }
            else
            {
                RemoveUnnecessaryCells(spawnedCellsCount - count);
            }
            
            for (int i = 0; i < neededCellsCount; i++)
            {
                var cell = _cellFactory.CreateCell(_cellConfig.Prefab);
                _spawnedCells.Add(cell);
            }
            
            SetValue(task, isFirstLevel);
            SetPositions(positions);
        }

        public void Reset()
        {
            foreach (var cell in _spawnedCells)
            {
                cell.Reset();
                Destroy(cell.gameObject);
            }
            _spawnedCells.Clear();
        }

        private void SetValue(Task.Task task, bool isFirstLevel)
        {
            foreach (var cell in _spawnedCells)
            {
                var cardData = task.GetAnswerOption();
                cell.Initialize(cardData.Sprite, cardData.Identifire);
                
                if (isFirstLevel)
                {
                    cell.OnGameStarted();
                }
            }
        }

        private void SetPositions(IReadOnlyList<Vector3> positions)
        {
            for (var i = 0; i < _spawnedCells.Count; i++)
            {
                _spawnedCells[i].transform.position = positions[i];
            }
        }

        private void RemoveUnnecessaryCells(int count)
        {
            for (int i = count - 1; i >= 0; i--)
            {
                _spawnedCells[_spawnedCells.Count - 1].Reset();
                Destroy(_spawnedCells[_spawnedCells.Count - 1].gameObject);
                _spawnedCells.RemoveAt(_spawnedCells.Count - 1);
            }
        }
    }
}