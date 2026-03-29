using UnityEngine;
using UnityEngine.Events;

public class TriggerVolume : MonoBehaviour {
	public UnityEvent OnTriggerEnterEvent, OnTriggerExitEvent;

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.layer == 9) {//9-character
			OnTriggerEnterEvent?.Invoke();
		}
	}
}

