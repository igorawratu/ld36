using UnityEngine;
using System.Collections;

public class GameManager : Singleton<GameManager> {
    private int score_ = 0;

    private float spawnRate = 5f;
    private float spawnTime = 0f;

    private float dist_max_ = 100f;
    private float dist_min_ = 50f;
    private float vel_min_ = 2f;
    private float vel_max_ = 10f;

    private GameObject target_;
    private GameObject player_;

    public int Score
    {
        get { return score_; }
        set { score_ = value; }
    }

    public GameObject Player
    {
        get { return player_; }
        set { player_ = value; }
    }

	// Use this for initialization
	void Start () {
        target_ = (GameObject)Resources.Load("Target");
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
        spawnTime += Time.deltaTime;
        if(spawnTime > spawnRate)
        {
            spawnTime = 0f;

            spawnTarget();
        }
	}
}
