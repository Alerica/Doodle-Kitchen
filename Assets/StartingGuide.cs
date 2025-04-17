using UnityEngine;
using TMPro;
using System.Collections;

public class StartingGuide : MonoBehaviour
{
    public TextMeshProUGUI startingText;   
    public GameObject startingPanel;
    private float typingSpeed = 0.04f;

    private string[] dialogLines = 
    {
        "Welcome to the Doodle Kitchen!",
        "My name is Doodles.",
        "I need your help in the kitchen.",
        "I have a recipe book—it contains so many recipes.",
        "But it seems I lost my recipe book.",
        "You need to make food in the Doodle Kitchen so I can write the recipes.",
        "Don't worry, when things get too hard, I'll come along to help.",
        "Happy cooking!"
    };


    private int currentLine = 0;
    private bool isTyping = false;

    void Start()
    {
        StartCoroutine(TypeLine(dialogLines[currentLine]));
    }

    public void ShowNextLine()
    {
        if (isTyping) return;

        currentLine++;

        if (currentLine < dialogLines.Length)
        {
            StartCoroutine(TypeLine(dialogLines[currentLine]));
        }
        else
        {
            startingPanel.SetActive(false);
        }
    }

    IEnumerator TypeLine(string line)
    {
        isTyping = true;
        startingText.text = "";

        foreach (char c in line)
        {
            startingText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }
}
