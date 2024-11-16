using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform John; // Referencia al objeto de John para seguir su posición

    void Update()
    {
        if (John != null) // Verifica que la referencia a John no sea nula
        {
            Vector3 position = transform.position; // Obtiene la posición actual de la cámara
            position.x = John.position.x; // Actualiza solo la posición x para que la cámara siga a John horizontalmente
            transform.position = position; // Asigna la nueva posición a la cámara
        }
    }
}

