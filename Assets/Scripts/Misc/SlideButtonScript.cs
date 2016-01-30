using UnityEngine;

public class SlideButtonScript : MonoBehaviour {
    private RectTransform parentRect;
    private RectTransform pos;
    private GameObject player;
    
    void Start() {
        player = transform.parent.GetComponent<CreateButtons>().GetPlayer();
        parentRect = transform.parent.GetComponent<RectTransform>();
        pos = GetComponent<RectTransform>();                    //Minun positio
    }

    void Update () {
        //FAIL
        if (pos.localPosition.x >= parentRect.rect.xMax) {
            player.GetComponent<BowingManScript>().hasFailed();
        }
        
        //TODO: Korjaa oikein päin. Space väärässä = FALEEEE
        if(pos.localPosition.x >= parentRect.rect.width / 3) {
            if (Input.GetKey(KeyCode.Space)){
                player.GetComponent<BowingManScript>().ChangeAnimator();
                Destroy(gameObject);
            }
        }
        pos.localPosition += new Vector3(Time.deltaTime * 150f, 0,0);
	}
}
