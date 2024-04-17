using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class click : MonoBehaviour, IPointerClickHandler
{
    public Button lvl1;
    public Button lvl2;
    public Button lvl3;
    public Button optionsButton;
    public Button exitButton;
    public AudioClip buttonClickSound;
    public AudioSource buttonSounds;

    void Start()
    {
        lvl1.onClick.AddListener(delegate { PlayButtonClickSound(); });
        lvl2.onClick.AddListener(delegate { PlayButtonClickSound(); });
        lvl3.onClick.AddListener(delegate { PlayButtonClickSound(); });

        optionsButton.onClick.AddListener(delegate { PlayButtonClickSound(); });
        exitButton.onClick.AddListener(delegate { PlayButtonClickSound(); });

        buttonClickSound = Resources.Load<AudioClip>("button-click");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlayButtonClickSound();
    }

    public void PlayButtonClickSound()
    {
        buttonSounds.Play();
    }
}