using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuestionScript : MonoBehaviour {

    enum Choises {A, B, C, D };

    public string QuestionText;
    /*
    public Button ButtonA;
    public Button ButtonB;
    public Button ButtonC;
    public Button ButtonD;
    */
    public string ChoiceTextA;
    public string ChoiceTextB;
    public string ChoiceTextC;
    public string ChoiceTextD;

    public string CorrectChoice;

    public void ButtonClicked(string buttonChar)
    {
        //Debug.Log("Pressed " + buttonChar);
        if (buttonChar == CorrectChoice)
        {
            Debug.Log("YOU HAVE WINNED!");
            // TODO: Handle the win
        }
        else
        {
            Debug.Log("GAME OVER. YOU ARE LOSE!");
            // TODO: Handle the game over
        }
    }

    // Use this for initialization
    void Start () {
        // Set the question text
        this.transform.GetChild(0).GetComponent<Text>().text = QuestionText;
        // Set button texts the most inefficient way possible
        GameObject.Find("ButtonAText").GetComponent<Text>().text = ChoiceTextA;
        GameObject.Find("ButtonBText").GetComponent<Text>().text = ChoiceTextB;
        GameObject.Find("ButtonCText").GetComponent<Text>().text = ChoiceTextC;
        GameObject.Find("ButtonDText").GetComponent<Text>().text = ChoiceTextD;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
