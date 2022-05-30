using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelPlay : MonoBehaviour
{
    public int sceneIndex = 0;
    // Adds the target scene index above that is set manually in the scene to the current build index
    public void Play(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + sceneIndex);
    }
}
