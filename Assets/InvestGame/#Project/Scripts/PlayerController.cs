using UnityEngine;

public class PlayerController : Singletone<PlayerController> {
	public Rigidbody rb;
	public Transform movable;

	public void BlockMove(bool state) {
		rb.isKinematic = state;
	}

	public void Warp(Transform point) {
		movable.position = point.position;
		movable.rotation = point.rotation;
	}
}
