using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Spiral")
        {
            GetComponent<Collider>().enabled = false;
            foreach(Transform child in transform)
            {
                child.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
