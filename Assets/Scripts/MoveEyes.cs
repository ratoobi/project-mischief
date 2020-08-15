using UnityEngine;

public class MoveEyes : MonoBehaviour
{
    private Vector3 mousePosition;
    private readonly float xEyeOffset = -0.079f;
    private readonly float yEyeOffset = -0.704f;
    private readonly float xRatio = 0.0532f; // horizontal ratio between cheese and eyes position
    private readonly float yRatio = 0.0385f; // vertical ratio between cheese and eyes position

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3((mousePosition.x * xRatio) + xEyeOffset, (mousePosition.y * yRatio) + yEyeOffset, transform.position.z);
    }
}
