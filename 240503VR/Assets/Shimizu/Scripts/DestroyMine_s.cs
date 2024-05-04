using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMine_s : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroy", 5);
    }

    void destroy()
    {
        Destroy(this.gameObject);
    }
}
