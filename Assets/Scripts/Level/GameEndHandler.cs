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

        [SerializeField] private float _maxFAdeValue = 0.5f;
        [SerializeField] private float _scalingDuration = 0.4f;
        [SerializeField] private float _fadingDuration = 1f;

        [Inject]
        public void Construct(RightAnswerView rightAnswerView)
        {
            GameCompleted += rightAnswerView.FadeOut;
        }
        public void OnGameCompleted()
        {
            _darkEffect.DOFade(_maxFAdeValue, _fadingDuration)
                .OnComplete(() => _restartButton.transform.DOScale(Vector3.one, _scalingDuration));
            GameCompleted?.Invoke();
        }

        public void OnGameRestarted()
        {
            _restartButton.transform.DOScale(Vector3.zero, _scalingDuration)
                .OnComplete(() => _darkEffect.DOFade(0f, _fadingDuration));
        }
    }
}