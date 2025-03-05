using UnityEngine;
using System.Collections.Generic;

public class Interpolador : MonoBehaviour
{
    public List<Vector3> interpoladorList = new List<Vector3>();
    public float duracion = 0.5f;
    private float tiempoActual = 0f;
    private int indiceActual = 0;

    void Start()
    {
        // Inicializar puntos
        interpoladorList.Add(new Vector3(10, 0, 0));
        interpoladorList.Add(new Vector3(10, 10, 0));
        interpoladorList.Add(new Vector3(20, 10, 0));
        interpoladorList.Add(new Vector3(40, 20, 0));

        transform.position = interpoladorList[0];
    }

    private void Update()
    {
        if (indiceActual < interpoladorList.Count - 1)
        {
            tiempoActual += Time.deltaTime / duracion;
            transform.position = Vector3.Lerp(interpoladorList[indiceActual], interpoladorList[indiceActual + 1], tiempoActual);

            // Si completó la interpolación entre los puntos
            if (tiempoActual >= 1f)
            {
                tiempoActual = 0f;
                indiceActual++;

                // Asegurar que el objeto termine exactamente en el último punto
                if (indiceActual >= interpoladorList.Count - 1)
                {
                    transform.position = interpoladorList[indiceActual];
                }
            }
        }
    }
}



