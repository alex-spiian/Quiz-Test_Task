using UnityEngine;

namespace Cell
{
    [CreateAssetMenu(fileName = "CellConfig", menuName = "ScriptableObject/CellConfig", order = 1)]
    public class CellConfig : ScriptableObject
    {
        [field:SerializeField]
        public Cell Prefab { get; private set; }
    }
}