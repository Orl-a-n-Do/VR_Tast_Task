using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDown : MonoBehaviour {
	public AnimationCurve distCurve;
	public float dist;
	public float timeMove;

	private void Start() {
		StartCoroutine(Move());
	}

	private IEnumerator Move() {
		Vector3 startPos = transform.position;
		float t = 0, a;
		while (true) {
			a = Mathf.Clamp01(t / timeMove);
			transform.position = startPos + Vector3.up * dist * distCurve.Evaluate(a);
			yield return null;
			t += Time.deltaTime;
			if (t > timeMove)
				t = 0;
		}
	}
}
