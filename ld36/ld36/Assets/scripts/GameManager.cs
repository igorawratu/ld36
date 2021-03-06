﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {
    private int score_ = 0;
    private int high_score_ = 0;

    private float spawnRate = 12.5f;
    private float spawnTime = 10f;

    private float dist_max_ = 75f;
    private float dist_min_ = 50f;
    private float vel_min_ = 5f;
    private float vel_max_ = 10f;

    private GameObject target_;
    private GameObject player_;
    private Text time_remaining_;
    private Text score_text_;

    private int time_elapsed_ = 0;
    private int max_time_ = 180;

    public bool played = false;
    private bool playing_ = false;

    private bool nhs_ = false;

    public int Score
    {
        get { return score_; }
        set {
            score_ = value;

            score_text_.text = "SCORE: " + score_;

            if (score_ == 5)
            {
                score_text_.color = new Color(0.1f, 0.7f, 0.1f);
            }

            if(score_ > high_score_)
            {
                high_score_ = score_;
                nhs_ = true;
            }
        }
    }

    public GameObject Target
    {
        get { return target_; }
        set { target_ = value; }
    }

    public bool NewHighScore
    {
        get { return nhs_; }
    }

    public int HighScore
    {
        get { return high_score_; }
    }

    public Text TimeRemaining
    {
        get { return time_remaining_; }
        set { time_remaining_ = value; }
    }

    public Text ScoreText
    {
        get { return score_text_; }
        set { score_text_ = value; }
    }

    public GameObject Player
    {
        get { return player_; }
        set { player_ = value; }
    }

	// Use this for initialization
	void Start () {
        

    }
	
    public void startGame()
    {
        nhs_ = false;
        played = true;
        playing_ = true;

        time_elapsed_ = 0;
        score_ = 0;

        int remaining = max_time_ - time_elapsed_++;
        time_remaining_.text = "TIME REMANING: " + remaining;

        time_remaining_.color = new Color(0.1f, 0.7f, 0.1f);
        score_text_.color = new Color(0.7f, 0.1f, 0.1f);

        StartCoroutine("displayTimeRemaining");
    }

    private void spawnTarget()
    {
        float d = Random.value * (dist_max_ - dist_min_) + dist_min_;

        float sn = Random.value > 0.5f ? -1f : 1f;

        Vector3 spawnPos = Vector3.Normalize(new Vector3(sn * (Random.value + 0.5f), Random.value + 0.5f, 0.2f)) * d;
        Vector3 dif = spawnPos - gameObject.transform.position;
        Vector3 dir = Vector3.Normalize(new Vector3(dif.z, 0.1f, -dif.x));

        if(dir.z < 0)
        {
            dir = -dir;
        }

        GameObject target = Instantiate(target_);
        target.transform.position = spawnPos;

        Quaternion target_rot = Quaternion.FromToRotation(Vector3.forward, dir);
        target.transform.rotation = target_rot;

        target.GetComponent<Target>().Velocity = dir * (Random.value * (vel_max_ - vel_min_) + vel_min_);
        target.GetComponent<Target>().Player = player_;

        
    }

	// Update is called once per frame
	void Update () {
        if (playing_)
        {
            spawnTime += Time.deltaTime;

            if (spawnTime > spawnRate)
            {
                spawnTime = 0f;

                spawnTarget();
            }
        }
	}

    IEnumerator displayTimeRemaining()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            int remaining = max_time_ - time_elapsed_++;
            time_remaining_.text = "TIME REMAINING: " + remaining;
            if(remaining == 10)
            {
                time_remaining_.color = new Color(0.7f, 0.1f, 0.1f);
            }

            if(remaining <= 0)
            {
                playing_ = false;
                Application.LoadLevel("StartScreen");
                break;
            }
        }

    }
}
