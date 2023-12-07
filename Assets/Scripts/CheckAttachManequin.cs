using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAttachManequin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   // This method is called when another Collider enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has a specific tag or component
        if (other.CompareTag(gameObject.tag))
        {
            // The entering object can attach to this object
            // Do something here, like initiating the attachment process
            Debug.Log("Object can attach!");
        } else {
            Debug.Log("NOPE");
        }
    }

}
