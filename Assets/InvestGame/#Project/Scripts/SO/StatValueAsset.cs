using System;
using UnityEngine;

[CreateAssetMenu(fileName = "StatValue", menuName = "Asset/StatValue", order = 0)]
public class StatValueAsset : ScriptableObject {
	public StatValue stat;
}

[Serializable]
public class StatValue {
	public StatType type;
	public float value;
}
