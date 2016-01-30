using UnityEngine;

public class SlideButtonScript : MonoBehaviour {
    private RectTransform parentRect;
    private RectTransform pos;
    private GameObject player;
    public Transform legalZone;
    
    void Start() {
        player = transform.parent.GetComponent<CreateButtons>().GetPlayer();
        parentRect = transform.parent.GetComponent<RectTransform>();
        pos = GetComponent<RectTransform>();                    //Minun positio
        legalZone = GameObject.FindGameObjectWithTag("legalZone").transform;
    }

    void Update () {
        //FAIL
        if (pos.localPosition.x >= parentRect.rect.xMax) {
            player.GetComponent<BowingManScript>().hasFailed();
        }

        //TODO: Korjaa oikein päin. Space väärässä = FALEEEE
        if (pos.localPosition.x - pos.rect.width / 2 >= parentRect.rect.width / 3) {
            transform.SetParent(legalZone);
        }

        pos.localPosition += new Vector3(Time.deltaTime * 150f, 0,0);
    }
}
