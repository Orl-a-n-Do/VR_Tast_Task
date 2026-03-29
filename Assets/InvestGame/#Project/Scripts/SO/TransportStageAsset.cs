using UnityEngine;

[CreateAssetMenu(fileName = "TransportStageAsset", menuName = "Asset/TransportStageAsset", order = 0)]
public class TransportStageAsset : ScriptableObject {
	public StatValueListAsset transportAsset;
	public ChoiceAsset[] choiceAsset;
}
