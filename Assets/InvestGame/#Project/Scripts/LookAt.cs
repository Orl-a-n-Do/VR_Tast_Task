using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {
	public Transform target;
	public bool lookAtPlayer;
	public bool flat;

	private void Start() {
		if (lookAtPlayer) {
			target = Camera.main.transform;
		}
	}

	private void Update() {
		transform.LookAt(target);
		if (flat) {
			transform.eulerAngles = new Vector3(0, transform.rotation.eulerAngles.y, 0);
		}
	}
}
