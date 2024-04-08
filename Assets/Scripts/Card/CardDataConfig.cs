using System;
using UnityEngine;

namespace Card
{
    
    [CreateAssetMenu(fileName = "CardDataConfig", menuName = "ScriptableObject/CardDataConfig", order = 2)]
    public class CardDataConfig : ScriptableObject
    {
        [field:SerializeField] public CardData[] CardData { get; private set; }
    }
}