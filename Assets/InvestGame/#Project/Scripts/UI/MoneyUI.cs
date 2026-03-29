using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour {
	public TextMeshProUGUI text;

	private void Start() {
		CurrencySystem.instance.OnChangeValue += ChangeValue;
		ChangeValue();
	}

	private void ChangeValue() {
		text.text = $"Осталось {CurrencySystem.instance.CurrentValue} руб";
	}
}
