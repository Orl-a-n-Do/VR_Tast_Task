using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TransportResultUI : MonoBehaviour {
	public GameObject result;
	public Slider loading;
	public TextMeshProUGUI resultText;
	public Button continueButton;

	public float timeLoading;

	private void Start() {
		result.SetActive(false);
		continueButton.onClick.AddListener(OnClick);
		TransportController.instance.OnSelectTransport += ShowResult;
	}

	private void OnClick() {
		result.gameObject.SetActive(false);
	}

	private void ShowResult() {
		StartCoroutine(Result());
	}

	IEnumerator Result() {
		float t = 0;
		result.SetActive(true);
		resultText.gameObject.SetActive(false);
		continueButton.gameObject.SetActive(false);
		loading.gameObject.SetActive(true);
		while (t < timeLoading) {
			var a = Mathf.Clamp01(t / timeLoading);
			loading.value = a;
			yield return null;
			t += Time.deltaTime;
		}
		loading.gameObject.SetActive(false);
		resultText.gameObject.SetActive(true);
		continueButton.gameObject.SetActive(true);

		TransportController.instance.ResultTransport();
		resultText.text = TransportController.instance.GetResultTransport(TransportController.instance.CurrentStage);
		TransportController.instance.NextStage();
	}
}
