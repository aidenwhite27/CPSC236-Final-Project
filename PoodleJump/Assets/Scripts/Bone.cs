using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    public float scoreToGive;

    private Score ScoreManager;

    private AudioSource bark1;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager = FindObjectOfType<Score>();

        bark1 = GameObject.Find("Bark1Sound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            ScoreManager.AddScore(scoreToGive);
            bark1.Play();
            gameObject.SetActive(false);
        }
    }
}
