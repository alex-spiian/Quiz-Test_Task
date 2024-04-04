using System;
using UnityEngine;

namespace Task
{
    
    [CreateAssetMenu(fileName = "TaskObjectConfig", menuName = "ScriptableObject/TaskObjectConfig", order = 2)]
    public class TaskObjectConfig : ScriptableObject
    {
        [field:SerializeField] public TaskObject[] TaskObjects { get; private set; }
    }
}