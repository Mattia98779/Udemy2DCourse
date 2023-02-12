using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    [SerializeField] private WaveConfigSO waveConfigSo;
    private List<Transform> waypoints;
    private int waypointIndex = 0;

    private void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    private void Start()
    {
        waveConfigSo = enemySpawner.GetCurrentWave();
        waypoints = waveConfigSo.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    private void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfigSo.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
