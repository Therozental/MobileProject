using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDropdown: MonoBehaviour
{
    [SerializeField] private Animator anim;
    private bool IsOpen;

    private void Start()
    {
        //anim = GetComponent<Animator>();
    }
    public void OnClick()
    {
        if (IsOpen == false)
        {
            anim.SetTrigger("Open");
            IsOpen = true;
        }

        else if (IsOpen == true)
        {
            anim.SetTrigger("Close");
            IsOpen = false;
        }

    }
}
