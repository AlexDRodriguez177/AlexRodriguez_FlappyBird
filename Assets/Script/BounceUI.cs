using System.Collections;
using UnityEngine;

public class BounceUI : MonoBehaviour
{
    public float bounceHeight = 50f;        
    public float bounceDuration = 0.5f;     

    private RectTransform rectTransform;
    private Vector2 startAnchoredPos;

    /// <summary>
    /// Gets the RectTransform component and initializes the starting position.
    /// Sets the initial anchored position of the UI element.
    /// Starts the bouncing coroutine when the script is enabled.
    /// </summary>
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startAnchoredPos = rectTransform.anchoredPosition;
        StartCoroutine(BounceUp());
    }
    /// <summary>
    /// Starts the boucing effect at the achored position of the UI element.
    /// Moves the UI element up by a specified height over a specified duration.
    /// Starts the coroutine to move the UI element down after it has moved up.
    /// </summary>
    private IEnumerator BounceUp()
    {
        yield return StartCoroutine(MoveVertical(startAnchoredPos, startAnchoredPos + Vector2.up * bounceHeight, bounceDuration));
        StartCoroutine(BounceDown());
    }
    /// <summary>
    /// Starts the boucing effect at the achored position of the UI element.
    /// Moves the UI element down to its original position after it has moved up.
    /// starts the coroutine to move the UI element up again after it has moved down.
    /// </summary>
    private IEnumerator BounceDown()
    {
        yield return StartCoroutine(MoveVertical(startAnchoredPos + Vector2.up * bounceHeight, startAnchoredPos, bounceDuration));
        StartCoroutine(BounceUp());
    }
    /// <summary>
    /// Smoothly moves the UI element from the start position to the end position over a specified duration.
    /// Uses a timer to interpolate the position of the UI element.
    /// Resets the timer when the movement is complete.
    /// Sets the anchored position of the UI element to the end position when the movement is complete.
    /// </summary>
    private IEnumerator MoveVertical(Vector2 startPosition, Vector2 endPosition, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        rectTransform.anchoredPosition = endPosition;
    }
    /// <summary>
    /// Restarts the bouncing effect by starting the BounceUp coroutine again.
    /// Uses this method to reset the bounce effect when the game is restarted or when needed.
    /// </summary>
    public void RestartBounce()
    {
        StartCoroutine(BounceUp());
    }
}
