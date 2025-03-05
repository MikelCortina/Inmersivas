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

        // Mover a la posición B
        yield return StartCoroutine(MoverObjeto(cubo, posicionA, posicionB, duracionMovimiento));

        yield return new WaitForSeconds(1f);

        // Rotar 90 grados en Y
        Quaternion rotacionFinal = Quaternion.Euler(0, 90, 0) * cubo.transform.rotation;
        yield return StartCoroutine(RotarObjeto(cubo, cubo.transform.rotation, rotacionFinal, duracionRotacion));

        // Esperar 1 segundo
        yield return new WaitForSeconds(1f);

        // Regresar a posición y rotación inicial
        yield return StartCoroutine(MoverObjeto(cubo, posicionB, posicionA, duracionMovimiento));
        yield return StartCoroutine(RotarObjeto(cubo, cubo.transform.rotation, rotacionInicial, duracionRotacion));
    }


    IEnumerator MoverObjeto(GameObject obj, Vector3 inicio, Vector3 fin, float duracion)
    {
        float tiempo = 0f;
        while (tiempo < 1f)
        {
            tiempo += Time.deltaTime / duracion;
            obj.transform.position = Vector3.Lerp(inicio, fin, tiempo);
            yield return null;
        }
    }

    IEnumerator RotarObjeto(GameObject obj, Quaternion inicio, Quaternion fin, float duracion)
    {
        float tiempo = 0f;
        while (tiempo < 1f)
        {
            tiempo += Time.deltaTime / duracion;
            obj.transform.rotation = Quaternion.Slerp(inicio, fin, tiempo);
            yield return null;
        }
    }
}
