using System.Collections;
using AnswerHandler;
using DG.Tweening;
using Level;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace SplashScreen
{
    public class SplashScreen : MonoBehaviour
    {
        [SerializeField] private Slider _loadingSlider;
        [SerializeField] private SpriteRenderer _splashScreenView;

        [SerializeField] private float _splashScreenFadeDuration = 0.5f;
        [SerializeField] private float _delayBeforNextLevelSpawn = 0.3f;
        [SerializeField] private float _loadingDelay = 0.007f;
        
        private LevelSpawner _levelSpawner;
        private RightAnswerView _rightAnswerView;

        [Inject]
        public void Construct(LevelSpawner levelSpawner, RightAnswerView rightAnswerView)
        {
            _rightAnswerView = rightAnswerView;
            gameObject.SetActive(true);
            _levelSpawner = levelSpawner;
            _levelSpawner.LevelReset += OnGameReset;
            StartCoroutine(LoadGame(false));
        }

        private void OnGameReset()
        {
            gameObject.SetActive(true);
            StartCoroutine(LoadGame(true));
        }

        private IEnumerator LoadGame(bool wasGameReset)
        {
            _splashScreenView.gameObject.SetActive(true);
            _splashScreenView.DOFade(1f, _splashScreenFadeDuration);
            if (wasGameReset)
            {
                yield return new WaitForSeconds(_delayBeforNextLevelSpawn);
                _levelSpawner.Spawn();
            }
            
            yield return StartCoroutine(StartLoading());

            if (!wasGameReset)
            {
                _levelSpawner.Spawn();
            }

            _splashScreenView.DOFade(0f, _splashScreenFadeDuration)
                .OnComplete(OnGameLoaded);
            _loadingSlider.value = 0;
            gameObject.SetActive(false);
        }

        private IEnumerator StartLoading()
        {
            while (_loadingSlider.value != 100)
            {
                _loadingSlider.value += 1;
                yield return new WaitForSeconds(_loadingDelay);
            }
        }

        private void OnGameLoaded()
        {
            _splashScreenView.gameObject.SetActive(true);
            _rightAnswerView.FadeIn();
        }

        private void OnDestroy()
        {
            _levelSpawner.LevelReset -= OnGameReset;
        }
    }
}