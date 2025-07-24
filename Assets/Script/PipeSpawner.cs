using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = .1f;
    public float randomVariable = 1f;
    public Transform spawnLocation;
    // sets timer to a high value to ensure the first spawn does not happen immediately until the first Update call
    private float timer = float.MaxValue;
    /// <summary>
    /// Sets timer to 0 and starts the timer at a cosistent rate.
    /// Starts spawning pipes at a random height within the specified range.
    /// Sets timer to 0 so that the spawning is spaced out.
    /// </summary>
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnRandomOpening();
            timer = 0f;
        }
    }
    /// <summary>
    /// Turns on the PipeSpawner component to start spawning pipes.
    /// Turns on the script.
    /// </summary>
    public void StartSpawning()
    {
        enabled = true;
    }
    /// <summary>
    /// Sets the a radonom heigth (y) offset for the pipe spawn location
    /// Sets the spawn position to the spawn location with the random height offset.
    /// spawns a pipe with the new hight opening at the spawn position.
    /// </summary>
    void SpawnRandomOpening()
    {
        float yOffset = Random.Range(-randomVariable, randomVariable);
        Vector3 spawnPosition = spawnLocation.position + Vector3.up * yOffset;
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}
