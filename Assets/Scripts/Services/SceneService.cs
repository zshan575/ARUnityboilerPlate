using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneService : MonoBehaviour
{
    [SerializeField] private SceneReference gameScene;
    [SerializeField] private SceneReference gameScene2;
    [SerializeField] private SceneReference mainScene;

    public void LoadGameScene()
    {
        if(Services.GameService.gameMode == GameMode.SinglePlayer)
            SceneManager.LoadSceneAsync(gameScene);
        else
            SceneManager.LoadSceneAsync(gameScene2);
    }

    public void LoadMainScene()
    {
        SceneManager.LoadSceneAsync(mainScene);
    }
}
