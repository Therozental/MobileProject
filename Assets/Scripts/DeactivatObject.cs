using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivatObject : MonoBehaviour
{
    public void DeactivateObject()
    {
        gameObject.SetActive(false);
    }
}
