using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Task
{
    public class TaskGenerator : MonoBehaviour
    {
        [SerializeField] private TaskObjectConfig[] _taskObjectConfig;

        private List<TaskObject> _availableObjects = new List<TaskObject>();
        private List<TaskObject> _usedObjects = new List<TaskObject>();

        private void GetaAvailableObjects(int randomIndex)
        {
            var taskObjectConfig = _taskObjectConfig[randomIndex];
            foreach (var taskObject in taskObjectConfig.TaskObjects)
            {
                _availableObjects.Add(taskObject);
            }
        }

        public Task Generate(int answersCount)
        {
            var randomIndex = Random.Range(0, _taskObjectConfig.Length);
            GetaAvailableObjects(randomIndex);

            var rightAnswer = GetRightAnswer();
            List<TaskObject> answerOptions = new List<TaskObject>();

            answerOptions.Add(rightAnswer);
            answersCount--;
            
            for (int i = 0; i < answersCount; i++)
            {
                var randomOption = GetRandomObject();
                if (answerOptions.Contains(randomOption))
                {
                    i--;
                    continue;
                }
                
                answerOptions.Add(randomOption);
            }

            Reset();
            return new Task(rightAnswer, answerOptions);
        }

        private TaskObject GetRandomObject()
        {
            var taskObject = _availableObjects[Random.Range(0, _availableObjects.Count)];
            _availableObjects.Remove(taskObject);
            return taskObject;
        }

        private TaskObject GetRightAnswer(
            )
        {
            var answer = GetRandomObject();
            if (!_usedObjects.Contains(answer))
            {
                _usedObjects.Add(answer);
                return answer;
            }
            
            return GetRightAnswer();
        }

        private void Reset()
        {
            _availableObjects.Clear();
        }
    }
}