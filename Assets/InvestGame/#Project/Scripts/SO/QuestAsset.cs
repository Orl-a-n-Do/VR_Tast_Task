using UnityEngine;

[CreateAssetMenu(fileName = "QuestAsset", menuName = "Asset/QuestAsset", order = 0)]
public class QuestAsset : ScriptableObject
{
    public StoryAsset story;

    public StatValueListAsset start, end;
}
