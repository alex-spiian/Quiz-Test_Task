using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;

namespace Card
{
    public class CardSpawner : MonoBehaviour
    {
        [SerializeField] private CardConfig cardConfig;
        
        private CardFactory _cardFactory;
        private readonly List<Card> _spawnedCards = new List<Card>();

        [Inject]
        public void Construct(CardFactory cardFactory)
        {
            _cardFactory = cardFactory;
        }
        
        public void Spawn(int count, global::Card.Task task, List<Vector3> positions, bool isFirstLevel)
        {
            var neededCardsCount = 0;
            var spawnedCardsCount = _spawnedCards.Count;
            
            if (count > spawnedCardsCount)
            {
                neededCardsCount = count - spawnedCardsCount;
            }
            else
            {
                RemoveUnnecessaryCards(spawnedCardsCount - count);
            }
            
            for (int i = 0; i < neededCardsCount; i++)
            {
                var card = _cardFactory.CreateCard(cardConfig.Prefab);
                _spawnedCards.Add(card);
            }
            
            SetValue(task, isFirstLevel);
            SetPositions(positions);
        }

        public void Reset()
        {
            foreach (var card in _spawnedCards)
            {
                card.Reset();
                Destroy(card.gameObject);
            }
            _spawnedCards.Clear();
        }

        private void SetValue(global::Card.Task task, bool isFirstLevel)
        {
            foreach (var card in _spawnedCards)
            {
                var cardData = task.GetAnswerOption();
                card.Initialize(cardData.Sprite, cardData.Identifire);
                
                if (isFirstLevel)
                {
                    card.OnGameStarted();
                }
            }
        }

        private void SetPositions(IReadOnlyList<Vector3> positions)
        {
            for (var i = 0; i < _spawnedCards.Count; i++)
            {
                _spawnedCards[i].transform.position = positions[i];
            }
        }

        private void RemoveUnnecessaryCards(int count)
        {
            for (int i = count - 1; i >= 0; i--)
            {
                _spawnedCards[_spawnedCards.Count - 1].Reset();
                Destroy(_spawnedCards[_spawnedCards.Count - 1].gameObject);
                _spawnedCards.RemoveAt(_spawnedCards.Count - 1);
            }
        }
    }
}