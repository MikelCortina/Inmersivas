using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float speed = 10f; // Velocidad de movimiento
    public float jumpForce = 5f; // Fuerza del salto
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtiene el Rigidbody
    }

    void Update()
    {
        MoveBall();
        Jump();
    }

    void MoveBall()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
