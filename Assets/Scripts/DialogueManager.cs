using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private bool isOpen = false;

    public Text nameText;
    public Text sentenceText;

    public Animator anim;
    private int isOpenHash;

    void Start()
    {
        isOpenHash = Animator.StringToHash("isOpen");
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (isOpen && Input.GetKeyDown(KeyCode.Return))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isOpen = true;
        anim.SetBool(isOpenHash, isOpen);
        nameText.text = dialogue.name;

        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        sentenceText.text = sentence;
        FindObjectOfType<AudioManager>().dialogueAudio.Play();
    }

    private void EndDialogue()
    {
        isOpen = false;
        anim.SetBool(isOpenHash, isOpen);
        FindObjectOfType<AudioManager>().dialogueAudio.Stop();
    }
}
