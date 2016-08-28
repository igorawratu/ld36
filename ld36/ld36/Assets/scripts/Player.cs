using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    private int stage = 1;
    private Vector3 last_mouse_pos_;

    public Musket musket;

    private GameManager manager_;
    private string[] anim_names_;
    public List<string> instructions_;
    public List<Sprite> instruction_pics_;
    public GameObject target_;
    
    public Text _timeRemainingText;
    public Text _scoreText;

    public GameObject _cockMusketSound;
    public GameObject _closeFrizzenSound;

    public Image _prompt;
    public Text _instruction;

    private float x_rot = 0f;
    private float y_rot = 0f;

    void Start () {
        last_mouse_pos_ = Input.mousePosition;
        manager_ = GameManager.Instance;
        manager_.Player = gameObject;
        manager_.TimeRemaining = _timeRemainingText;
        manager_.ScoreText = _scoreText;
        manager_.Target = target_;

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
            GetComponent<Animator>().SetInteger("stage", ++stage);
            _prompt.sprite = instruction_pics_[stage];
            _instruction.text = instructions_[stage];

            if(_prompt.sprite == null)
            {
                _prompt.color = new Color(0, 0, 0, 0);
            }
            else
            {
                _prompt.color = new Color(1, 1, 1, 1);
            }
        }
    }

    void lowerGun()
    {
        GetComponent<Animator>().SetInteger("stage", ++stage);
        _prompt.sprite = instruction_pics_[stage];
        _instruction.text = instructions_[stage];

        if (_prompt.sprite == null)
        {
            _prompt.color = new Color(0, 0, 0, 0);
        }
        else
        {
            _prompt.color = new Color(1, 1, 1, 1);
        }
    }

    void raiseLock()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(_cockMusketSound);
            GetComponent<Animator>().SetInteger("stage", ++stage);
            _prompt.sprite = instruction_pics_[stage];
            _instruction.text = instructions_[stage];

            if (_prompt.sprite == null)
            {
                _prompt.color = new Color(0, 0, 0, 0);
            }
            else
            {
                _prompt.color = new Color(1, 1, 1, 1);
            }
        }
    }

    void applyGunpowder()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GetComponent<Animator>().SetInteger("stage", ++stage);
            _prompt.sprite = instruction_pics_[stage];
            _instruction.text = instructions_[stage];

            if (_prompt.sprite == null)
            {
                _prompt.color = new Color(0, 0, 0, 0);
            }
            else
            {
                _prompt.color = new Color(1, 1, 1, 1);
            }
        }
    }

    void closeFrizzen()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(_closeFrizzenSound);
            GetComponent<Animator>().SetInteger("stage", ++stage);
            _prompt.sprite = instruction_pics_[stage];
            _instruction.text = instructions_[stage];

            if (_prompt.sprite == null)
            {
                _prompt.color = new Color(0, 0, 0, 0);
            }
            else
            {
                _prompt.color = new Color(1, 1, 1, 1);
            }
        }
    }

    void insertBullet()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GetComponent<Animator>().SetInteger("stage", ++stage);
            _prompt.sprite = instruction_pics_[stage];
            _instruction.text = instructions_[stage];

            if (_prompt.sprite == null)
            {
                _prompt.color = new Color(0, 0, 0, 0);
            }
            else
            {
                _prompt.color = new Color(1, 1, 1, 1);
            }
        }
    }

    void extractRamRod()
    {
        if (Input.mouseScrollDelta.y > 1f)
        {
            GetComponent<Animator>().SetInteger("stage", ++stage);
            _prompt.sprite = instruction_pics_[stage];
            _instruction.text = instructions_[stage];

            if (_prompt.sprite == null)
            {
                _prompt.color = new Color(0, 0, 0, 0);
            }
            else
            {
                _prompt.color = new Color(1, 1, 1, 1);
            }
        }
    }

    void insertRamRod()
    {
        if (Input.mouseScrollDelta.y < -1f)
        {
            GetComponent<Animator>().SetInteger("stage", ++stage);
            _prompt.sprite = instruction_pics_[stage];
            _instruction.text = instructions_[stage];

            if (_prompt.sprite == null)
            {
                _prompt.color = new Color(0, 0, 0, 0);
            }
            else
            {
                _prompt.color = new Color(1, 1, 1, 1);
            }
        }
    }

    void retractRamRod()
    {
        if (Input.mouseScrollDelta.y < -1f)
        {
            GetComponent<Animator>().SetInteger("stage", ++stage);
            _prompt.sprite = instruction_pics_[stage];
            _instruction.text = instructions_[stage];
            if (_prompt.sprite == null)
            {
                _prompt.color = new Color(0, 0, 0, 0);
            }
            else
            {
                _prompt.color = new Color(1, 1, 1, 1);
            }

        }
    }

    void fullCock()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            stage = 1;
            Instantiate(_cockMusketSound);
            GetComponent<Animator>().SetInteger("stage", stage);
            _prompt.sprite = instruction_pics_[stage];
            _instruction.text = instructions_[stage];

            if (_prompt.sprite == null)
            {
                _prompt.color = new Color(0, 0, 0, 0);
            }
            else
            {
                _prompt.color = new Color(1, 1, 1, 1);
            }
        }
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T))
        {
            _prompt.enabled = !_prompt.enabled;
            _instruction.enabled = !_instruction.enabled;
        }

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
        

        float d_y_rot = dif.x * Mathf.PI * Time.deltaTime * 5;
        float d_x_rot = -dif.y * Mathf.PI * Time.deltaTime * 5;

        d_x_rot = Mathf.Clamp(d_x_rot + x_rot, -90f, 20f) - x_rot;
        d_y_rot = Mathf.Clamp(d_y_rot + y_rot, -90f, 90f) - y_rot;

        x_rot += d_x_rot;
        y_rot += d_y_rot;

        gameObject.transform.Rotate(Vector3.up, d_y_rot, Space.World);
        gameObject.transform.Rotate(Vector3.right, d_x_rot);

        last_mouse_pos_ = Input.mousePosition;
    }
}
