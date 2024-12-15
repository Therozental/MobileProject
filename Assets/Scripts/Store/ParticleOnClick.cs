using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleOnClick : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        particles.Stop();
    }

    private void OnEnable()
    {
        particles.Stop();
    }

    public void OnClick()
    {
        particles.Stop();
        particles.Play();
    }
}
