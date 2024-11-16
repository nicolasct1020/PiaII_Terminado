using UnityEngine;
using UnityEngine.SceneManagement;  // Necesario para cargar escenas

public class RedBarrelCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificamos si el objeto que colisiona es el jugador (John)
        if (other.CompareTag("Player"))
        {
            // Llamamos a la función para reiniciar el nivel
            RestartLevel();
        }
    }

    // Función para reiniciar el nivel
    private void RestartLevel()
    {
        // Obtener el nombre de la escena activa y recargarla
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
