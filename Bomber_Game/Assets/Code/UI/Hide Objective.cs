using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideObjective : MonoBehaviour
{
    public GameObject Text;
    public bool Objective = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Objective == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Apagado");
                Text.SetActive(false);
                Objective = false;
            }
        }
       
        /*if(Objective == false)
        {
             if (Input.GetKeyDown(KeyCode.Q))
                {
                    Debug.Log("Encendido");
                    Text.SetActive(true);
                    Objective = true;
                }
         }*/
        
    }
}
