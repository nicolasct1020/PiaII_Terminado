using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed; // Velocidad de la bala
    public AudioClip Sound; // Sonido que se reproduce al disparar

    private Rigidbody2D Rigidbody2D; // Referencia al componente Rigidbody2D
    private Vector3 Direction; // Dirección de movimiento de la bala

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody2D del objeto
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound); // Reproduce el sonido una vez
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed; // Mueve la bala en la dirección con la velocidad definida
    }

    public void SetDirection(Vector3 direction)
    {
        Direction = direction; // Establece la dirección de la bala
    }

    public void DestroyBullet()
    {
        Destroy(gameObject); // Destruye el objeto de la bala
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GruntScript grunt = other.GetComponent<GruntScript>(); // Comprueba si colisiona con un "Grunt"
        JohnMovement john = other.GetComponent<JohnMovement>(); // Comprueba si colisiona con "John"

        if (grunt != null)
        {
            grunt.Hit(); // Si es "Grunt", llama a su método Hit
        }
        if (john != null)
        {
            john.Hit(); // Si es "John", llama a su método Hit
        }
        DestroyBullet(); // Destruye la bala después de la colisión
    }
}
