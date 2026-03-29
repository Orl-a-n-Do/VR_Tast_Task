using UnityEngine;

public class BlockerMove : MonoBehaviour {
	[SerializeField] private bool block;

	void Start() {
		PlayerController.instance.BlockMove(block);
	}
}
