using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Level1");
    }
}
