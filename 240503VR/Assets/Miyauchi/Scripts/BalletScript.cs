using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("DestroyBallet", 2.0f);
    }

    private void DestroyBallet()
    {
        Destroy(gameObject);
    }
}
