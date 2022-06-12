using UnityEngine;

public class Dialogable : Interactable
{
    public Dialogue dialogue;
    public override void Interact()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
