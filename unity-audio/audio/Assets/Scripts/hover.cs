using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class hover : MonoBehaviour, IPointerEnterHandler
{
    public Button lvl1;
    public Button lvl2;
    public Button lvl3;
    public Button optionsButton;
    public Button exitButton;
    public AudioClip buttonRolloverSound;
    public AudioSource buttonSounds;

    void Start()
    {
        lvl1.onClick.AddListener(delegate { PlayButtonRolloverSound(); });
        lvl2.onClick.AddListener(delegate { PlayButtonRolloverSound(); });
        lvl3.onClick.AddListener(delegate { PlayButtonRolloverSound(); });

        optionsButton.onClick.AddListener(delegate { PlayButtonRolloverSound(); });
        exitButton.onClick.AddListener(delegate { PlayButtonRolloverSound(); });

        buttonRolloverSound = Resources.Load<AudioClip>("button-rollover");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayButtonRolloverSound();
    }

    public void PlayButtonRolloverSound()
    {
        //buttonSounds.clip = buttonRolloverSound;
        buttonSounds.Play();
    }
}