using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuElementUI : MonoBehaviour {
	public Button button;
	private MenuUI _menuUI;
	private MenuType _type;
	public UnityEvent OnSelect;

	private void Start() {
		button.onClick.AddListener(OnClick);
	}

	public void Init(MenuUI menu, MenuType type) {
		_type = type;
		_menuUI = menu;
	}

	private void OnClick() {
		_menuUI.SelectType(_type);
		OnSelect?.Invoke();
	}
}
