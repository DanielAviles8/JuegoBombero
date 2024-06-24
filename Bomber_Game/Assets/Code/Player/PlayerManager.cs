using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    public int HP;
    

    
    // Start is called before the first frame update
    void Start()
    {
        HP = 1;
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
                HP = 0;
                GameManager.gameState = GameState.GameOver; 
                
            }
            Debug.Log("ahh me quemo");
            
        }
    }
    
}
