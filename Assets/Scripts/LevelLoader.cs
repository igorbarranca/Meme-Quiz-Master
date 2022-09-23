using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float loadGameDelay = 1f;
    [SerializeField] float loadMainMenuDelay = 1f;

    public void LoadGame()
    {
        StartCoroutine(LoadGameDelayed());
    }
    IEnumerator LoadGameDelayed()
    {
        yield return new WaitForSeconds(loadGameDelay);
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadMainMenuDelayed());
    }
    IEnumerator LoadMainMenuDelayed()
    {
        yield return new WaitForSeconds(loadMainMenuDelay);
        SceneManager.LoadScene(0);
    }
}
