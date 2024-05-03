using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defence_s : MonoBehaviour
{
    [SerializeField] GameObject shield;


    public void OnDefenced()
    {
        shield.SetActive(true);
    }

    public void EndDefence()
    {
        shield.SetActive(false);
    }

}
