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
    public AudioSource buttonRolloverSound;

    // Start is called before the first frame update
    void Start()
    {
        SceneHistory = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Previous", SceneHistory);
        lvl1.onClick.AddListener(delegate { LevelSelect(1); });
        lvl2.onClick.AddListener(delegate { LevelSelect(2); });
        lvl3.onClick.AddListener(delegate { LevelSelect(3); });

        optionsButton.onClick.AddListener(delegate { Options(); });
        exitButton.onClick.AddListener(delegate { exitProgram(); });
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
        buttonRolloverSound.Play();
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
    }
}