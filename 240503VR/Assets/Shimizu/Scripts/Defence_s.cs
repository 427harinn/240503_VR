using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defence_s : MonoBehaviour
{
    [SerializeField] GameObject shield;
    bool IsShield;

    public void OnDefenced()
    {
        shield.SetActive(true);
        IsShield = true;
    }

    public void EndDefence()
    {
        shield.SetActive(false);
        IsShield = false;
    }

    public bool GetIsSield()
    {
        return IsShield;
    }
}
