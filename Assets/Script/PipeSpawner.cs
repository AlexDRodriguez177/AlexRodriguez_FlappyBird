using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = .1f;
    public float randomVariable = 1f;
    public Transform spawnLocation;
    
    private float timer = float.MaxValue;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnRandomOpening();
            timer = 0f;
        }
    }

    public void StartSpawning()
    {
        enabled = true;
    }
    
    void SpawnRandomOpening()
    {
        float yOffset = Random.Range(-randomVariable, randomVariable);
        Vector3 spawnPosition = spawnLocation.position + Vector3.up * yOffset;
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}
