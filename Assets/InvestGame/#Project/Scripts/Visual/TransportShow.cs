using UnityEngine;
using UnityEngine.UI;

public class TransportShow : MonoBehaviour {
	public GameObject transport;
	public Toggle toggle;

	private void Start() {
		toggle.onValueChanged.AddListener(ChangeToggle);
	}

	private void ChangeToggle(bool state) {
		transport.SetActive(state);
	}
}
