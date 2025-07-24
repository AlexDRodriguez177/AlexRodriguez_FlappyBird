using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject scoreUI;
    public GameObject titleScreen;
    public GameObject tutorialScreen;
    public GameObject gameOverScreen;

    /// <summary>
    /// This method updates the score displayed in the UI.
    /// Takes an integer score as input and converts it to a string
    /// It stores the score in the scoreText component.
    /// </summary>
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
    /// <summary>
    /// When the game starts, this method is called to show the title screen
    /// Turns off the tutorial, game over screen, and Score UI.
    /// This method is called by the GameManager to initialize the UI.
    /// </summary>
    public void ShowStart()
    {
        titleScreen.SetActive(true);
        tutorialScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        scoreUI.SetActive(false);
    }
    /// <summary>
    /// Turns off the title screen or sets it inactive.
    /// </summary>
    public void HideStart()
    {
        titleScreen.SetActive(false);
    }
    /// <summary>
    /// Once the player is ready to play, this method is called to show the tutorial screen
    /// Turns off the title screen and game over screen.
    /// </summary>
    public void ShowReady()
    {
        titleScreen.SetActive(false);
        tutorialScreen.SetActive(true);
        gameOverScreen.SetActive(false);
    }
    /// <summary>
    /// Hides the tutorial screen and shows the score UI.
    /// </summary>
    public void HideReady()
    {
        tutorialScreen.SetActive(false);
        scoreUI.SetActive(true);
    }
    /// <summary>
    /// Turns on game over screen
    /// </summary>
    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
