using System;
using DefaultNamespace;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace AnswerHandler
{
    public class RightAnswerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _answerView;
        [SerializeField] private float _animationDuration;
        

        public void UpdateView(string answer)
        {
            _answerView.text = GlobalConstants.FIND_TEXT + answer;
        }

        public void FadeIn()
        {
            _answerView.DOFade(1f, _animationDuration);
        }
        
        public void FadeOut()
        {
            _answerView.DOFade(0f, _animationDuration);
        }
    }
}