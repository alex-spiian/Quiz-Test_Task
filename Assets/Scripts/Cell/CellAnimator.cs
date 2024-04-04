using System;
using DG.Tweening;
using UnityEngine;

namespace Cell
{
    public class CellAnimator : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _animatedObject;
        [SerializeField] private ParticleSystem _starsEffect;
        public Vector3 bounceScale;
        public float bounceDuration;
        public Ease bounceEase;

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
            _bounceSequence.Append(transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.4f).SetEase(Ease.Linear));
            _bounceSequence.Append(transform.DOScale(Vector3.one, 0.4f).SetEase(Ease.InOutBack));
            _bounceSequence.Play();
        }
        public void ShowVictory(Action AnimationEnded)
        {
            _starsEffect.gameObject.SetActive(true);

            _victorySequence = DOTween.Sequence();
            _victorySequence.Append(_animatedObject.transform.DOScale(bounceScale, bounceDuration).SetEase(bounceEase));
            _victorySequence.Append(_animatedObject.transform.DOScale(originalScale, bounceDuration).SetEase(bounceEase));
            _victorySequence.Append(_animatedObject.transform.DOScale(originalScale, bounceDuration / 2)
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
            _defendSequence.Append(_animatedObject.transform.DORotate(new Vector3(0f, 0f, 20f), 0.1f));
            _defendSequence.Append(_animatedObject.transform.DORotate(new Vector3(0f, 0f, -20f), 0.2f));
            _defendSequence.Append(_animatedObject.transform.DORotate(Vector3.zero, 0.1f));

            _defendSequence.Play();
        }
        
    }
}