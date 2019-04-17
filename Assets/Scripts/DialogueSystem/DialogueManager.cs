using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Fix This" + gameObject.name);
        }
        else
        {
            instance = this;
        }
    }


    public GameObject dialogueCanvas, dialogueImageBox, dialogueBox;
    
    public Text dialogueName, dialogueText;
    public Image dialogueImage;
    public float delay = 0.001f;
    
    public Queue<DialogueBase.Info> dialogueInfo = new Queue<DialogueBase.Info>(); //FIFO Collection

    private bool isDialogueOption;
    public GameObject dialogueOptionUI;
    public bool inDialogue;
    public GameObject[] optionButtons;
    private int optionsAmount;

    private bool isCurrentlyTyping;
    private string completeText; 
    
    public void EnqueueDialogue(DialogueBase db)
    {
        if (inDialogue) return;
        inDialogue = true;
        
        dialogueCanvas.SetActive(true);
        dialogueInfo.Clear();
        
        OptionsParser(db);
        
        foreach (DialogueBase.Info info in db.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }

        DequeueDialogue();
    }

    public void DequeueDialogue()
    {
        if (isCurrentlyTyping == true)
        {
            CompleteText();
            StopAllCoroutines();
            isCurrentlyTyping = false;
            return;
        }
        
        if (dialogueInfo.Count == 0)
        {
            EndofDialogue();
            return;
        }
        
        DialogueBase.Info info = dialogueInfo.Dequeue();
        completeText = info.textBase;

        dialogueName.text = info.characterBase.characterName;
        dialogueText.text = info.textBase;
        dialogueImage.sprite = info.imageBase;

        dialogueText.text = "";
        StartCoroutine(TypeText(info));
    }

    IEnumerator TypeText(DialogueBase.Info info)
    {
        isCurrentlyTyping = true;
        foreach (char c in info.textBase.ToCharArray())
        {
            yield return new WaitForSeconds(delay);
            dialogueText.text += c;
            yield return null;
        }

        isCurrentlyTyping = false;
    }

    private void CompleteText()
    {
        dialogueText.text = completeText;
    }
    
    public void EndofDialogue()
    {
        dialogueCanvas.SetActive(false);
        OptionsLogic();
    }

    private void OptionsLogic()
    {
        if (isDialogueOption == true)
        {
            dialogueCanvas.SetActive(true);
            dialogueImageBox.SetActive(true);
            dialogueBox.SetActive(false);
            dialogueOptionUI.SetActive(true);
        }
        else
        {
            inDialogue = false;
        }
    }

    public void CloseOptions()
    {
        dialogueOptionUI.SetActive(false);
    }

    private void OptionsParser(DialogueBase db)
    {
        if (db is DialogueOptions)
        {
            isDialogueOption = true;
            DialogueOptions dialogueOptions = db as DialogueOptions;
            optionsAmount = dialogueOptions.optionsInfo.Length;

            for (int i = 0; i < optionButtons.Length; i++)
            {
                optionButtons[i].SetActive(false);
            }
            
            for (int i = 0; i < optionsAmount; i++)
            {
                optionButtons[i].SetActive(true);
                optionButtons[i].transform.GetChild(0).gameObject.GetComponent<Text>().text =
                    dialogueOptions.optionsInfo[i].buttonNameRU;
                UnityEventHandler myEventHandler = optionButtons[i].GetComponent<UnityEventHandler>();
                myEventHandler.eventHandler = dialogueOptions.optionsInfo[i].myEvent;
                
                if (dialogueOptions.optionsInfo[i].nextDialogue != null)
                {
                    myEventHandler.myDialogue = dialogueOptions.optionsInfo[i].nextDialogue;
                }
                else
                {
                    myEventHandler.myDialogue = null;
                }
            }
        }
        else
        {
            isDialogueOption = false;
        }
    }
}
