using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue : MonoBehaviour
{
    public List<Sentence> sentences = new List<Sentence>();
    public GameObject activateAfterDialogue;
}

[System.Serializable]
public class Sentence
{
    public string name;
    public Sprite avatar;

    [TextArea(3, 12)]
    public string text;
}
