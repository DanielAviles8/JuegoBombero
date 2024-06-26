using UnityEngine;

public class Object : MonoBehaviour
{
    public GameObject Player;
    public static bool pickedSmokeSign;
    public static bool pickedEmergencyExit;
    private bool pickedExtinguisher;
    private bool firstStage0;
    private bool firstStage1;
    private bool activeDoor;
    public GameObject SmokeSign;
    public GameObject SmokeFinal;
    public GameObject Smoke;
    public GameObject FirstExit;
    public GameObject SecondExit;
    public GameObject FinalExit;
    public GameObject Extinguisher;
    public GameObject ClosedDoor;
    public GameObject OpenedDoor;
    public GameObject Fire;

    // Start is called before the first frame update
    void Start()
    {
        SmokeFinal.SetActive(false);
        Smoke.SetActive(false);
        SecondExit.SetActive(false);
        FinalExit.SetActive(false);
        ClosedDoor.SetActive(false);
        pickedSmokeSign = false;
        pickedEmergencyExit = false;
        firstStage0 = false;
        firstStage1 = false;
        activeDoor = false;
    }

    // Update is called once per frame
    void Update()
    {
        PickItem();
        PickExtinguisher();
        ActiveDoor();
        Debug.Log(activeDoor);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SmokeSign"))
        {
            pickedSmokeSign = true;
        }
        if (other.gameObject.CompareTag("FirstExit"))
        {
            pickedEmergencyExit = true;
        }
        if (other.gameObject.CompareTag("FinalSmoke") && SmokeFinal == true)
        {
            Smoke.SetActive(true);
            Smoke.transform.position = SmokeFinal.transform.position;
            firstStage0 = true;
        }
        if (other.gameObject.CompareTag("FinalExit"))
        {
            FinalExit.SetActive(true);
            FinalExit.transform.position = SecondExit.transform.position;
            firstStage1 = true;
        }

        if (other.gameObject.CompareTag("Extinguisher") && activeDoor == true)
        {
            pickedExtinguisher = true;
        }

        if (other.gameObject.CompareTag("OpenDoor"))
        {
            if(activeDoor == true)
            {
                OpenedDoor.SetActive(false);
                ClosedDoor.SetActive(true);
            }
        }
        if (other.gameObject.CompareTag("CeaseFire") && pickedExtinguisher == true)
        {
            Fire.SetActive(false);
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
            FirstExit.SetActive(false);
            SecondExit.SetActive(true);
            SecondExit.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);            
        }
    }
    private void PickExtinguisher()
    {
        if(pickedExtinguisher == true)
        {
            Extinguisher.transform.parent = Player.transform;
            Extinguisher.transform.position = Player.transform.position;
        }
    }
    private void ActiveDoor()
    {
        if(firstStage0 == true && firstStage1 == true)
        {
            activeDoor = true;
        }
    }
}
