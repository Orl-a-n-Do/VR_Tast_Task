using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour {
	public float rotateSpeed;
	public Vector3 dir;

	private void Start() {
		StartCoroutine(Rotate());
	}

	IEnumerator Rotate() {
		while (true) {
			transform.rotation = Quaternion.Euler(dir * rotateSpeed * Time.deltaTime) * transform.rotation;
			yield return null;
		}
	}
}
