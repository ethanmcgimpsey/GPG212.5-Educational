using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public List<QuestionAndAnswer> questionAndAnswers = new List<QuestionAndAnswer>();
    public TextMeshProUGUI questionText; //All references to ingame objects
    public TMP_InputField answerField;
    public Transform player, playerStartPosition, playerQuestionPosition, playerEndPosition;
    // Start is called before the first frame update
    void Start()
    {
        ResetRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetRoom()
    {
        questionText.text = ""; //Resets question/room
        answerField.text = ""; //Resets answer field
        player.position = playerStartPosition.position; //Resets player's position
        answerField.interactable = false;
        StartCoroutine(EnterRoom());

    }
    public IEnumerator EnterRoom()
    {
        float timer = 0; //Creating a timer variable and setting it to 0. 
        while (timer < 1) //Loops the code while timer is less than one
        {
            player.position = Vector3.Lerp(playerStartPosition.position, playerQuestionPosition.position, timer); //Moves the player from the start position to the question position over the span of the timer
            timer += Time.deltaTime; //increasing the timer
            yield return null; //waits til next frame
        }
        //ask the question
        answerField.interactable = true; //Enables answer field
        QuestionAndAnswer currentQuestion = questionAndAnswers[Random.Range(0, questionAndAnswers.Count)]; //picks random question and answer
        questionText.text = currentQuestion.question; //Displays the question text
    }
    public IEnumerator ExitRoom()
    {
        answerField.interactable = false; //Disables answer field
        float timer = 0; //Creating a timer variable and setting it to 0. 
        while (timer < 1) //Loops the code while timer is less than one
        {
            player.position = Vector3.Lerp(playerQuestionPosition.position, playerEndPosition.position, timer); //Moves the player from the start position to the question position over the span of the timer
            timer += Time.deltaTime; //increasing the timer
            yield return null; //waits til next frame
        }
        ResetRoom();
    }
    public void OnAnswer()
    {
        StartCoroutine(ExitRoom()); //Has player leave room when answer is correct
    }
    
}
