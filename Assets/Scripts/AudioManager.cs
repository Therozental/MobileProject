using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------- Audio Source -------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;


    [Header("------- Audio Clip -------")]
    public AudioClip background;
    public AudioClip openShop;
    public AudioClip expandPlusSign;
    public AudioClip playCard;
    public AudioClip warWin;
    public AudioClip warLose;
    public AudioClip winPoints;
    public AudioClip noMoreCards;
    public AudioClip levelUp;
    public AudioClip makeAPurchase;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void PlaySfx(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    //AudioManager audioManager;

    //private void Awake()
    //{
    //    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    //}

    //audioManager.PlaySfx(audioManager.addsoundhere);
}
