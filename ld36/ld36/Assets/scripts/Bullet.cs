using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if((player.transform.position - gameObject.transform.position).magnitude > 500f)
        {
            Destroy(gameObject);
        }
	}
}
