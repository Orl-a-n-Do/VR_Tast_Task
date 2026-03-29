using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
	public void Load() {
		SceneManager.LoadScene((int)SceneType.Game);
	}
}

public enum SceneType {
	Tutor = 0,
	Game = 1
}