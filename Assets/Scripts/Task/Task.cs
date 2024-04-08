using System.Collections.Generic;
using UnityEngine;

namespace Task
{
    public class Task
    {
        public CardData RightAnswer { get; }
        private List<CardData> _answerOptions;

        public Task(CardData rightAnswer, List<CardData> answerOptions)
        {
            RightAnswer = rightAnswer;
            _answerOptions = answerOptions;
        }

        public CardData GetAnswerOption()
        {
            var randomCard = _answerOptions[Random.Range(0, _answerOptions.Count)];
            _answerOptions.Remove(randomCard);
            return randomCard;
        }
    }
}