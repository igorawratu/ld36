using UnityEngine;
using System.Collections;

public class Musket : MonoBehaviour {
    public GameObject bullet_prefab_;
    public GameObject tip;
    public GameObject explosion;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
       
	}

    public void fire()
    {
        Vector3 direction = gameObject.transform.rotation * Vector3.down;

        GameObject bullet = Instantiate(bullet_prefab_);
        bullet.transform.position = tip.transform.position;
        bullet.GetComponent<Rigidbody>().velocity = direction * 100;
        bullet.GetComponent<Bullet>().player = gameObject;

        GameObject exp = Instantiate(explosion);
        exp.transform.parent = gameObject.transform;
        exp.transform.position = tip.transform.position;
        exp.transform.rotation = tip.transform.rotation;
    }
}
