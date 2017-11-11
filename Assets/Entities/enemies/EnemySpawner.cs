using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float height = 5f;
    public float width = 10f;

    public float speed = 5f;

    private float xmin, xmax;
    private int direction = 0;
    
    // Use this for initialization
    void Start()
    {
        spawnEnemies();
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distance));
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distance));
        xmin = leftMost.x;
        xmax = rightMost.x;

        direction = new System.Random().Next(0, 2);
        if (direction != 1)
        {
            direction = -1;
        }
    }

    private void spawnEnemies()
    {
        foreach (Transform child in transform)
        {
            spawnEnemy(child);
        
        }
    }

    private void spawnEnemy(Transform parent)
    {
        GameObject enemy = Instantiate(enemyPrefab, parent.transform.position, Quaternion.identity) as GameObject;
        enemy.transform.parent = parent;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 1));
    }

   
    
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime * direction;
        float leftEdge = transform.position.x - (0.5f * width);
        float rightEdge = transform.position.x + (0.5f * width);
        
        if ((rightEdge > xmax && direction == 1) || (leftEdge < xmin && direction == -1))
        {
            direction = direction * -1;
        }

        if (AllMembersDead())
        {
            SpawnUntilFull();

        }

    }

    Transform NextFreePosition()
    {
        foreach (Transform position in transform)
        {
            if (position.childCount == 0)
            {
                return position;
            }
        }
        return null;
    }

    void SpawnUntilFull()
    {
        Transform freePosition = NextFreePosition();
        if (freePosition)
        {
             spawnEnemy(freePosition);
            
        }
        if (NextFreePosition())
        {
            Invoke("SpawnUntilFull", 0.5f);
            
        }

    }

    Boolean AllMembersDead()
    {
        foreach (Transform childPositionGameObject in transform)
        {
            if (childPositionGameObject.childCount != 0)
            {
                return false;
            }
        }
        return true;
    }
}