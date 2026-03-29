using UnityEngine;
using UnityEngine.Events;

public class DelayInvoke : MonoBehaviour {
	public float delay;
	public UnityEvent OnEvent;

	public void DelayStart() {
		Invoke(nameof(ActivateEvent), delay);
	}

	private void ActivateEvent() {
		OnEvent.Invoke();
	}
}
