using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class NPC : MonoBehaviour
{
    [SerializeField] bool firstInteraction = true;
    [SerializeField] int repeatStartPosition;

    public string npcName;
    public DialogueAsset dialogueAsset;
    public DialogueTree dialogueTree;
    bool inConversation=false;

    public UnityEvent DialogStarted;
    public UnityEvent DialogEnded;

    [SerializeField]
    private bool GrantLoot;


    private void OnEnable()
    {
        NguyenSingleton.Instance.DialogueController.OnDialogueStarted += JoinConversation;
        NguyenSingleton.Instance.DialogueController.OnDialogueEnded += LeaveConversation;

    }

    private void OnDisable()
    {
        NguyenSingleton.Instance.DialogueController.OnDialogueStarted -= JoinConversation;
        NguyenSingleton.Instance.DialogueController.OnDialogueEnded -= LeaveConversation;
    }

    [HideInInspector]
    public int StartPosition
    {
        get
        {
            if (firstInteraction)
            {
                firstInteraction = false;
                return 0;
            }
            else
            {
                return repeatStartPosition;
            }
        }
    }

    public bool InConversation { get => inConversation; set => inConversation = value; }

    public void ReponseInteract()
    {

        if(InConversation)
        {
            NguyenSingleton.Instance.DialogueController.SkipLine();
        }
        else
        {
            NguyenSingleton.Instance.DialogueController.StartDialogueTree(dialogueTree, repeatStartPosition, npcName);
        }

    }
    void JoinConversation()
    {
        inConversation = true;
        DialogStarted?.Invoke();
    }

    void LeaveConversation()
    {
        inConversation = false;
        if (GrantLoot)
        {
            DialogEnded?.Invoke();
            GrantLoot = false;
        }

    }






}