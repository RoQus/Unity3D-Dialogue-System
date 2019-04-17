using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogues")]
public class DialogueBase : ScriptableObject
{
    [System.Serializable]
    public class Info
    {
        public DialogueCharacterProfile characterBase;
        //public string db_nameRU;
        public Sprite imageBase;
        [TextArea (4,10)]
        public string textBase;
    }

    [Header("Insert Dialogue Information")]
    public Info[] dialogueInfo;
    
    IEnumerator WaitTextCoroutine(int waitText)
    {
        yield return new WaitForSeconds(waitText);
    }
}
