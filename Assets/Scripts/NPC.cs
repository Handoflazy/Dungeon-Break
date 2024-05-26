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
    public DialogueTree dialogueTree;
    bool inConversation=false;

    public UnityEvent DialogStarted;
    public UnityEvent DialogEnded;

    [SerializeField]
    private bool GrantLoot;

    private void Start()
    {
        NguyenSingleton.Instance.playerID.playerEvents.OnDialogueStart += JoinConversation;
        NguyenSingleton.Instance.playerID.playerEvents.OnDialogueEnd += LeaveConversation;
    }
    private void OnDisable()
    {
        NguyenSingleton.Instance.playerID.playerEvents.OnDialogueStart -= JoinConversation;
        NguyenSingleton.Instance.playerID.playerEvents.OnDialogueEnd -= LeaveConversation;
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
            NguyenSingleton.Instance.DialogueController.StartDialogueTree(dialogueTree, repeatStartPosition, npcName,GetComponent<Animator>());
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
            GrantLoot = false;
        }
        DialogEnded?.Invoke();

    }






}