using UnityEngine;

public class ConstrainEyePosition : MonoBehaviour
{
    private readonly float rightBoundary = 0.42f;
    private readonly float leftBoundary = -0.50f;
    private readonly float topBoundary = -0.53f;
    private readonly float bottomBoundary = -0.9f;

    void Update()
    {
        if (transform.position.x > rightBoundary)
            transform.position = new Vector3(rightBoundary, transform.position.y, transform.position.z);
        if (transform.position.x < leftBoundary)
            transform.position = new Vector3(leftBoundary, transform.position.y, transform.position.z);

        if (transform.position.y > topBoundary)
            transform.position = new Vector3(transform.position.x, topBoundary, transform.position.z);
        if (transform.position.y < bottomBoundary)
            transform.position = new Vector3(transform.position.x, bottomBoundary, transform.position.z);
    }
}
