using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    public TextMeshProUGUI resText;
    public Button restartButton;

	private void Start() {
		restartButton.onClick.AddListener(OnClick);
	}

	private void OnEnable() {
		CurrencySystem.instance.FinalProfit();
		var isProfitProduct = CurrencySystem.instance.IsProfitProduct();
		var textProfit = isProfitProduct ? "Продукт вырос в цене, хорошее вложение" : "Продук упал в цене, плохое вложение";
		resText.text = $"В результате вы заработали {CurrencySystem.instance.GetFinalCostProduct()}\n" +
			$"Ваш счет {CurrencySystem.instance.CurrentValue} руб\n" +
			textProfit;
	}

	private void OnClick() {
		SceneManager.LoadScene((int)SceneType.Game);
	}
}
