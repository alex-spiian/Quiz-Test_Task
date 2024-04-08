using UnityEngine;

namespace Card
{
    [CreateAssetMenu(fileName = "CardConfig", menuName = "ScriptableObject/CardConfig", order = 1)]
    public class CardConfig : ScriptableObject
    {
        [field:SerializeField]
        public Card Prefab { get; private set; }
    }
}