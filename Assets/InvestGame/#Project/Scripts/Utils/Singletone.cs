using UnityEngine;

public class Singletone : MonoBehaviour { }

public class Singletone<T> : Singletone where T : Singletone {
	public static T instance;

	protected virtual void Awake() {
		instance = this as T;
	}
}
