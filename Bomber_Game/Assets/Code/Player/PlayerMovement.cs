using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 target;
    private Animator animator; // Referencia al componente Animator

    void Start()
    {
        // animator.SetBool("IsWalking", false);
        target = transform.position;
        animator = GetComponent<Animator>(); // Obtener referencia al Animator
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
        // Obtener posici�n en el mundo donde se hizo clic
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z; // Mantener la misma profundidad (z)
    }

    void UpdateAnimation()
    {
        // Calcular direcci�n para determinar la animaci�n adecuada
        Vector2 direction = (target - transform.position).normalized;

        // Determinar la direcci�n principal basada en los �ngulos
        float angle = Vector2.SignedAngle(Vector2.up, direction);
        int directionIndex = Mathf.RoundToInt(angle / 90f); // 0: up, 1: right, 2: down, 3: left

        // Actualizar los par�metros del Animator para la direcci�n y el estado de caminar
        animator.SetFloat("MoveX", direction.x);
        animator.SetFloat("MoveY", direction.y);

        if (direction.magnitude > 0.1f)
        {
            animator.SetBool("IsWalking", true);
        } else
        {
            animator.SetBool("IsWalking", false);
        }

        // Asignar la direcci�n correcta de caminar e idle
        string[] walkAnimations = { "runUp", "runRight", "runDown", "runLeft" };
        string[] idleAnimations = { "idleUp", "idleRight", "idleDown", "idleLeft" };

        animator.Play(walkAnimations[directionIndex], -1, 0); // -1 para forzar la reproducci�n desde el inicio
        animator.Play(idleAnimations[directionIndex], -1, 0);
    }

    void FixedUpdate()
    {
        // Mover al jugador hacia el objetivo
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Funciona");
            // Aqu� puedes agregar l�gica adicional cuando el jugador colisiona con una pared
        }
    }
}
