using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour {

    public float timeToShowStartButton;
    private float currentTimeToShowStartButton;

    public GameObject[] texts;
    public GameObject[] images;

    public GameObject startButton;
    public GameObject loadingText;

    public AudioSource buttonSound;

    private MissionsManager missionManager;

    private int randObject;

	// Use this for initialization
	void Start () {
        missionManager = FindObjectOfType<MissionsManager>();
        randObject = Random.Range(0, 5);

        texts[randObject].SetActive(true);
        images[randObject].SetActive(true);

    }

    // Update is called once per frame
    void Update () {

        currentTimeToShowStartButton += Time.deltaTime;

        if(currentTimeToShowStartButton >= timeToShowStartButton)
        {
            loadingText.SetActive(false);
            startButton.SetActive(true); 
        }
    }

    public void OnClick()
    {
        SceneManager.LoadScene("Level" + missionManager.levelToGo); //Carrega o determinado level
        buttonSound.Play();
    }
}
