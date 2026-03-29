using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HoverObject : MonoBehaviour
{
	public UnityEvent onHover, onUnHover;
	public void OnHover() {
		onHover?.Invoke();
	}

	public void OnUnHover() {
		onUnHover?.Invoke();
	}
}
