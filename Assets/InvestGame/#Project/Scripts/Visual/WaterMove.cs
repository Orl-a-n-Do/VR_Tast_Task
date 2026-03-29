using System.Collections;
using UnityEngine;

public class WaterMove : MonoBehaviour {
	public Renderer renderer;
	public float speed = 1f;
	public Vector2 dirMove;
	private Material mat;

	private void Start() {
		mat = renderer.material;
		StartCoroutine(WaterFlow());
	}

	IEnumerator WaterFlow() {
		while (true) {
			mat.mainTextureOffset = mat.mainTextureOffset + dirMove * speed * Time.deltaTime;
			yield return null;
		}
	}
}
