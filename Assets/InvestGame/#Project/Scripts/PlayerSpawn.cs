using UnityEngine;

public class PlayerSpawn : MonoBehaviour {
	[SerializeField] private Transform point;

	private void Start() {
		PlayerController.instance.Warp(point);
	}
}
