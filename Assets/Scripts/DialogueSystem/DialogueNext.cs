using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNext : MonoBehaviour
{
    public void NextDialogueButton()
    {
        DialogueManager.instance.DequeueDialogue();
    }
}
