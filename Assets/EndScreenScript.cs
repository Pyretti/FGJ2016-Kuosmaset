using UnityEngine;
using UnityEngine.UI;
public class EndScreenScript : MonoBehaviour {
    public GameObject gameManager;
    public Text grade;
    public Text time;

    private GameManager s;

    void Start() {
        s = gameManager.GetComponent<GameManager>();
        gameObject.SetActive(true);
    }

    void OnEnable() {
        SecondTime t = new SecondTime();
        time.text = s.ReturnTime();
        
        //TODO: Testaaaaaa
        //< 0.30

        //ABCDF
        if(t.min == 0 && t.sec < 30) {
            grade.text = "F!"; 
        }else if(t.min == 0 && t.sec >= 30){ // 0.30 - 1min
            grade.text = "C";
        } 
        else if (t.min == 1 && t.sec < 30) { // < 1.30
            grade.text = "B";
        } 
        else if (t.min == 1 && t.sec >= 30) { // < 2min
            grade.text = "A-";
        } 
        else if (t.min == 2 && t.sec < 30) {
            grade.text = "A";
        } else { //Victory
            grade.text = "A+";
        }
    }
}
