using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Declaro la variable de la velocidad y el Vector con el que se hace todo
    public float speed = 5f;
    private Vector3 target;

    void Start()
    {
        //Seteo el vector al inicio
        target = transform.position;   
    }

    void Update()
    {
        //Igualo el Vector target a el punto de la pantalla donde hace click izq sin moverse en z porque es 2d
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }

        //Muevo el vector hacia ese punto con la velocidad multiplicada por el tiempo
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
