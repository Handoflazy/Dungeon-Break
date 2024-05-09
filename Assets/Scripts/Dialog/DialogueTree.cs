using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Dialog/DialogueTree")]
public class DialogueTree : ScriptableObject
{
    public DialogueSection[] sections;
}
[Serializable]
public struct DialogueSection
{
    [TextArea]
    public string[] dialogue;
    public bool endAfterDialogue;
    public BranchPoint branchPoint;
}
[Serializable]
public struct BranchPoint
{
    [TextArea]
    public string question;
    public Answer[] answers;
}
[Serializable]
public struct Answer
{
    public string answerLabel;
    public int nextElement;
}