using UnityEngine;

public class StopAnimation : MonoBehaviour {
	private TransportAnimation transportAnimation;

	public void Init(TransportAnimation ta) {
		transportAnimation = ta;
	}

	public void Stop() {
		if (transportAnimation != null)
			transportAnimation.StopAnimation();
	}
}
