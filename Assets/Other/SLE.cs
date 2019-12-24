using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SLE
{
    public static void LoadScene(string fileToLoad=null, bool unloadCurrent=true)
    {
        if (unloadCurrent) SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene("SimpleLevelEditor");
        Scene scene = SceneManager.GetActiveScene();
        if (fileToLoad != null)
        {
            GameObject[] gobjs = scene.GetRootGameObjects();
            GameObject managerObject = gobjs[0];
            Manager manager = managerObject.GetComponent<Manager>();
            manager.LoadFile(fileToLoad);
        }
    }
}
