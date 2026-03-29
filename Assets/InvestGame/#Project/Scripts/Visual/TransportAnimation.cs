using System;
using UnityEngine;

public class TransportAnimation : MonoBehaviour {
	public TransportUI transportUI;
	public TransportAnim[] transportAnims;

	[Serializable]
	public struct TransportAnim {
		public StatType statType;
		public Animator animator;
		public AudioSource source;
	}

	private void Start() {
		transportUI.onSelectTransport.AddListener(SelectTransport);
		foreach (TransportAnim anim in transportAnims) {
			var sa = anim.animator.gameObject.GetComponent<StopAnimation>();
			if (sa == null) {
				sa = anim.animator.gameObject.AddComponent<StopAnimation>();
				sa.Init(this);
			}
		}
	}

	private void SelectTransport() {
		foreach (var t in transportAnims) {
			if (t.statType == transportUI.SelectedType) {
				t.animator.SetTrigger("Activate");
				t.source.Play();
			}
		}
	}

	public void StopAnimation() {
		foreach (var t in transportAnims) {
			t.source.Stop();
		}
	}
}
