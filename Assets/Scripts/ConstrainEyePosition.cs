using UnityEngine;

public class ConstrainEyePosition : MonoBehaviour
{
    private readonly float rightBoundary = 0.7f;
    private readonly float leftBoundary = -0.09f;
    private readonly float upperBoundary = 0.1f;
    private readonly float lowerBoundary = -0.2f;

    void Update()
    {
        if (transform.position.x > rightBoundary)
            transform.position = new Vector3(rightBoundary, transform.position.y, transform.position.z);
        if (transform.position.x < leftBoundary)
            transform.position = new Vector3(leftBoundary, transform.position.y, transform.position.z);

        if (transform.position.y > upperBoundary)
            transform.position = new Vector3(transform.position.x, upperBoundary, transform.position.z);
        if (transform.position.y < lowerBoundary)
            transform.position = new Vector3(transform.position.x, lowerBoundary, transform.position.z);
    }
}
