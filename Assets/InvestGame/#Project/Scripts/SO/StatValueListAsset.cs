using System;
using UnityEngine;

[CreateAssetMenu(fileName = "StatValueListAsset", menuName = "Asset/StatValueListAsset", order = 0)]
public class StatValueListAsset : ScriptableObject {
	public StatValue[] stat;
}
