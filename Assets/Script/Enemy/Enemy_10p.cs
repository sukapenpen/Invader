using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_10p : MonoBehaviour {

	public int xAxis = 1;
	public int yAxis = -1;
	public int speed = 1;
	public float waitT = 1.5f;

	private List<Transform> enemys = new List<Transform> ();


	IEnumerator Start () {
		//子要素の取得
		int count = 0;
		foreach(Transform child in gameObject.transform) {
			enemys.Add (child);
			Debug.Log ("Child[" + count + "]:" + child.name);
			count++;
		}
		Debug.Log (enemys.Count);
		while (enemys.Count > 0) {
			yield return new WaitForSeconds (waitT);
			Move ();
			if (enemys [enemys.Count - 1].transform.position.x == -1
				|| enemys [0].transform.position.x == -13) {
				Fall ();
			}
		}
	}

	void Update () {

	}

	void Move () {
		Vector2 position = transform.position;
		position.x += xAxis * speed;
		transform.position = position;
	}

	void Fall () {
		Vector2 position = transform.position;
		position.y += yAxis * speed;
		transform.position = position;
	}
	//-13<x<-1
}
