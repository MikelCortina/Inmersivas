using UnityEngine;
using System.Collections;

public class CuboControlador : MonoBehaviour
{
    public Vector3 posicionA = new Vector3(-3, 0, 0);
    public Vector3 posicionB = new Vector3(3, 0, 0);
    public float duracionMovimiento = 3.0f;
    public float duracionRotacion = 2.0f;
    private GameObject cubo;
    private Quaternion rotacionInicial;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(SecuenciaCubo());
        }
    }

    IEnumerator SecuenciaCubo()
    {
        // Instanciar cubo en la posición A
        if (cubo == null)
        {
            cubo = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cubo.transform.position = posicionA;
            rotacionInicial = cubo.transform.rotation;
        }
        yield return new WaitForSeconds(1f);
    }
}
