using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    DialogueController [] dialogues;

    void Awake() {
        dialogues = FindObjectsOfType<DialogueController>();

        for(int i = 1; i < dialogues.Count(); i++) 
        {
            dialogues[i].enabled = false;
            dialogues[i].dialoguePanel.SetActive(false);
        }
    }

    void Update()
    {
        for(int i = 0; i < dialogues.Count(); i++) 
        {
            if (dialogues[i].finish)
            {
                dialogues[i].finish=false;
                dialogues[i].enabled=false;
                dialogues[i+1].enabled=true;
            }
        }
    }

    
}
