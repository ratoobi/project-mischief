using UnityEngine;

public class MoveEyes : MonoBehaviour
{
    private Vector3 mousePosition;
    private readonly float moveSpeed = 80.0f;
    private Vector2 direction;

    Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        direction = (mousePosition - transform.position).normalized;
        rb2D.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }
}
