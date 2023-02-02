using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public void ReloadCurrentScene()
    {
        StartCoroutine(Reload());
    }

    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(2f);
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
    }
}
