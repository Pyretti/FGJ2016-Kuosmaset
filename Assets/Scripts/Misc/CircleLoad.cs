using UnityEngine;
using System.Collections;

public class CircleLoad : MonoBehaviour {
    //TODO: Tee niin että sen saa sidottua objektin ympärille?

    public int segments;
	public float xradius;
	public float yradius;
	public float offsetRadius;

	LineRenderer line;
	float tickPeriod = 2f;
	float angle;
	Transform parentTrans;

	bool _online;

	void Start()
	{
		line = gameObject.GetComponent<LineRenderer>();
		line.SetVertexCount(segments + 1);
		line.useWorldSpace = false;

		angle = 360;
		_online = false;
		parentTrans = this.transform.parent.transform;

		xradius = yradius = (parentTrans.lossyScale.y / 2) + offsetRadius;
	}


	// Update is called once per frame
	void Update () {
		if (_online) {
			angle -= Time.deltaTime * (360 / tickPeriod);
			if (angle <= 0) {
				goOffline();
				angle = 0;
			}
			drawCircle (angle);
		}
	}
	public bool isOnline(){
		return _online;
	}
	public void goOffline()	{
		this._online = false;
	}
	//Aloita animaatio
	public void goOnline()	{
		resetTicks ();
		this._online = true;
	}

	//vaihda miten nopeasti tehdään kierros (sekunnit)
	public void setTickRate(float seconds){
		this.tickPeriod = seconds;
	}
	//Aloita kierros alusta
	public void resetTicks(){
		angle = 360;
	}
	//Piirrä viivoilla ympyrä
	private void drawCircle(float currentAngle){
		setLineColor (currentAngle);

		float x;
		float y;
		float z = 0f;
		
		float angle = 20f;
		
		for (int i = 0; i < (segments + 1); i++)
		{
			x = Mathf.Sin (Mathf.Deg2Rad * angle) * xradius;
			y = Mathf.Cos (Mathf.Deg2Rad * angle) * yradius;
			
			line.SetPosition (i ,new Vector3(x,y,z) );
			
			angle += (currentAngle / segments);
		}
	}

	private void setLineColor(float currentAngle)	{
		Color currentColor = getAngleColor (currentAngle);
		this.line.SetColors (currentColor, currentColor);
		line.material = new Material(Shader.Find("Particles/Additive"));
	}

	private Color getAngleColor(float angle){
		Color tmp;

		if (angle > 270f) {
			//tmp = new Color(40, 160, 20, 255);
			tmp = Color.green;
		} 
		else if (angle > 180f) {
			//tmp = new Color(100, 200, 100, 255);
			tmp = Color.green;
		} 
		else if (angle > 120f) {
			//tmp = new Color(200, 200, 100, 255);
			tmp = Color.yellow;
		}  
		else if (angle > 90) {
			//tmp = new Color(250, 200, 0,255);
			tmp = Color.yellow;
		} 
		else {
			//tmp = new Color(230, 60, 20,255);
			tmp = Color.red;
		}

		return tmp;
	}
}
