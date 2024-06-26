using UnityEngine;

public class Object : MonoBehaviour
{
    public static bool pickedSmokeSign;
    public static bool pickedEmergencyExit;
    public GameObject SmokeSign;
    public GameObject SmokeFinal;
    public GameObject Smoke;
    public GameObject EmergencyExit;
    
    // Start is called before the first frame update
    void Start()
    {
        SmokeFinal.SetActive(false);
        Smoke.SetActive(false);
        pickedSmokeSign = false;
        pickedEmergencyExit = false;
    }

    // Update is called once per frame
    void Update()
    {
        PickItem();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SmokeSign"))
        {
            pickedSmokeSign = true;
            Debug.Log("señal de fumar recogida");
        }
        if (other.gameObject.CompareTag("EmergencyExit"))
        {
            pickedEmergencyExit = true;
            Debug.Log("Señal de salida de emergencia recogida");
        }
        if (other.gameObject.CompareTag("FinalSmoke") && SmokeFinal == true)
        {
            Debug.Log("Objeto colocado");
            Smoke.SetActive(true);
            Smoke.transform.position = SmokeFinal.transform.position;
        }
    }
    private void PickItem()
    {
        if (pickedSmokeSign == true)
        {
            SmokeSign.SetActive(false);
            SmokeFinal.SetActive(true);
            SmokeFinal.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        }

        if(pickedEmergencyExit == true)
        {
            EmergencyExit.SetActive(false);
        }
    }
}
