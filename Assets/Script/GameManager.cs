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

    void Awake()
    {
        Instance = this;
        pipeSpawner.enabled = false;
    }

    void Start()
    {
        uiManager.ShowStart();
        bird.gameObject.SetActive(false);
    }

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

    public void ReadyGame()
    {
        uiManager.HideStart();
        uiManager.ShowReady();
        bird.ResetBird();
        bird.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        score = 0;
        uiManager.HideReady();
        pipeSpawner.enabled = true;
        bird.StartGame();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        uiManager.ShowGameOver();
    }

    public void IncreaseScore()
    {
        score++;
        uiManager.UpdateScore(score);
    }
}
