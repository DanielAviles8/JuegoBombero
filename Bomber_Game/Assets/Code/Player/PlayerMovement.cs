using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 target;
    private Animator animator; // Referencia al componente Animator
    

    void Start()
    {
        animator = GetComponent<Animator>(); // Obtener referencia al Animator
        target = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetTargetPosition();
        }

        UpdateAnimation();
    }

    void SetTargetPosition()
    {
        // Obtener posición en el mundo donde se hizo clic
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z; // Mantener la misma profundidad (z)
    }

    void UpdateAnimation()
    {
        // Calcular dirección para determinar la animación adecuada
        Vector2 direction = (target - transform.position).normalized;
        
        // Actualizar los parámetros del Animator para la dirección y el estado de caminar
        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);
        bool WalkingLeft;
        bool WalkingUp;
        bool WalkingRight;
        bool WalkingDown;
        bool isWalking = direction.magnitude != 0f;
        if(direction.magnitude == 0f)
        {
            isWalking = false;
        }

        if (direction.x < 0f)
        {
            WalkingLeft = true;
        }
        else
        {
            WalkingLeft= false;
        }

        if(direction.y > 0f)
        {
            WalkingUp = true;
        }
        else
        {
            WalkingUp = false;
        }

        if(direction.x > 0f)
        {
            WalkingRight = true;
        }
        else
        {
            WalkingRight= false;
        }
        
        if(direction.y < 0f)
        {
            WalkingDown = true;
        }
        else
        {
            WalkingDown= false;
        }

        animator.SetBool("IsWalking", isWalking);
        animator.SetBool("WalkingLeft", WalkingLeft);
        animator.SetBool("WalkingUp", WalkingUp);
        animator.SetBool("WalkingRight", WalkingRight);
        animator.SetBool("WalkingDown", WalkingDown);
    }

    void FixedUpdate()
    {
        // Mover al jugador hacia el objetivo
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
