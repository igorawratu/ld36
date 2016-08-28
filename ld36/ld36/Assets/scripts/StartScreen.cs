using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour {
    public Text _scores;

	// Use this for initialization
	void Start () {
        string nhs = GameManager.Instance.NewHighScore ? " NEW HIGH SCORE" : "HIGH SCORE";
        _scores.text = nhs + "\n" + GameManager.Instance.HighScore + "\nLAST SCORE\n" + GameManager.Instance.Score;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown)
        {
            Application.LoadLevel("Main");
        }
	}
}
