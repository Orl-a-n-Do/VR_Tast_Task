using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ChoiceAsset", menuName = "Asset/ChoiceAsset", order = 0)]
public class ChoiceAsset : ScriptableObject {
	public StatType selectedType;
	public StatValue additionalStat;
	public string question, selected, unselected;

	[Serializable]
	public struct Lose {
		public LoseType loseType;
		public float lostValue;
	}

	public Lose[] loses;
}

public enum LoseType {
	None,
	LostProduct,
	LostMoney
}
