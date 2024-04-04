using System;
using AnswerHandler;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Level
{
    public class GameEndHandler : MonoBehaviour
    {
        private event Action GameCompleted;
        [SerializeField] private SpriteRenderer _darkEffect;
        [SerializeField] private Button _restartButton;

        [Inject]
        public void Construct(RightAnswerView rightAnswerView)
        {
            GameCompleted += rightAnswerView.FadeOut;
        }
        public void OnGameCompleted()
        {
            _darkEffect.DOFade(0.5f, 1f)
                .OnComplete(() => _restartButton.transform.DOScale(Vector3.one, 0.4f));
            GameCompleted?.Invoke();
        }

        public void OnGameRestarted()
        {
            _restartButton.transform.DOScale(Vector3.zero, 0.4f)
                .OnComplete(() => _darkEffect.DOFade(0f, 1f));
        }
    }
}