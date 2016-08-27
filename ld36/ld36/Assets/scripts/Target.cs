using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {
    private Vector3 velocity_ = Vector3.forward;
    private GameObject player_;
    private float despawnLimit = 250f;

    public Vector3 Velocity
    {
        get { return velocity_; }
        set { velocity_ = value; }
    }

    public GameObject Player
    {
        get { return player_; }
        set { player_ = value; }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = gameObject.transform.position + velocity_ * Time.deltaTime;

        float dist = (gameObject.transform.position - player_.transform.position).magnitude;

        if(dist > despawnLimit)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.Score = GameManager.Instance.Score + 1;
        Destroy(gameObject);
    }
}
