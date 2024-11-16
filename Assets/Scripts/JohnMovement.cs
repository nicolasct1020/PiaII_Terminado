using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    public float Speed; // Velocidad de movimiento de John
    public float JumpForce; // Fuerza del salto
    public GameObject BulletPrefab; // Prefab de la bala

    private Rigidbody2D Rigidbody2D; // Referencia al componente Rigidbody2D
    private Animator Animator; // Referencia al componente Animator
    private float Horizontal; // Almacena el input horizontal
    private bool Grounded; // Indica si John está en el suelo
    private float LastShoot; // Tiempo del último disparo
    private int Health = 15; // Salud de John

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody2D del objeto
        Animator = GetComponent<Animator>(); // Obtiene el Animator del objeto
    }

    private void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal"); // Captura el input horizontal

        // Voltea la dirección de John según el input
        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("running", Horizontal != 0.0f); // Activa la animación de correr si hay movimiento

        // Dibuja un rayo para detectar si John está en el suelo
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;

        // Realiza el salto si se presiona la tecla W y John está en el suelo
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

        // Dispara si se presiona la barra espaciadora y ha pasado suficiente tiempo desde el último disparo
        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.20f)
        {
            Shoot();
            LastShoot = Time.time; // Actualiza el tiempo del último disparo
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y); // Actualiza la velocidad en función del input horizontal
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce); // Aplica una fuerza hacia arriba para saltar
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = Vector3.right; // Determina la dirección de disparo
        else direction = Vector3.left;

        // Instancia la bala y establece su dirección
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    public void Hit()
    {
        Health -= 1; // Reduce la salud
        if (Health == 0) Destroy(gameObject); // Destruye a John si la salud llega a 0
    }
}
