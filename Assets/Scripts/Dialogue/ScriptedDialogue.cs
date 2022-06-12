using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptedDialogue : MonoBehaviour
{
    public Dialogue dialogue;
    public bool isPlayed = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isPlayed)
        {
            isPlayed = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }

}
