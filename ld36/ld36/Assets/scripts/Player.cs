using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    private int stage = 1;
    private Vector3 last_mouse_pos_;

    public Musket musket;

    private float ramrod_pos_ = 0f;

    private int clicks_required = 15;
    private int num_clicks = 0;

    public GameObject bullet_;

    private GameManager manager_;

    void Start () {
        last_mouse_pos_ = Input.mousePosition;
        manager_ = GameManager.Instance;
        manager_.Player = gameObject;
    }
	
    void checkFire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            musket.fire();
            GetComponent<Animator>().SetInteger("stage", ++stage);
        }
    }

    void raiseLock()
    {
        if(Input.mouseScrollDelta.y < -1f)
        {
            GetComponent<Animator>().SetInteger("stage", ++stage);
        }
    }

    void applyGunpowder()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GetComponent<Animator>().SetInteger("stage", ++stage);
        }
    }

    void closeFrizzen()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<Animator>().SetInteger("stage", ++stage);
        }
    }

    void insertBullet()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            //bullet_.SetActive(true);
            GetComponent<Animator>().SetInteger("stage", ++stage);
        }
    }

    void extractRamRod()
    {
        //bullet_.SetActive(false);
        if (Input.mouseScrollDelta.y > 1f)
        {
            GetComponent<Animator>().SetInteger("stage", ++stage);
        }
    }

    void insertRamRod()
    {
        if (Input.GetMouseButtonDown(0))
        {
            num_clicks++;
        }

        if(num_clicks > clicks_required)
        {
            num_clicks = 0;
            GetComponent<Animator>().SetInteger("stage", ++stage);
        }
    }

    void retractRamRod()
    {
        if (Input.mouseScrollDelta.y < -1f)
        {
            GetComponent<Animator>().SetInteger("stage", ++stage);
        }
    }

    void fullCock()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            stage = 1;
            GetComponent<Animator>().SetInteger("stage", stage);
        }
    }

	// Update is called once per frame
	void Update () {
        Vector3 dif = Input.mousePosition - last_mouse_pos_;

        Animator anim = GetComponent<Animator>();

        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 || anim.GetCurrentAnimatorStateInfo(0).loop)
        {
            switch (stage)
            {
                case 1:
                    checkFire();
                    break;
                case 2:
                    raiseLock();
                    break;
                case 3:
                    applyGunpowder();
                    break;
                case 4:
                    closeFrizzen();
                    break;
                case 5:
                    insertBullet();
                    break;
                case 6:
                    extractRamRod();
                    break;
                case 7:
                    insertRamRod();
                    break;
                case 8:
                    retractRamRod();
                    break;
                case 9:
                    fullCock();
                    break;
                default:
                    break;
            }
        }
        

        float y_rot = dif.x * Mathf.PI * Time.deltaTime * 5;
        float x_rot = -dif.y * Mathf.PI * Time.deltaTime * 5;

        gameObject.transform.Rotate(Vector3.up, y_rot, Space.World);
        gameObject.transform.Rotate(Vector3.right, x_rot);

        last_mouse_pos_ = Input.mousePosition;
    }
}
