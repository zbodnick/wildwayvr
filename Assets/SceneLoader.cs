using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{

	public string nextScene;

	public void LoadScene() {
		SceneManager.LoadScene(nextScene);
	}

}