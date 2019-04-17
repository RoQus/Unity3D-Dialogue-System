using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueBase dialogueRU;
    public DialogueBase dialogueEN;
    public GameObject NewGameVars;
    public int dialogueGame;


    private void Start()
    {
        dialogueGame = 1;
    }

    public void DialogueTriggers()
    {
        //DialogueManager.instance.EnqueueDialogue(dialogueRU);

        if (dialogueGame == 0)
        {
            DialogueManager.instance.EnqueueDialogue(dialogueEN);
        }
        else if (dialogueGame == 1)
        {
            DialogueManager.instance.EnqueueDialogue(dialogueRU);
        }
    }

    private void Update()
    {
        if (NewGameVars.GetComponent<Player>().gameStage == 0)
        {
            DialogueTriggers();
        }
    }
}