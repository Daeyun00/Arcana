using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    // Expose this to the Inspector so you can drag & drop them in the EXACT order!
    [SerializeField] private DialogueController[] dialogues;

    void Start() 
    {
        // Safety check to prevent errors if the array is empty
        if (dialogues == null || dialogues.Length == 0) return;

        // Turn off everything EXCEPT the first one (index 0)
        for(int i = 1; i < dialogues.Length; i++) 
        {
            dialogues[i].enabled = false;
            if (dialogues[i].dialoguePanel != null) 
            {
                dialogues[i].dialoguePanel.SetActive(false);
            }
        }
    }

    void Update()
    {
        for(int i = 0; i < dialogues.Length; i++) 
        {
            if (dialogues[i].finish)
            {
                dialogues[i].finish = false;
                dialogues[i].enabled = false;

                // Check if there is actually a "next" dialogue before trying to turn it on!
                // This prevents the IndexOutOfRangeException crash.
                if (i + 1 < dialogues.Length) 
                {
                    dialogues[i+1].enabled = true;
                    
                    // You probably want to activate the next panel as well
                    if (dialogues[i+1].dialoguePanel != null) 
                    {
                        dialogues[i+1].dialoguePanel.SetActive(true);
                    }
                }
            }
        }
    }
}