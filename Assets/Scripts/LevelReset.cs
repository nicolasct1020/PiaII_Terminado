using UnityEngine;
using UnityEngine.SceneManagement; // Aseg�rate de incluir esta l�nea para usar SceneManager

public class LevelReset : MonoBehaviour
{
    // L�mite de ca�da en el eje y
    public float fallLimit = -10f;

    // Update se llama una vez por frame
    void Update()
    {
        // Verifica si la posici�n 'y' del personaje es menor al l�mite de ca�da
        if (transform.position.y < fallLimit)
        {
            // Reinicia la escena actual
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
