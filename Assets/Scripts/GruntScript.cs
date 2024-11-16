using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public Transform John; // Referencia al objeto de John
    public GameObject BulletPrefab; // Prefab de la bala que dispara el Grunt

    private int Health = 2; // Salud del Grunt
    private float LastShoot; // Tiempo del �ltimo disparo

    void Update()
    {
        if (John == null) return; // Si no hay referencia a John, sale del m�todo

        // Calcula la direcci�n hacia John
        Vector3 direction = John.position - transform.position;

        // Voltea la direcci�n del Grunt para mirar hacia John
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        // Calcula la distancia horizontal entre el Grunt y John
        float distance = Mathf.Abs(John.position.x - transform.position.x);

        // Dispara si la distancia es menor a 1.0 y ha pasado el tiempo m�nimo entre disparos
        if (distance < 1.0f && Time.time > LastShoot + 0.25f)
        {
            Shoot(); // Llama al m�todo para disparar
            LastShoot = Time.time; // Actualiza el tiempo del �ltimo disparo
        }
    }

    private void Shoot()
    {
        // Determina la direcci�n del disparo bas�ndose en la escala del objeto
        Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);

        // Instancia la bala y la posiciona en la direcci�n de disparo
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction); // Establece la direcci�n de la bala
    }

    public void Hit()
    {
        Health -= 1; // Reduce la salud en 1
        if (Health == 0) Destroy(gameObject); // Destruye el Grunt si la salud llega a 0
    }
}

