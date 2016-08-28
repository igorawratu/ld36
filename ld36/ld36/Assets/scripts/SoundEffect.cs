using UnityEngine;
using System.Collections;

public class SoundEffect : MonoBehaviour {
    public float aliveTime = 1f;
    public float startTime = 0f;

    private float time = 0f;
	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().time = startTime;
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time > aliveTime)
        {
            Destroy(gameObject);
        }
	}
}
