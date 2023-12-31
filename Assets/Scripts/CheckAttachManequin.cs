using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAttachManequin : MonoBehaviour
{

    public AudioClip errorSound;
    public AudioClip correctSound;
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
            Debug.Log("Piece" + other.tag);
            Debug.Log("Obj" + gameObject.tag);
            PlayCorrectSound();
        }
        else
        {
            Debug.Log("NOPE!");
            Debug.Log("Piece" + other.tag);
            Debug.Log("Obj" + gameObject.tag);
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

    private void PlayCorrectSound()
    {
        if (correctSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(correctSound);
        }
    }
}
