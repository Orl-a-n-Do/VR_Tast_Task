using System;

public class CurrencySystem : Singletone<CurrencySystem> {
	public StatType[] productTypes;
	private float _currentValue = 1000000f;
	private float _currentAmount = 1000f;
	private StatValueListAsset _startValues;
	private StatValueListAsset _endValues;
	private StatType _selectedType;

	public float CurrentValue => _currentValue;

	public Action OnChangeValue;

	private void Start() {
		_currentValue = InvestController.instance.startMoney.stat.value;
		_startValues = InvestController.instance.Quest.start;
		_endValues = InvestController.instance.Quest.end;
	}

	public void ChangeValue(float value) {
		_currentValue += value;
		OnChangeValue?.Invoke();
	}

	public void BuyProduct(StatType type) {
		_selectedType = type;
		float price = 0;
		for (int i = 0; i < _startValues.stat.Length; i++) {
			if (_startValues.stat[i].type == type) {
				price = _startValues.stat[i].value;
				break;
			}
		}
		ChangeValue(-price * _currentAmount);
	}

	public StatValue GetStartValue(StatType type) {
		for (int i = 0; i < _startValues.stat.Length; i++) {
			if (_startValues.stat[i].type == type) {
				return _startValues.stat[i];
			}
		}
		return null;
	}

	public void LoseAmount(float amountPercent) {
		_currentAmount -= _currentAmount * amountPercent;
	}

	public bool IsProfitProduct() {
		float startPrice = 0, endPrice = 0;
		for (int i = 0; i < _startValues.stat.Length; i++) {
			if (_startValues.stat[i].type == _selectedType) {
				startPrice = _startValues.stat[i].value;
				break;
			}
		}
		for (int i = 0; i<_endValues.stat.Length; i++) {
			if (_endValues.stat[i].type == _selectedType) {
				endPrice = _endValues.stat[i].value;
				break;
			}
		}
		return endPrice > startPrice;
	}

	public float GetFinalCostProduct() {
		float finalPrice = 0;
		for (int i = 0; i < _endValues.stat.Length; i++) {
			if (_endValues.stat[i].type == _selectedType) {
				finalPrice = _endValues.stat[i].value;
				break;
			}
		}
		return finalPrice * _currentAmount;
	}

	public void FinalProfit() {
		ChangeValue(GetFinalCostProduct());
	}
}
