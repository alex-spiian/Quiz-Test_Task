using System.Collections.Generic;
using UnityEngine;

namespace Task
{
    public class Task
    {
        public TaskObject RightAnswer { get; }
        private List<TaskObject> _answerOptions;

        public Task(TaskObject rightAnswer, List<TaskObject> answerOptions)
        {
            RightAnswer = rightAnswer;
            _answerOptions = answerOptions;
        }

        public TaskObject GetAnswerOption()
        {
            var randomObject = _answerOptions[Random.Range(0, _answerOptions.Count)];
            _answerOptions.Remove(randomObject);
            return randomObject;
        }
    }
}