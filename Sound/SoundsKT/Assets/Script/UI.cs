using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject PanelPause;
    [SerializeField] private GameObject ButtonPause;
    [SerializeField] private Slider music;
    [SerializeField] private Slider SFX;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource death;
    [SerializeField] private AudioSource shooting;
    public void Pause()
    {
        Time.timeScale = 0;
        PanelPause.SetActive(true);
        ButtonPause.SetActive(false);
    }
    public void UnPause()
    {
        Time.timeScale = 1;
        PanelPause.SetActive(false);
        ButtonPause.SetActive(true);
        musicSource.volume = music.value;
        death.volume = SFX.value;
        shooting.volume = SFX.value;
    }
}
