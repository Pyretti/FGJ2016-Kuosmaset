using UnityEngine;
using UnityEngine.UI;

public class DancingManScript : MonoBehaviour {
    public GameObject buttonToPress;
    public float defaultTimer = 1.5f;
    public float offsetTimer = 1f;

    private PlayerBase pb;
    private float timer = 2f;
    private KeyCode btn;
    private CircleLoad loadBar;
    //qwerasdfzxcv
    private KeyCode[] btnArray = new KeyCode[12];

    //TODO: SIIVOA!!!!!
    void Start() {
        btnArray[0] = KeyCode.Q;
        btnArray[1] = KeyCode.W;
        btnArray[2] = KeyCode.E;
        btnArray[3] = KeyCode.R;
        btnArray[4] = KeyCode.A;
        btnArray[5] = KeyCode.S;
        btnArray[6] = KeyCode.D;
        btnArray[7] = KeyCode.F;
        btnArray[8] = KeyCode.Z;
        btnArray[9] = KeyCode.X;
        btnArray[10] = KeyCode.X;
        btnArray[11] = KeyCode.C;

        btn = GetRandomButton();
        buttonToPress.GetComponentInChildren<TextMesh>().text = btn.ToString();

        //Cicle loaderin alustus
        loadBar = buttonToPress.GetComponent<CircleLoad>();
        loadBar.setTickRate(1.5f);

        buttonToPress.SetActive(false);
    } 

    void Update() {
        timer -= Time.deltaTime;

        if (timer <= 0) {
            buttonToPress.SetActive(true);
            loadBar.goOnline();
            if (Input.GetKeyDown(btn)) {
                btn = GetRandomButton();
                transform.GetComponentInChildren<TextMesh>().text = btn.ToString();
                buttonToPress.SetActive(false);
                timer = defaultTimer;
            }
        }

        //Kuolema
        if(timer <= offsetTimer) {
            //pb.TakeDmg();
        }
    }

    KeyCode GetRandomButton() {
        System.Random rnd = new System.Random();
        return btnArray[rnd.Next(0, 12)];
        //return (KeyCode)rnd.Next(97, 122);
    }

    public float GetTimer() {
        return timer;
    }

    /// <summary>
    /// Decreases timer
    /// </summary>
    /// <param name="decrease">Amount (0.1f - 0.5f)</param>
    public void SetTimer(float decrease) {
        timer -= decrease;
    }

}
