using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCollider : MonoBehaviour 
{
    private SceneLoader sceneLoader;

    void OnTriggerEnter2D(Collider2D trigger)
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        sceneLoader.LoadScene("Lose Screen");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }
}