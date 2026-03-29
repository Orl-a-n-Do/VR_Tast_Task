using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TransportElementUI : MonoBehaviour {
	public Button button;
	public TextMeshProUGUI buttonText;
	private StatType _type;
	public StatType Type => _type;
	private TransportUI _transportUI;

	private void Start() {
		button.onClick.AddListener(OnClick);
	}
	public void Init(TransportUI transportUI, StatType type) {
		_transportUI = transportUI;
		_type = type;
		buttonText.text = type.Name;
	}

	private void OnClick() {
		_transportUI.SelectTransport(_type);
	}

	public void SetSelected() {
		buttonText.color = Color.green;
	}

	public void DisableButton() {
		button.interactable = false;
	}
}
