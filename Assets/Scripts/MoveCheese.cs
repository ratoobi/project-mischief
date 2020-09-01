using UnityEngine;

public class MoveCheese : MonoBehaviour
{
    private Vector3 mousePosition;
    private Vector2 direction;
    private readonly float moveSpeed = 500.0f;
    
    Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Cursor.lockState = CursorLockMode.Confined;

    }

    void FixedUpdate()
    {
        rb2D.bodyType = RigidbodyType2D.Dynamic;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - transform.position).normalized;
        rb2D.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }
}
