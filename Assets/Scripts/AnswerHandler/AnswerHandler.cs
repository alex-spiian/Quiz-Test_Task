using System;
using VContainer;

namespace AnswerHandler
{
    public class AnswerHandler

    {
        private event Action LevelCompleted;
        private string _rightAnswer;
        private RightAnswerView _rightAnswerView;

        [Inject]
        public void Construct(RightAnswerView rightAnswerView)
        {
            _rightAnswerView = rightAnswerView;
        }
        public void Initialize(string identifire, Action levelCompleted)
        {
            _rightAnswer = identifire;
            _rightAnswerView.UpdateView(identifire);
            LevelCompleted += levelCompleted;
        }

        public bool IsAnswerCorrect(string answer)
        {
            return answer == _rightAnswer;
        }

        public void OnLevelCompleted()
        {
            var tempEvent = LevelCompleted;
            LevelCompleted?.Invoke();
            LevelCompleted -= tempEvent;
        }
    }
}