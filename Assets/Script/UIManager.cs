using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject scoreUI;
    public GameObject titleScreen;
    public GameObject tutorialScreen;
    public GameObject gameOverScreen;

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ShowStart()
    {
        titleScreen.SetActive(true);
        tutorialScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        scoreUI.SetActive(false);
    }

    public void HideStart()
    {
        titleScreen.SetActive(false);
    }

    public void ShowReady()
    {
        titleScreen.SetActive(false);
        tutorialScreen.SetActive(true);
        gameOverScreen.SetActive(false);
    }

    public void HideReady()
    {
        tutorialScreen.SetActive(false);
        scoreUI.SetActive(true);
    }

    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
    }


}
