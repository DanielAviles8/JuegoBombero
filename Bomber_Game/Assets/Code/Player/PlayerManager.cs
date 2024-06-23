using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    public uint HP;
    
    // Start is called before the first frame update
    void Start()
    {
        HP = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            HP--;
            if (HP <= 0)
            {
              //  GameManager=GetComponent<GameManager>();
             //   SetGameState(GameState.GameOver);
                // hay que referenciar al GameManager     no me acuerdo xD
            }
            Debug.Log("ahh me quemo");
            // Aquí puedes agregar lógica adicional cuando el jugador colisiona con una pared
        }
    }
    
}
