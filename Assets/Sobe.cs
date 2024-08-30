using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float speed = 5f;   // Adjust the speed as needed
    public float maxY = 10f;   // Adjust the maximum Y position
    public float minY = -10f;  // Adjust the minimum Y position

    private int direction = 1;  // 1 for moving up, -1 for moving down

    // Update is called once per frame
    void Update()
    {
        // Move the platform up or down based on the direction
        transform.Translate(Vector3.up * direction * speed * Time.deltaTime);

        // Check if the platform has reached the maximum or minimum Y position
        if (transform.position.y >= maxY)
        {
            // Change direction to move down
            direction = -1;
        }
        else if (transform.position.y <= minY)
        {
            // Change direction to move up
            direction = 1;
        }
    }
}
