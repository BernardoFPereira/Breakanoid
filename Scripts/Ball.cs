using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour 
{
    private Paddle paddle;
    private bool hasStarted = false;
    private Vector3 paddleToBallVector;
	
    // Use this for initialization
	void Start () 
    {
        paddle = FindObjectOfType<Paddle>();
        paddleToBallVector = transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!hasStarted)
        {
            transform.position = paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButtonDown(0))
            {
                print("Ball lauched!");
                hasStarted = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 10f);
            }
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(0f, 0.2f));
        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
}