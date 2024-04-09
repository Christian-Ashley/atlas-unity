using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button lvl1;
    public Button lvl2;
    public Button lvl3;
    public Button optionsButton;
    public Button exitButton;
    private int SceneHistory;
    public AudioClip buttonRolloverSound;

    // Start is called before the first frame update
    void Start()
    {
        SceneHistory = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Previous", SceneHistory);
        lvl1.onClick.AddListener(delegate { LevelSelect(1); PlayButtonRolloverSound(); });
        lvl2.onClick.AddListener(delegate { LevelSelect(2); PlayButtonRolloverSound(); });
        lvl3.onClick.AddListener(delegate { LevelSelect(3); PlayButtonRolloverSound(); });

        optionsButton.onClick.AddListener(delegate { Options(); PlayButtonRolloverSound(); });
        exitButton.onClick.AddListener(delegate { exitProgram(); PlayButtonRolloverSound(); });

        buttonRolloverSound = Resources.Load<AudioClip>("button-rollover");
    }

    public void LevelSelect(int lvl)
    {
        SceneManager.LoadScene("Level0" + lvl);
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void exitProgram()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

    private void PlayButtonRolloverSound()
    {
        AudioSource.PlayClipAtPoint(buttonRolloverSound, transform.position);
    }

    // Update is called once per frame
    void Update()
    {

    }
}