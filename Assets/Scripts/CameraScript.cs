using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform John; // Referencia al objeto de John para seguir su posici�n

    void Update()
    {
        if (John != null) // Verifica que la referencia a John no sea nula
        {
            Vector3 position = transform.position; // Obtiene la posici�n actual de la c�mara
            position.x = John.position.x; // Actualiza solo la posici�n x para que la c�mara siga a John horizontalmente
            transform.position = position; // Asigna la nueva posici�n a la c�mara
        }
    }
}

