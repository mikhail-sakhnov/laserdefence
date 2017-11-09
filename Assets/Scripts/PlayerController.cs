using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float xmin = -5;
     private float xmax = 5;
    

    public float speed = 15f;
    public float padding = 1;
    
    

    // Use this for initialization
    void Start()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, distance));
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, distance));

        xmin = leftMost.x + padding;
        xmax = rightMost.x - padding;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Have left arrow pressed");

            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Have right arrow pressed");
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}