using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOnDisable : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    private void OnDisable()
    {
        SceneManager.LoadScene(sceneName);
    }
}
