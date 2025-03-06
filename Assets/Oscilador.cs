using UnityEngine;

public class Rotador : MonoBehaviour
{
    public float velocidadRotacion = 45f; // Velocidad de rotación en grados por segundo

    void Update()
    {
        transform.Rotate(Vector3.right * velocidadRotacion * Time.deltaTime);
    }
}
