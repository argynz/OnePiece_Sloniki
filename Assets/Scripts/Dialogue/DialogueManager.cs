using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<Sentence> sentences;
    private bool isOpen = false;

    public Text nameText;
    public Text sentenceText;
    public Image avatar;

    public Animator anim;
    private int isOpenHash;

    private GameObject activateAfterDialogue;

    void Start()
    {
        isOpenHash = Animator.StringToHash("isOpen");
        sentences = new Queue<Sentence>();
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
        if (!isOpen)
        {
            isOpen = true;
        }

        activateAfterDialogue = dialogue.activateAfterDialogue;
        anim.SetBool(isOpenHash, isOpen);

        sentences.Clear();
        foreach (Sentence sentence in dialogue.sentences)
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

        Sentence sentence = sentences.Dequeue();
        nameText.text = sentence.name;
        sentenceText.text = sentence.text;
        avatar.sprite = sentence.avatar;
        
        FindObjectOfType<AudioManager>().dialogueAudio.Play();
    }

    private void EndDialogue()
    {
        if (isOpen)
        {
            isOpen = false;
        }

        if (activateAfterDialogue != null)
        {
            activateAfterDialogue.SetActive(true);
        }
        anim.SetBool(isOpenHash, isOpen);
        FindObjectOfType<AudioManager>().dialogueAudio.Stop();
    }
}
