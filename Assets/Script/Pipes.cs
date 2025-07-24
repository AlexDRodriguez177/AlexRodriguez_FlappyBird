using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float destroyX = -10f;
    private bool scored = false;
   
    /// <summary>
    /// Moves the pipes to the left by using the move speed and multiplying it by time.delttime for a cosistent frame rate
    /// If the pipe position is less than 0 and has not been scored yet it will set score to true and increase the score
    /// Once the object moves past the destroy float on the x axis then the game object will be destoryed automatically
    /// </summary>
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (!scored && transform.position.x < 0)
        {
            scored = true;
            GameManager.Instance.IncreaseScore();
        }

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}
