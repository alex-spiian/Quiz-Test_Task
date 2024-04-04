using System;
using System.Reflection;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace Cell
{
    public class CellAnimator : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _animatedObject;
        [SerializeField] private ParticleSystem _starsEffect;
        
        [SerializeField]private Vector3 _valueBounceScale;
        [SerializeField] private float _bounceDuration;
        [SerializeField]private Vector3 _cellBounceScale;
        [SerializeField]private Vector3 _minRotation;
        [SerializeField]private Vector3 _maxRotation;
        
        private Vector3 originalScale;
        private Sequence _bounceSequence;
        private Sequence _victorySequence;
        private Sequence _defendSequence;

        private void Start()
        {
            originalScale = _animatedObject.transform.localScale;
        }

        public void Reset()
        {
            _bounceSequence.Kill();
            _victorySequence.Kill();
            _defendSequence.Kill();
        }
        public void ShowBounce()
        {
            transform.localScale = Vector3.zero;

            _bounceSequence = DOTween.Sequence();
            _bounceSequence.Append(transform.DOScale(_cellBounceScale, _bounceDuration).SetEase(Ease.Linear));
            _bounceSequence.Append(transform.DOScale(Vector3.one, _bounceDuration).SetEase(Ease.InOutBack));
            _bounceSequence.Play();
        }
        public void ShowVictory(Action AnimationEnded)
        {
            _starsEffect.gameObject.SetActive(true);

            _victorySequence = DOTween.Sequence();
            _victorySequence.Append(_animatedObject.transform.DOScale(_valueBounceScale, _bounceDuration).SetEase(Ease.InOutBack));
            _victorySequence.Append(_animatedObject.transform.DOScale(originalScale, _bounceDuration).SetEase(Ease.InOutBack));
            _victorySequence.Append(_animatedObject.transform.DOScale(originalScale, _bounceDuration / 2)
                    .SetEase(Ease.Linear))
                .OnComplete(() => OnVictoryAnimationEnded(AnimationEnded));

            _victorySequence.Play();
        }

        private void OnVictoryAnimationEnded(Action AnimationEnded)
        {
            _starsEffect.gameObject.SetActive(false);
            AnimationEnded?.Invoke();
        }

        public void ShowDefend()
        {
            _defendSequence = DOTween.Sequence();
            _defendSequence.Append(_animatedObject.transform.DORotate(_maxRotation, 0.1f));
            _defendSequence.Append(_animatedObject.transform.DORotate(_minRotation, 0.2f));
            _defendSequence.Append(_animatedObject.transform.DORotate(Vector3.zero, 0.1f));

            _defendSequence.Play();
        }
        
    }
}