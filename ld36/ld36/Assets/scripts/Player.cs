using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    private int stage = 1;
    private Vector3 last_mouse_pos_;

    public Musket musket;

    private int clicks_required = 15;
    private int num_clicks = 0;

    public GameObject bullet_;

    private GameManager manager_;
    private string[] anim_names_;

    public Text _timeRemainingText;
    public Text _scoreText;

    void Start () {
        last_mouse_pos_ = Input.mousePosition;
        manager_ = GameManager.Instance;
        manager_.Player = gameObject;
        manager_.TimeRemaining = _timeRemainingText;
        manager_.ScoreText = _scoreText;

        manager_.startGame();

        anim_names_ = new string[11];
        anim_names_[0] = "";
        anim_names_[1] = "sway";
        anim_names_[2] = "fire";
        anim_names_[3] = "LowerMusket";
        anim_names_[4] = "raiselock";
        anim_names_[5] = "applygunpowder";
        anim_names_[6] = "lowerfrizzen";
        anim_names_[7] = "insertbullet";
        anim_names_[8] = "rotate_extracted_ramrod";
        anim_names_[9] = "rerotate_ramrod";
        anim_names_[10] = "retract_ramrod";
    }
	
    void checkFire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            musket.fire();
            //GetComponent<Animator>().SetInteger("stage", ++stage);
        }
    }

    void lowerGun()
    {
        GetComponent<Animator>().SetInteger("stage", ++stage);
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
            GetComponent<Animator>().SetInteger("stage", ++stage);
        }
    }

    void extractRamRod()
    {
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

        if ((anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && anim.GetCurrentAnimatorStateInfo(0).IsName(anim_names_[stage])) || stage == 1)
        {
            switch (stage)
            {
                case 1:
                    checkFire();
                    break;
                case 2:
                    lowerGun();
                    break;
                case 3:
                    raiseLock();
                    break;
                case 4:
                    applyGunpowder();
                    break;
                case 5:
                    closeFrizzen();
                    break;
                case 6:
                    insertBullet();
                    break;
                case 7:
                    extractRamRod();
                    break;
                case 8:
                    insertRamRod();
                    break;
                case 9:
                    retractRamRod();
                    break;
                case 10:
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
