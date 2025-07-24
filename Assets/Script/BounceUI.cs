using System.Collections;
using UnityEngine;

public class BounceUI : MonoBehaviour
{
    public float bounceHeight = 50f;        
    public float bounceDuration = 0.5f;     

    private RectTransform rectTransform;
    private Vector2 startAnchoredPos;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startAnchoredPos = rectTransform.anchoredPosition;

        StartCoroutine(BounceUp());
    }

    private IEnumerator BounceUp()
    {
        yield return StartCoroutine(MoveVertical(startAnchoredPos, startAnchoredPos + Vector2.up * bounceHeight, bounceDuration));
        StartCoroutine(BounceDown());
    }

    private IEnumerator BounceDown()
    {
        yield return StartCoroutine(MoveVertical(startAnchoredPos + Vector2.up * bounceHeight, startAnchoredPos, bounceDuration));
        StartCoroutine(BounceUp());
    }

    private IEnumerator MoveVertical(Vector2 from, Vector2 to, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        rectTransform.anchoredPosition = to;
    }

    public void RestartBounce()
    {
        StartCoroutine(BounceUp());
    }
}
