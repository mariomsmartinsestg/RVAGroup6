using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAttachManequin : MonoBehaviour
{

    public AudioClip errorSound;
    private AudioSource audioSource;

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
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        // Check if the entering object has a specific tag
        if (other.CompareTag(gameObject.tag))
        {
            Debug.Log("Object can attach!");
            Debug.Log(other.tag);
            Debug.Log(gameObject.tag);
        }
        else
        {
            Debug.Log("NOPE!");
            Debug.Log(other.tag);
            Debug.Log(gameObject.tag);
            PlayErrorSound();
        }
    }

    private void PlayErrorSound()
    {
        if (errorSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(errorSound);
        }
    }
}
