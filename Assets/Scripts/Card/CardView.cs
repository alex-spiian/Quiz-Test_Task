using Provider;
using UnityEngine;
using VContainer;

namespace Card
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _background;
        [SerializeField] private SpriteRenderer _value;

        private ColorProvider _colorProvider;

        [Inject]
        public void Construct(ColorProvider colorProvider)
        {
            _colorProvider = colorProvider;
        }
        public void UpdateView(Sprite value)
        {
            _background.color = _colorProvider.GetRandomColor();
            _value.sprite = value;
        }

        public void Reset()
        {
            _value.sprite = null;
        }
    }
}