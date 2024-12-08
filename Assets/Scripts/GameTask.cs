using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "GameTask", menuName = "Tasks/Task")]
public class GameTask : ScriptableObject
{
    public string taskId;
    public string taskName;
    public string taskType;
    public bool isCompleted;
}
