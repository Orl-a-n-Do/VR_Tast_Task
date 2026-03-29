using System;

public class TransportController : Singletone<TransportController> {
	public TransportStageAsset[] stages;

	public Action OnSelectTransport;

	private int currentStage = 0;
	public int CurrentStage => currentStage;
	private StatType _transportSelected;
	private bool _choiceSelected;
	private string[] resultTexts;

	private void Start() {
		resultTexts = new string[stages.Length];
	}

	public TransportStageAsset GetStage() {
		return stages[currentStage];
	}

	public TransportStageAsset GetStage(int stage) {
		return stages[stage];
	}

	public ChoiceAsset GetChoice(StatType type) {
		for (int i = 0; i < stages[currentStage].choiceAsset.Length; i++) {
			if (stages[currentStage].choiceAsset[i].selectedType == type) {
				return stages[currentStage].choiceAsset[i];
			}
		}
		return null;
	}

	public void SelectTransport(StatType type, bool choiceSelected) {
		_transportSelected = type;
		_choiceSelected = choiceSelected;
		var price = GetCost(type);
		if (choiceSelected) {
			price += GetCostChoice(type);
		}
		CurrencySystem.instance.ChangeValue(-price);
		OnSelectTransport?.Invoke();
	}

	public void ResultTransport() {
		ChoiceAsset choiceAsset = GetChoice(_transportSelected);
		string resText = "";
		if (choiceAsset != null) {
			if (_choiceSelected) {
				resText = choiceAsset.selected;
			} else {
				resText = choiceAsset.unselected;
				LoseTransport(choiceAsset);
			}
		} else {
			resText = $"Товар успешно доставлен";
		}
		resultTexts[currentStage] = resText;
	}

	public string GetResultTransport(int stage) {
		return resultTexts[stage];
	}

	public float GetCost(StatType type) {
		for (int i = 0; i < stages[currentStage].transportAsset.stat.Length; i++) {
			if (stages[currentStage].transportAsset.stat[i].type == type) {
				return stages[currentStage].transportAsset.stat[i].value;
			}
		}
		return 0;
	}

	public float GetCostChoice(StatType type) {
		for (int i = 0; i < stages[currentStage].choiceAsset.Length; i++) {
			if (stages[currentStage].choiceAsset[i].selectedType == type) {
				return stages[currentStage].choiceAsset[i].additionalStat.value;
			}
		}
		return 0;
	}

	public void NextStage() {
		currentStage++;
	}

	public void LoseTransport(ChoiceAsset choiceAsset) {
		for(int i = 0;i<choiceAsset.loses.Length;i++) {
			switch (choiceAsset.loses[i].loseType) {
				case LoseType.LostProduct:
					CurrencySystem.instance.LoseAmount(choiceAsset.loses[i].lostValue);
					break;
				case LoseType.LostMoney:
					CurrencySystem.instance.ChangeValue(-choiceAsset.loses[i].lostValue);
					break;
				default: 
					break;
			}
		}
	}
}
