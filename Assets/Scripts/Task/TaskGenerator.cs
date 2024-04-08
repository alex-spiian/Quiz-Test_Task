using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Card
{
    public class TaskGenerator : MonoBehaviour
    {
        [SerializeField] private CardDataConfig[] _cardDataConfigs;

        private readonly List<CardData> _availableCards = new List<CardData>();
        private readonly List<CardData> _usedCards = new List<CardData>();

        private void GetaAvailableObjects(int randomIndex)
        {
            var cardDataConfig = _cardDataConfigs[randomIndex];
            foreach (var cardData in cardDataConfig.CardData)
            {
                _availableCards.Add(cardData);
            }
        }

        public Task Generate(int answersCount)
        {
            var randomIndex = Random.Range(0, _cardDataConfigs.Length);
            GetaAvailableObjects(randomIndex);

            var rightAnswer = GetRightAnswer();
            List<CardData> answerOptions = new List<CardData>();

            answerOptions.Add(rightAnswer);
            answersCount--;
            
            for (int i = 0; i < answersCount; i++)
            {
                var randomOption = GetRandomCard();
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

        private CardData GetRandomCard()
        {
            var cardData = _availableCards[Random.Range(0, _availableCards.Count)];
            _availableCards.Remove(cardData);
            return cardData;
        }

        private CardData GetRightAnswer(
            )
        {
            var answer = GetRandomCard();
            if (!_usedCards.Contains(answer))
            {
                _usedCards.Add(answer);
                return answer;
            }
            return GetRightAnswer();
        }

        private void Reset()
        {
            _availableCards.Clear();
        }
    }
}