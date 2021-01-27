﻿using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public void nextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex < 3){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else{
            Application.Quit();
        }
    }
}
