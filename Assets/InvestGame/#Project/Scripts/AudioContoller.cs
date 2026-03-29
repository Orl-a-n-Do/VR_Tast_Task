using BNG;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class AudioContoller : MonoBehaviour {
	private GameObject hoverUI;
	private Button hoverButton;
	private Toggle hoverToggle;
	public GameObject clickAudio;
	private AudioSource clickSound;

	private void Start() {
		UIPointer pointer = PlayerController.instance.GetComponentInChildren<UIPointer>();
		clickAudio.transform.parent = pointer.CurrentCursor.transform;
		clickAudio.transform.localPosition = Vector3.zero;
		clickSound = clickAudio.GetComponentInChildren<AudioSource>();
	}

	private void Update() {
		if (VRUISystem.Instance.ReleasingObject != null) {
			if (VRUISystem.Instance.ReleasingObject != hoverUI) {
				var b = VRUISystem.Instance.ReleasingObject.GetComponentInChildren<Button>();
				var t = VRUISystem.Instance.ReleasingObject.GetComponentInChildren<Toggle>();
				if (b != null || t != null) {
					UnSubscribeButton();
					UnSubscribeToggle();
					SubscribeButton(b);
					SubscribeToggle(t);
				}
			}
		} else {
			hoverUI = null;
			UnSubscribeButton();
			UnSubscribeToggle();
		}
	}
	private void SubscribeToggle(Toggle t) {
		if (t != null) {
			hoverToggle = t;
			hoverToggle.onValueChanged.AddListener(OnClickToggle);
		}
	}

	private void SubscribeButton(Button b) {
		if (b != null) {
			hoverButton = b;
			hoverButton.onClick.AddListener(OnClickButtonUI);
		}
	}

	private void UnSubscribeToggle() {
		if (hoverToggle != null) {
			hoverToggle.onValueChanged.AddListener(OnClickToggle);
			hoverToggle = null;
		}
	}

	private void UnSubscribeButton() {
		if (hoverButton != null) {
			hoverButton.onClick.AddListener(OnClickButtonUI);
			hoverButton = null;
		}
	}

	private void OnClickButtonUI() {
		clickSound.Play();
	}

	private void OnClickToggle(bool state) {
		clickSound.Play();
	}
}
