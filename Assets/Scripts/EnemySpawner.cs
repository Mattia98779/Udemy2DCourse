using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfigSO> waveConfigSos;
    [SerializeField] private float timeBetweenWaves = 0f;
    private WaveConfigSO currentWave;
    [SerializeField] private bool isLooping;
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    private IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigSos)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                        currentWave.GetStartingWaypoint().position,
                        Quaternion.Euler(0,0,180), transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
        
        
    }
}
