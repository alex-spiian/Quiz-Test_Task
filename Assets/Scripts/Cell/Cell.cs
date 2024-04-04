using UnityEngine;
using VContainer;

namespace Cell
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private CellView _cellView;
        [SerializeField] private CellAnimator _animator;
        
        private AnswerHandler.AnswerHandler _answerHandler;
        private string _identifire;

        [Inject]
        public void Construct(AnswerHandler.AnswerHandler answerHandler)
        {
            _answerHandler = answerHandler;
        }
        public void Initialize(Sprite value, string identifire)
        {
            _identifire = identifire;
            _cellView.UpdateView(value);
        }

        public void Reset()
        {
            _cellView.Reset();
            _animator.Reset();
        }
        public void OnGameStarted()
        {
            _animator.ShowBounce();
        }
        private void OnMouseUp()
        {
            if (_answerHandler.IsAnswerCorrect(_identifire))
            {
                _animator.ShowVictory(_answerHandler.OnLevelCompleted);
                return;
            }
            
            _animator.ShowDefend();
        }
    }
}