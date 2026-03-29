using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ProductSelector : MonoBehaviour {
	public ProductElementUI[] elements;
	//public TextMeshProUGUI text;
	public UnityEvent onSelectProduct;

	private StatType _selectedType;

	private void Start() {
		Init();
	}

	private void OnEnable() {
		if (_selectedType != null) {
			DisableButtons();
		}
	}

	private void Init() {
		for (int i = 0; i < elements.Length; i++) {
			elements[i].Init(this, CurrencySystem.instance.GetStartValue(CurrencySystem.instance.productTypes[i]));
		}
		//text.text = InvestController.instance.Quest.story.Text;
	}

	public void SelectType(StatType type) {
		_selectedType = type;
		InvestController.instance.SelectType(type);
		DisableButtons();
		onSelectProduct?.Invoke();
	}

	public void DisableButtons() {
		foreach (var button in elements) {
			button.DisableUI();
			button.HideButton();
		}
	}
}
