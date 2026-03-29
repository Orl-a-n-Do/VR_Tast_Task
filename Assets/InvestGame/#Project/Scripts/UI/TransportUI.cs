using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TransportUI : MonoBehaviour {
	public int stageTransport;
	public TransportElementUI[] transportButtons;
	public TextMeshProUGUI textTransport;
	public TextMeshProUGUI additionalText;
	public Toggle toggle;
	public Button selectButton;

	public UnityEvent onSelectTransport;

	private TransportStageAsset _asset;
	private StatType _selectType;
	public StatType SelectedType => _selectType;

	private void Start() {
		_asset = TransportController.instance.GetStage(stageTransport);		
		selectButton.onClick.AddListener(OnClick);
		SetTransportElements();
		textTransport.gameObject.SetActive(false);
		additionalText.gameObject.SetActive(false);
		selectButton.interactable = true;
		selectButton.gameObject.SetActive(false);
		toggle.gameObject.SetActive(false);
	}

	private void OnClick() {
		TransportController.instance.SelectTransport(_selectType, toggle.isOn);
		selectButton.interactable = false;
		toggle.interactable = false;
		foreach (var transportButton in transportButtons) {
			transportButton.DisableButton();
			if (transportButton.Type == _selectType) {
				transportButton.SetSelected();
			}
		}
		onSelectTransport?.Invoke();
	}

	public void SelectTransport(StatType type) {
		_selectType = type;
		textTransport.gameObject.SetActive(true);
		selectButton.gameObject.SetActive(true);
		for (int i = 0; i < transportButtons.Length; i++) {
			if (_asset.transportAsset.stat[i].type == type) {
				textTransport.text = $"стоимость данной доставки {_asset.transportAsset.stat[i].value} руб";
				break;
			}
		}
		additionalText.gameObject.SetActive(false);
		toggle.gameObject.SetActive(false);
		toggle.isOn = false;
		for (int i = 0; i < _asset.choiceAsset.Length; i++) {
			if (_asset.choiceAsset[i].selectedType == type) {
				toggle.gameObject.SetActive(true);
				toggle.isOn = false;
				additionalText.gameObject.SetActive(true);
				additionalText.text = $"{_asset.choiceAsset[i].question}";
				break;
			}
		}
	}

	private void SetTransportElements() {
		for (int i = 0; i < transportButtons.Length; i++) {
			transportButtons[i].gameObject.SetActive(false);
		}
		for (int i = 0; i < _asset.transportAsset.stat.Length; i++) {
			transportButtons[i].gameObject.SetActive(true);
			transportButtons[i].Init(this, _asset.transportAsset.stat[i].type);
		}
	}
}
