using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	private static UIManager instance;

	[Tooltip("A collection of prefabs that will be instantiated that are expected to have scripts" +
		"to take care of themselves fully. (This keeps them modular and independent of the manager scripts)")]
	[SerializeField] private GameObject[] uiPrefabs;

	private RectTransform screenCanvas;

	public static RectTransform ScreenCanvas {
		get { return (instance == null) ? null : instance.screenCanvas; }
	}

	public void Awake() {
		if (instance != null && instance != this) {
			GameObject.DestroyImmediate(gameObject);
			return;
		}
		instance = this;

		GameObject result = GameObject.Find("Screen Canvas"); //Would not do this in Update! I just do this once in Awake haha.
		screenCanvas = (result == null) ? null : result.transform as RectTransform;

		for (int i = 0; i < uiPrefabs.Length; i++)
			GameObject.Instantiate(uiPrefabs[i], screenCanvas);
	}
}
