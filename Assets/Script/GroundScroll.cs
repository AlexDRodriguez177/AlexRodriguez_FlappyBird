using UnityEngine;
using UnityEngine.UIElements;

public class GroundScroll : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public float resetPositionX; 
    public float initalPositionX;

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
