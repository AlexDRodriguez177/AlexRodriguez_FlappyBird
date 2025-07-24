using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    private Rigidbody2D birdRB;
    private Animator birdAnimator;
    private bool isAlive = false;
    private Vector3 initialBirdPosition;
    private Quaternion initialBirdRotation;

    public float maxJumpVelocity = 5f;
    public float maxUpwardAngle = 45f;     
    public float maxDownwardAngle = -90f;  
    public float rotationLerpSpeed = 5f;
    public float gravityScale = 3f;
    /// <summary>
    /// Gets the initial position and rotation of the bird.
    /// Gets the Animator and Rigidbody2D components of the bird.
    /// Sets the gravity scale of the bird's Rigidbody2D to 0 to prevent it from falling immediately makes the bird float.
    /// </summary>
    void Start()
    {
        initialBirdPosition = transform.position;
        initialBirdRotation = transform.rotation;
        birdAnimator = GetComponent<Animator>();
        birdRB = GetComponent<Rigidbody2D>();
        birdRB.gravityScale = 0f; 
    }
    /// <summary>
    /// If the bird is alive, checks for input to jump.
    /// Calls the Jump method when the "Jump" or "Fire1" button is pressed.
    /// Calls the RotateBasedOnVelocity method to adjust the bird's rotation based on its vertical velocity.
    /// </summary>
    void Update()
    {
        if (isAlive)
        {
            if (Input.GetButton("Jump") || Input.GetButton("Fire1"))
            {
                Jump();
            }
            RotateBasedOnVelocity();
        }
    }
    /// <summary>
    /// Uses the Rigidbody2D component to apply an upward force to the bird, simulating a jump.
    /// Calls the Animator to trigger the "Jump" animation.
    /// </summary>
    private void Jump()
    {
        birdRB.linearVelocity = Vector2.up * maxJumpVelocity;
        birdAnimator.SetTrigger("Jump");
    }
    /// <summary>
    /// Holds the bird's rotation based on its vertical velocity.
    /// Sets the tilt based on the vertical velocity of the bird.
    /// Clamps the InverLerp value to ensure it stays within a valid range.
    /// Makes sures the tilt has a smooth transition to the target angle.
    /// Makes sure the angles are clamped to prevent extreme rotations.
    /// </summary>
    void RotateBasedOnVelocity()
    {
        float verticalVelocity = birdRB.linearVelocity.y;

        float tilt = 0f;
        if (verticalVelocity > 0)
        {
            tilt = Mathf.InverseLerp(0, maxJumpVelocity, verticalVelocity);
        }
        else
        {
            tilt = Mathf.InverseLerp(0, -maxJumpVelocity, verticalVelocity);
            if (tilt < 0)
            {
                tilt = 0;
            }
        }
        float targetAngle = 0f;

        if(verticalVelocity > 0)
        {
            targetAngle = Mathf.Lerp(0, maxUpwardAngle, tilt);
        }
        else
        {
            targetAngle = Mathf.Lerp(0, maxDownwardAngle, tilt);
        }
        
        float currentZ = transform.eulerAngles.z;
        if (currentZ > 180)
        {
            currentZ -= 360;
        }

        float newZ = Mathf.Lerp(currentZ, targetAngle, Time.deltaTime * rotationLerpSpeed);
        transform.rotation = Quaternion.Euler(0f, 0f, newZ);
    }
    /// <summary>
    /// Sets the bird to be alive, enabling gravity and resetting its velocity.
    /// </summary>
    public void StartGame()
    {
        isAlive = true;
        birdRB.gravityScale = gravityScale;
        birdRB.linearVelocity = Vector2.zero;
    }
    /// <summary>
    /// Resets the bird's position and rotation to its initial state.
    /// Turns off the bird's gravity and sets it to not alive.
    /// </summary>
    public void ResetBird()
    {
        isAlive = false;
        birdRB.gravityScale = 0f;
        transform.position = initialBirdPosition;
        transform.rotation = initialBirdRotation;
    }
    /// <summary>
    /// Called when the bird collides with an obstacle or the ground.
    /// Makes the bird not alive, stops its movement, and triggers the game over state.
    /// </summary>
    public void Die()
    {
        isAlive = false;
        birdRB.linearVelocity = Vector2.zero;
        GameManager.Instance.GameOver();
    }
    /// <summary>
    /// When the bird collides with an obstacle or the ground, it calls the Die method.
    /// </summary>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }
}
