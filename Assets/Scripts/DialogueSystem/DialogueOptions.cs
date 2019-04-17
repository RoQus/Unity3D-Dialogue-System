using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Dialogue Option", menuName = "Dialogues Options")]
public class DialogueOptions : DialogueBase
{
    [System.Serializable]
    public class Options
    {
        public string buttonNameRU;
        public string buttonNameEN;
        public string buttonNamePL;
        public DialogueBase nextDialogue;
        public UnityEvent myEvent;
    }

    public Options[] optionsInfo;
}
