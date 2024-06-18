using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HideObjective : MonoBehaviour
{
    public GameObject TextBox;
    private bool Objective = false;
    // Start is called before the first frame update
    void Start()
    {
        TextBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SetObjectiveInScreen();
    }
    public void SetObjectiveInScreen()
    {
        if (Objective == true && Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Apagado");
            TextBox.SetActive(false);
            Objective = false;
            return;
        }

        if (Objective == false && Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Encendido");
            TextBox.SetActive(true);
            Objective = true;
        }
    }
}
