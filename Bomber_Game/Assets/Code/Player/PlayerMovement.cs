using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 target;
    private Animator animator;
    private Vector2 currentPos;
    private Vector2 direction;
    private Vector3 previous = Vector3.zero;
    private Vector2 velocity;    

    void Start()
    {
        animator = GetComponent<Animator>();
        target = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetTargetPosition();
        }
   
        GetDirection();
        GetVelocity();
        UpdateAnimation();
    }

    void SetTargetPosition()
    {
        // Obtener posición en el mundo donde se hizo clic
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z; 
    }

    void UpdateAnimation()
    {
        float xAbsolute = Mathf.Abs(direction.x);
        float yAbsolute = Mathf.Abs(direction.y);
        // Calcular dirección para determinar la animación adecuada
        //Vector2 direction = (target - transform.position).normalized;
        
        // Actualizar los parámetros del Animator para la dirección y el estado de caminar
        //animator.SetFloat("MoveX", direction.x);
        //animator.SetFloat("MoveY", direction.y);
        
        bool isWalking = direction.magnitude != 0f;

        
            
        animator.SetBool("IsWalking", isWalking);
        
        if (xAbsolute > yAbsolute)
        {
            animator.SetBool("WalkingDown", false);
            animator.SetBool("WalkingUp", false);
            if(direction.x < 0f)
            {
                animator.SetBool("WalkingLeft", true);
                animator.SetBool("WalkingRight", false);
            }
            else
            {
                animator.SetBool("WalkingLeft", false);
                animator.SetBool("WalkingRight", true);
            }  
        }
        else
        {

            animator.SetBool("WalkingLeft", false);
            animator.SetBool("WalkingRight", false);

            if(direction.y < 0f)
            {
                animator.SetBool("WalkingDown", true);
                animator.SetBool("WalkingUp", false);
            }
            else
            {
                animator.SetBool("WalkingDown", false);
                animator.SetBool("WalkingUp", true);
                animator.SetBool("WalkingRight", false);
                animator.SetBool("WalkingLeft", false);
            }
        }

        if (direction.x == 0f && direction.y == 0f)
        {
            isWalking = false;
        }

        if (isWalking == false)
        {
            animator.SetBool("WalkingRight", false);
            animator.SetBool("WalkingLeft", false);
            animator.SetBool("WalkingDown", false);
            animator.SetBool("WalkingUp", false);
        }
    }

    void FixedUpdate()
    {
        // Mover al jugador hacia el objetivo
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void GetDirection()
    {
        var fwdDotProduct = Vector3.Dot(transform.forward, velocity);
        var upDotProduct = Vector3.Dot(transform.up, velocity);
        var rightDotProduct = Vector3.Dot(transform.right, velocity);

        direction  = new Vector3(rightDotProduct, upDotProduct, fwdDotProduct).normalized;

        
    }
    private void GetVelocity()
    {
        velocity = (transform.position - previous) / Time.deltaTime;
        previous = transform.position;
    }
}
