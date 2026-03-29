using System;
using UnityEngine;

public class MenuUI : MonoBehaviour {
	public MenuChapter[] chapters;

	[Serializable]
	public struct MenuChapter {
		public MenuType type;
		public MenuElementUI elementUI;
		public GameObject chapter;
	}

	private void Start() {
		for (int i = 0; i < chapters.Length; i++) {
			chapters[i].elementUI.Init(this, chapters[i].type);
		}
	}

	public void SelectType(MenuType type) {
		for (int i = 0; i < chapters.Length; i++) {
			chapters[i].chapter.SetActive(false);
		}
		for (int i = 0; i < chapters.Length; i++) {
			if (chapters[i].type == type) {
				chapters[i].chapter.SetActive(true);
				break;
			}
		}
	}
}

public enum MenuType {
	product,
	transport1,
	transport2,
	transport3,
	results
}