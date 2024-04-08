using System;
using UnityEngine;

namespace Card
{
    [Serializable]
    public class CardData
    {
        [field:SerializeField] public string Identifire { get; private set; }
        [field:SerializeField] public Sprite Sprite { get; private set; }
    }
}