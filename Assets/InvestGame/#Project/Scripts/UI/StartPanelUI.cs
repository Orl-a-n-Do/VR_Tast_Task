using TMPro;
using UnityEngine;

public class StartPanelUI : MonoBehaviour {
	public TextMeshProUGUI text;

	private void Start() {
		UpdateText();
	}

	private void UpdateText() {
		var storyText = InvestController.instance.Quest.story.Text;
		var mess = "Текущее положение в мире:\n" + storyText;
		text.text = mess;
	}
}
