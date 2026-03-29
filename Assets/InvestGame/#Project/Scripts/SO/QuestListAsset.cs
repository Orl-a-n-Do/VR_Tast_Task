using UnityEngine;

[CreateAssetMenu(fileName = "QuestListAsset", menuName = "Asset/QuestListAsset", order = 0)]
public class QuestListAsset : ScriptableObject {
	public QuestAsset[] questAssets;

	public QuestAsset GetAsset() => questAssets[Random.Range(0, questAssets.Length)];
}
