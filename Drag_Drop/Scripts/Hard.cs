using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hard : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
