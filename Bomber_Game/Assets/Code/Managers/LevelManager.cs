using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadLevel1(string Level1)
    {
        SceneManager.LoadScene(Level1);
    }
}
