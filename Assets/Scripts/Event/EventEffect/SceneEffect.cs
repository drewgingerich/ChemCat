using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "EventEffect/SceneEffect")]
public class SceneEffect : EventEffect {
	[SerializeField] string nextSceneName;

	public override void Trigger() {
		SceneManager.LoadScene(nextSceneName);
	}
}
