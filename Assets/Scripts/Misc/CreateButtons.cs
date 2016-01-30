using UnityEngine;

public class CreateButtons : MonoBehaviour {
    public GameObject btn;
    public GameObject player; //Tyhmästi tehty mutta en keksinyt parempaa.

    float timer = 1f;
    float position;

    void Start() {
        position = GetComponent<RectTransform>().rect.xMin;
    }

    void Update() {
        timer -= Time.deltaTime;
        if(timer <= 0) { 
            GameObject go = (GameObject)Instantiate(btn, new Vector3(position + 460, transform.position.y, 0), Quaternion.identity);
            go.transform.SetParent(transform);
            timer = 1f;
        }
    }

    public GameObject GetPlayer() {
        return player;
    }

}
