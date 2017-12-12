using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_40p : MonoBehaviour {
	
	public int xAxis = 1;
	public int speed = 1;
	public float waitT = 1.5f;

	IEnumerator Start () {
		for (int i = 0; i < 10; i++) { //1列の敵がいなくなるまで
			yield return new WaitForSeconds (waitT);
			Move ();
		}
	}

	void Update () {

	}

	void Move () {
		Vector2 position = transform.position;
		position.x += xAxis * speed;
		transform.position = position;
	}
}
