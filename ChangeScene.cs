﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeScene : MonoBehaviour {
    public void LoadTargetScene(int targetScene)
    {
        SceneManager.LoadScene(targetScene);
    }

    public void LoadTargetScene(string targetScene)
    {
        SceneManager.LoadScene(targetScene);
    }

    public void AddTargetScene(int targetScene)
    {
        SceneManager.LoadScene(targetScene, LoadSceneMode.Additive);
    }

    public void AddTargetScene(string targetScene)
    {
        SceneManager.LoadScene(targetScene, LoadSceneMode.Additive);
    }

    public void DeleteTargetScene(int targetScene)
    {
        SceneManager.UnloadScene(targetScene);
    }

    public void DeleteTargetScene(string targetScene)
    {
        SceneManager.UnloadScene(targetScene);
    }

    public void ToogleTargetScene(string targetScene)
    {
        if (SceneManager.GetSceneByName(targetScene).isLoaded)
        {
            SceneManager.UnloadScene(targetScene);
        }
        else
        {
            SceneManager.LoadScene(targetScene, LoadSceneMode.Additive);
        }            
    }
}
