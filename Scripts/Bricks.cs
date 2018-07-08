using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    public float volume = 1f;
    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public GameObject smoke;

    private int timesHit;
    private SceneLoader sceneLoader;
    private bool isBreakable;

    // Use this for initialization
    void Start()
    {
        isBreakable = (this.tag == "Breakable");
        // Keep track of breakable bricks
        if (isBreakable)
        {
            breakableCount++;
        }

        timesHit = 0;
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position, volume);
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            sceneLoader.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else 
        { 
            Debug.LogWarning ("Brick damage sprite missing!");
        }
    }
}
