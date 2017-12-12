using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

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
			if (Right()) {
				yield return new WaitForSeconds (waitT);
				Fall ();
				xAxis = -1;
			} else if (Left()) {
				yield return new WaitForSeconds (waitT);
				Fall ();
				xAxis = 1;
			}
		}
	}

	void Update () {

	}

	//進む、左右はxAxisによりけり
	void Move () {
		Vector2 position = transform.position;
		position.x += xAxis * speed;
		transform.position = position;
	}

	//右端のboolean
	bool Right () {
		for (int i = 0; i < enemys.Count - 1; i ++) {
			foreach(Transform childR in enemys[i]) {
				if (childR.transform.position.x == -2) {
					return true;
				}
			}
		}
		return false;
	}

	//左端のboolean
	bool Left () {
		for (int i = 0; i < enemys.Count - 1; i ++) {
			foreach(Transform childL in enemys[i]) {
				if (childL.transform.position.x == -13) {
					return true;
				}
			}
		}
		return false;
	}

	//一段下げる
	void Fall () {
		Vector2 position = transform.position;
		position.y += yAxis * speed;
		transform.position = position;
	}
}
