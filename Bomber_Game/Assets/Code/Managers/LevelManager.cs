using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    int levelIndex = 1;
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        
    }
}
