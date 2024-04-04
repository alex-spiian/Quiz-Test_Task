using UnityEngine;

namespace Level
{
    
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "ScriptableObject/LevelConfig", order = 3)]
    public class LevelConfig : ScriptableObject
    {
        [field:SerializeField]
        public int RowsCount { get; private set; }
        
        [field:SerializeField]
        public int ColumnsCount { get; private set; }
        
        [field:SerializeField]
        public float Spacing { get; private set; }
    }
}