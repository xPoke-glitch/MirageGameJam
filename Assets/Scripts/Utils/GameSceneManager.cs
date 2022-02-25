using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    private void OnEnable()
    {
        Player.OnGameOver += ToGameOverScene;
    }

    private void OnDisable()
    {
        Player.OnGameOver -= ToGameOverScene;
    }

    private void ToGameOverScene()
    {
        ChangeSceneWithDelay("GameOver", 2.0f);
    }

    public void ChangeScene(string name)
    {
        ChangeSceneWithDelay(name, 0.0f);
    }

    public void ChangeSceneWithDelay(string name, float delay)
    {
        StartCoroutine(COChangeSceneWithDelay(name, delay));
    }

    private IEnumerator COChangeSceneWithDelay(string name, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(name);
    }
}
