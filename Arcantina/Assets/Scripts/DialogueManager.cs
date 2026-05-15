using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    DialogueController [] dialogues;

    void awake() {
        dialogues = FindObjectsOfType<DialogueController>();

        for(int i = 1; i < dialogues.Count(); i++) {
            dialogues[i].enabled = false;
        }
    }

    
}
