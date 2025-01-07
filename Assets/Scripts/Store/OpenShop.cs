using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    public AudioManager audioManager;
    public PopupManager popupManager;
    
    public void OpenShopMenu()
    {
        audioManager.PlaySfx(audioManager.noMoreCards);
        popupManager.shopPopup.SetActive(true); //openes the shop
    }
}
