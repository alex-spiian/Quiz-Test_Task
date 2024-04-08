using UnityEngine;
using UnityEngine.Serialization;
using VContainer;

namespace Card
{
    public class Card : MonoBehaviour
    {
        [SerializeField] private CardView _cardView;
        [SerializeField] private CardVisualEffects _cardVisualEffects;
        
        private AnswerHandler.AnswerHandler _answerHandler;
        private string _identifire;

        [Inject]
        public void Construct(AnswerHandler.AnswerHandler answerHandler)
        {
            _answerHandler = answerHandler;
        }
        public void Initialize(Sprite sprite, string identifire)
        {
            _identifire = identifire;
            _cardView.UpdateView(sprite);
        }
        public void Reset()
        {
            _cardView.Reset();
            _cardVisualEffects.Reset();
        }
        public void OnGameStarted()
        {
            _cardVisualEffects.ShowBounce();
        }
        private void OnMouseUp()
        {
            if (_answerHandler.IsAnswerCorrect(_identifire))
            {
                _cardVisualEffects.ShowVictory(_answerHandler.OnLevelCompleted);
                return;
            }
            _cardVisualEffects.ShowDefeat();
        }
    }
}