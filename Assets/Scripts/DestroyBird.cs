using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyBird : MonoBehaviour {

    // Use this for initialization
    public Text scoreText;          //Store a reference to the UI Text component which will display the number of pickups collected.
    public Text highScoreText;
    public static int count;
    private int bonus;
    private int lastscore;
    private int highScore;
    private GameObject player;
    public GameObject explosion;
    private Vector3 starting;
    private float max;
    string highScoreKey = "HighScore";

    public float distance;
    void Start()
    {
        //Initialize count to zero.
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        SetHighScore();
        count = 0;
        bonus = 0;
        SetScoreText();
        starting = transform.position;
        max = 0f;
    }
    void OnDisable()
    {
        //If our scoree is greter than highscore, set new higscore and save.
        if (count > highScore)
        {
            PlayerPrefs.SetInt(highScoreKey, count);
            PlayerPrefs.Save();
        }
    }
    void Update()
    {
        distance = Vector3.Distance(starting, transform.position);
       // Debug.Log(distance);
        if (distance > max)
            max = distance;
        if(max>4)
        Points((int)max);
        SetScoreText();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag =="Paukstis")
        {
            Instantiate(explosion, other.gameObject.transform.position, transform.rotation = Quaternion.identity);
            Destroy(other.gameObject);
            SpeedUp();
            Bonus(100);
            SetScoreText();
        }
        if (other.gameObject.tag == "NesantisPaukstis")
        {
            Bonus(1000);
            SetScoreText();
        }
    }
    void SetScoreText()
    {
        scoreText.text = "Taškai: " + count.ToString();
    }
    void SetHighScore()
    {

        highScoreText.text = "HighScore: " + highScore.ToString();
    }
    void SpeedUp()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * 100 + transform.right * 500);
    }
    void Points(int kiekis)
    {
        count = kiekis+bonus;
    }
    void Bonus(int kiekis)
    {
        bonus = bonus + kiekis;
    }
}
