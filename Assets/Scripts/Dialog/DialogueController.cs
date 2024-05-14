using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine;
using System.Collections;
using UnityEditor.Rendering;
using static System.Collections.Specialized.BitVector32;

public class DialogueController : MonoBehaviour
{

    [SerializeField] private float charactersPerSecond = 5;

    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] CanvasGroup dialogueBox;
    [SerializeField] GameObject answerBox;
    [SerializeField] Button[] answerObjects;

    [Header("Image Dialogue")]
    [SerializeField] Animator characterAnim;
    [SerializeField] SpriteRenderer characterSprite;
    [SerializeField] Image image;

    bool skipLineTriggered;
    private IEnumerator currentCoroutine;
    bool answerTriggered;
    int answerIndex;





    void ResetBox()
    {
        StopAllCoroutines();
        dialogueBox.gameObject.SetActive(false);
        answerBox.SetActive(false);
        skipLineTriggered = false;
        answerTriggered = false;
    }
    public void StartDialogue(string[] dialogue, int startPosition, string name,Animator anim) =>
       StartConversation(RunDialogue(dialogue, startPosition), name,anim);

    public void StartDialogueTree(DialogueTree dialogueTree, int startSection, string name, Animator anim) =>
        StartConversation(RunDialogueTree(dialogueTree, startSection), name, anim);


    private void StartConversation(IEnumerator dialogueCoroutine, string name, Animator anim)
    {
        ResetBox();
        nameText.text = name + "...";
        dialogueBox.gameObject.SetActive(true);
        NguyenSingleton.Instance.playerID.playerEvents.OnDialogueStart?.Invoke();
        characterAnim.runtimeAnimatorController = anim.runtimeAnimatorController;
        StartCoroutine(dialogueCoroutine);
    }
    private void Update()
    {
        image.sprite = characterSprite.sprite;
    }
    private IEnumerator ShowText(string line)
    {
        skipLineTriggered = false;
        StartCoroutine(TypeTextUncapped(line));
        yield return new WaitUntil(() => !skipLineTriggered); // Wait for typing or skip
        dialogueText.text = line;
    }


    IEnumerator RunDialogue(string[] dialogue, int startPosition)
    {
        for (int i = startPosition; i < dialogue.Length; i++)
        {

            currentCoroutine = TypeTextUncapped(dialogue[i]);
            StartCoroutine(currentCoroutine);
            while (skipLineTriggered == false)
            {

                yield return null;
            }
            skipLineTriggered = false;

            if (dialogueText.text != dialogue[i])
            {
                StopCoroutine(currentCoroutine);
                dialogueText.text = dialogue[i];
                skipLineTriggered = false;
                while (skipLineTriggered == false)
                {

                    yield return null;
                }
                skipLineTriggered = false;

            }
        }

        NguyenSingleton.Instance.playerID.playerEvents.OnDialogueEnd?.Invoke();
        dialogueBox.gameObject.SetActive(false);
    }
    public void SkipLine()
    {
        skipLineTriggered = true;
    }
    IEnumerator TypeTextUncapped(string line)
    {
        float timer = 0;
        float interval = 1 / charactersPerSecond;
        string textBuffer = null;
        char[] chars = line.ToCharArray();
        int i = 0;

        while (i < chars.Length)
        {
            if (timer < Time.deltaTime)
            {
                textBuffer += chars[i];
                dialogueText.text = textBuffer;
                timer += interval;
                i++;
            }
            else
            {
                timer -= Time.deltaTime;
                yield return null;
            }
        }
    }

    IEnumerator RunDialogueTree(DialogueTree dialogueTree, int section)
    {
        for (int i = 0; i < dialogueTree.sections[section].dialogue.Length; i++)
        {
            currentCoroutine = TypeTextUncapped(dialogueTree.sections[section].dialogue[i]);
            StartCoroutine(currentCoroutine);
            while (skipLineTriggered == false)
            {
                yield return null;
            }
            skipLineTriggered = false;
            if (dialogueText.text != dialogueTree.sections[section].dialogue[i])
            {
                StopCoroutine(currentCoroutine);
                dialogueText.text = dialogueTree.sections[section].dialogue[i];
                skipLineTriggered = false;
                while (skipLineTriggered == false)
                {

                    yield return null;
                }
                skipLineTriggered = false;

            }
        }

        if (dialogueTree.sections[section].endAfterDialogue)
        {
            NguyenSingleton.Instance.playerID.playerEvents.OnDialogueEnd?.Invoke();
            dialogueBox.gameObject.SetActive(false);
            yield break;
        }

        //dialogueText.text = dialogueTree.sections[section].branchPoint.question;
        currentCoroutine = TypeTextUncapped(dialogueTree.sections[section].branchPoint.question);
        StartCoroutine(currentCoroutine);
        while (skipLineTriggered == false)
        {
            yield return null;
        }
        skipLineTriggered = false;
        if (dialogueText.text != dialogueTree.sections[section].branchPoint.question)
        {
            StopCoroutine(currentCoroutine);
            dialogueText.text = dialogueTree.sections[section].branchPoint.question;
            skipLineTriggered = false;
            while (skipLineTriggered == false)
            {

                yield return null;
            }
            skipLineTriggered = false;

        }
        ShowAnswers(dialogueTree.sections[section].branchPoint);

        while (answerTriggered == false)
        {
            yield return null;
        }
        answerBox.SetActive(false);
        answerTriggered = false;

        StartCoroutine(RunDialogueTree(dialogueTree, dialogueTree.sections[section].branchPoint.answers[answerIndex].nextElement));
    }
    void ShowAnswers(BranchPoint branchPoint)
    {
        // Reveals the aselectable answers and sets their text values
        answerBox.SetActive(true);
        for (int i = 0; i < 3; i++)
        {
            if (i < branchPoint.answers.Length)
            {
                answerObjects[i].GetComponentInChildren<TextMeshProUGUI>().text = branchPoint.answers[i].answerLabel;
                answerObjects[i].gameObject.SetActive(true);
            }
            else
            {
                answerObjects[i].gameObject.SetActive(false);
            }
        }
    }
    public void AnswerQuestion(int answer)
    {
        answerIndex = answer;
        answerTriggered = true;
    }
}