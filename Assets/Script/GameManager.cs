using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Bird bird;
    public PipeSpawner pipeSpawner;
    public UIManager uiManager;
    public BounceUI bounceUI;
    private int score = 0;
    public AudioSource centeralAudio;
    public AudioClip startClip;
    public AudioClip scoreClip;
    /// <summary>
    /// Allows the GameManager to be a singleton instance.
    /// Turns off the PipeSpawner component to prevent pipes from spawning at the start.
    /// </summary>
    void Awake()
    {
        Instance = this;
        pipeSpawner.enabled = false;
    }
    /// <summary>
    /// Calls the ShowStart method from the UIManager to display the start screen.
    /// Turns off the Bird game object to hide it at the start of the game.
    /// </summary>
    void Start()
    {
        uiManager.ShowStart();
        bird.gameObject.SetActive(false);
    }
    /// <summary>
    /// When the game is reset, this method is called to reset the game state.
    /// Finds all the pipes with the script attached to them
    /// Collects them in an arry and destroys them.
    /// Resets the score to 0 and updates the UI.
    /// Resets the UI to bounce
    /// Resets the bird and turns it off.
    /// Sets timer to 1;
    /// </summary>
    public void ResetGame()
    {
        Pipes[] leftOverObstcles = FindObjectsByType<Pipes>(FindObjectsSortMode.None);
        foreach(Pipes obstacle in leftOverObstcles)
        {
            Destroy(obstacle.gameObject);
        }
        score = 0;
        uiManager.UpdateScore(score);

        uiManager.ShowStart();
        bounceUI.RestartBounce();
        pipeSpawner.enabled = false;
        bird.ResetBird();
        bird.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    /// <summary>
    /// When thee game is ready to start, this method is called to set up the game state.
    /// Hides the start screen and shows the ready screen.
    /// Resets the bird to its initial state.
    /// Turrns on the bird game object to make it visible.
    /// Uses the start butto to show the ready screen.
    /// </summary>
    public void ReadyGame()
    {
        uiManager.HideStart();
        uiManager.ShowReady();
        bird.ResetBird();
        bird.gameObject.SetActive(true);
        centeralAudio.PlayOneShot(startClip);
    }
    /// <summary>
    /// Starts the game by resetting the score to 0
    /// Hides the ready screen.
    /// Tunrs on the PipeSpawner component to start spawning pipes.
    /// Turns on the bird to make it visible.
    /// When the player clicks the screen the bird starts the game.
    /// </summary>
    public void StartGame()
    {
        score = 0;
        uiManager.HideReady();
        pipeSpawner.enabled = true;
        bird.StartGame();
    }
    /// <summary>
    /// Sets timer to 0 to stop the game.
    /// Shows the game over screen using the UIManager.
    /// </summary>
    public void GameOver()
    {
        Time.timeScale = 0f;
        uiManager.ShowGameOver();
    }
    /// <summary>
    /// Increases the score by 1 each time this method is called.
    /// Sends the score to be converted and displayed in the UIManager.
    /// Plays the Score sound when the score is increased.
    /// </summary>
    public void IncreaseScore()
    {
        score++;
        centeralAudio.PlayOneShot(scoreClip);
        uiManager.UpdateScore(score);
    }
}
