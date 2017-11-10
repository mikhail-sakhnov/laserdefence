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
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
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
        
    }
}