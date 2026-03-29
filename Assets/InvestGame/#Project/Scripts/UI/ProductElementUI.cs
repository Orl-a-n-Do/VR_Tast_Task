using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductElementUI : MonoBehaviour {
	public TextMeshProUGUI textProduct, textPrice;
	public Button button;

	private StatType _stat;
	private ProductSelector _selecter;

	public void DisableUI() {
		button.interactable = false;
	}

	public void HideButton() {
		button.gameObject.SetActive(false);
	}

	public void Init(ProductSelector selector, StatValue statValue) {
		_selecter = selector;
		_stat = statValue.type;
		textProduct.text = $"{statValue.type.Name}";
		textPrice.text = $"{statValue.value * 1000}";
		button.onClick.AddListener(OnClick);
	}

	private void OnClick() {
		textProduct.color = Color.green;
		textPrice.color = Color.green;
		_selecter.SelectType(_stat);
	}
}
