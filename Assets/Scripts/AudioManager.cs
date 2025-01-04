using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;


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
    public AudioClip computerPlayCard;
    public AudioClip warWin;
    public AudioClip warLose;
    public AudioClip winPoints;
    public AudioClip warFlip;
    public AudioClip noMoreCards;
    public AudioClip levelUp;
    public AudioClip makeAPurchase;
    public AudioClip tie;
    


    [Header("------- Sliders -------")]
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
    public void PlaySfx(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    
    public void ChangeMusicVolume()
    {
        musicSource.volume = musicSlider.value;
    }

    public void ChangeSoundVolume()
    {
        sfxSource.volume = sfxSlider.value;
    }

    //AudioManager audioManager;

    //private void Awake()
    //{
    //    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    //}

    //audioManager.PlaySfx(audioManager.addsoundhere);
}
