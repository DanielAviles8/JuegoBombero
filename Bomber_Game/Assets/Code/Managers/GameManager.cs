using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    None,
    LoadMenu,
    MainMenu,
    Loading,
    Playing,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    // Estado actual del juego
    public static GameState gameState = GameState.None;

    private void Awake()
    {
        // Aseguramos que solo haya una instancia de GameManager
        if (gameManager != null && gameManager != this)
        {
            Destroy(gameObject);
            return;
        }

        gameManager = this;
       // DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        // Aqu� podr�as inicializar tu juego con el estado inicial que desees
       // SetGameState(GameState.LoadMenu);
    }

    private void Update()
    {
        //Debug.Log(gameState);
        // Aqu� podr�as agregar l�gica de actualizaci�n seg�n el estado actual
    }

    // M�todo para cambiar el estado del juego
    public void SetGameState(GameState newState)
    {
        if (gameState == newState)
        {
            Debug.LogWarning($"El juego ya est� en estado {newState}");
            return;
        }

        gameState = newState;
        Debug.Log($"Estado del juego cambiado a: {gameState}");

        // Aqu� puedes a�adir l�gica adicional seg�n el estado cambiado
        switch (gameState)
        {
            case GameState.None:
                // Ejemplo de lo que podr�as hacer en el estado None
                break;
            case GameState.LoadMenu:
               
                break;
            case GameState.MainMenu:
                // Ejemplo de lo que podr�as hacer en el estado MainMenu
                break;
            case GameState.Loading:
                // Ejemplo de lo que podr�as hacer en el estado Loading
                SceneManager.LoadScene("Level1");
                break;
            case GameState.Playing:
                // Ejemplo de lo que podr�as hacer en el estado Playing
                break;
            case GameState.GameOver:
                // Ejemplo de lo que podr�as hacer en el estado GameOver
                Debug.Log("GameOver");
                break;
            default:
                break;
        }
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    // M�todo para obtener el estado actual del juego
    public GameState GetGameState()
    {
        return gameState;
    }
}
