using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainKeyCollision : MonoBehaviour
{
    [HideInInspector]
    public AudioSource tickSource;
    // Start is called before the first frame update
    void Start()
    {
        tickSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Plane")
        {
            tickSource.Play();
        }
    }
}
