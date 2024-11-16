using UnityEngine;
using UnityEngine.SceneManagement; // Asegúrate de incluir esta línea para usar SceneManager

public class LevelReset : MonoBehaviour
{
    // Límite de caída en el eje y
    public float fallLimit = -10f;

    // Update se llama una vez por frame
    void Update()
    {
        // Verifica si la posición 'y' del personaje es menor al límite de caída
        if (transform.position.y < fallLimit)
        {
            // Reinicia la escena actual
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
