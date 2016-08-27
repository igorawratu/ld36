using UnityEngine;
using System.Collections;

public class Musket : MonoBehaviour {
    public GameObject bullet_prefab_;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
       
	}

    public void fire()
    {
        Vector3 direction = gameObject.transform.rotation * Vector3.left;

        GameObject bullet = Instantiate(bullet_prefab_);
        bullet.transform.position = gameObject.transform.position;
        bullet.GetComponent<Rigidbody>().velocity = direction * 1000;
        bullet.GetComponent<Bullet>().player = gameObject;
    }
}
