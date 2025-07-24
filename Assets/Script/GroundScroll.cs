using UnityEngine;
using UnityEngine.UIElements;

public class GroundScroll : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public float resetPositionX; 
    public float initalPositionX;
    /// <summary>
    /// Moves the ground to the left at a specified speed
    /// Keeps a cosistent speed for the ground to scroll
    /// When the ground reaches a certain position on the x-axis, it resets its position
    /// Sets the position of the ground to its initial position on the x-axis
    /// Makes the new position the initial position of the ground
    /// </summary>
    void Update()
    {
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

        if (transform.position.x <= resetPositionX)
        {
            Vector2 newPosition = new Vector2(initalPositionX, transform.position.y);
            transform.position = newPosition;
        }
    }
}
