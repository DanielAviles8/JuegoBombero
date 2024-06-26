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
        // Aquí podrías inicializar tu juego con el estado inicial que desees
       // SetGameState(GameState.LoadMenu);
    }

    private void Update()
    {
        //Debug.Log(gameState);
        // Aquí podrías agregar lógica de actualización según el estado actual
    }

    // Método para cambiar el estado del juego
    public void SetGameState(GameState newState)
    {
        if (gameState == newState)
        {
            Debug.LogWarning($"El juego ya está en estado {newState}");
            return;
        }

        gameState = newState;
        Debug.Log($"Estado del juego cambiado a: {gameState}");

        // Aquí puedes añadir lógica adicional según el estado cambiado
        switch (gameState)
        {
            case GameState.None:
                // Ejemplo de lo que podrías hacer en el estado None
                break;
            case GameState.LoadMenu:
              //  SceneManager.LoadScene("SampleScene");
                break;
            case GameState.MainMenu:
                // Ejemplo de lo que podrías hacer en el estado MainMenu
                break;
            case GameState.Loading:
                // Ejemplo de lo que podrías hacer en el estado Loading
                break;
            case GameState.Playing:
                // Ejemplo de lo que podrías hacer en el estado Playing
                break;
            case GameState.GameOver:
                // Ejemplo de lo que podrías hacer en el estado GameOver
                Debug.Log("GameOver");
                break;
            default:
                break;
        }
    }

    // Método para obtener el estado actual del juego
    public GameState GetGameState()
    {
        return gameState;
    }
}
