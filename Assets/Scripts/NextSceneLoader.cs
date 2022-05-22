using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NextSceneLoader:MonoBehaviour
{
    void OnEnable()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}