using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Enemy : NetworkBehaviour {

  public int xAxis = 1;
  public int yAxis = -1;
  public int speed = 1;
  public float waitT = 1.5f;
  public float point1 = -2.0f;
  public float point2 = -13.0f;
  private float maxRight;
  private float maxLeft;
  [SyncVar] private string enemyName;


  private List<Transform> enemys = new List<Transform> ();

  /*問題点
	 * 親の親を支点にlocalPositionしたいけどどうすれば・・・
	 * 理由はネット対戦のための個別化したプレイヤーオブジェクトのため
	 */

  /* 問題点の解決？
   * 作成時に座標指定すればよさそう
   */


  IEnumerator Start () {
    //if (isLocalPlayer)
    //{
    //子要素の取得
    if (transform.position.x == -11.0f) {
      maxRight = point1;
      maxLeft = point2;
      enemyName = "Player1";
    }
    if (transform.position.x == 4.0f) {
      maxRight = point2 * -1;
      maxLeft = point1 * -1;
      enemyName = "Player2";
    }
    int count = 0;
    foreach (Transform child in gameObject.transform) {
      enemys.Add (child);
      Debug.Log ("Child[" + count + "]:" + child.name);
      count++;
    }
    Debug.Log (enemys.Count);
    while (enemys.Count > 0) {
      yield return new WaitForSeconds (waitT);
      Move ();
      if (Right ()) {
        yield return new WaitForSeconds (waitT);
        Fall ();
        xAxis = -1;
      } else if (Left ()) {
        yield return new WaitForSeconds (waitT);
        Fall ();
        xAxis = 1;
      }
      //}
    }
  }

  void Update () {

  }

  //進む、左右はxAxisによりけり
  //[Command]
  void Move () {
    Vector2 position = transform.position;
    position.x += xAxis * speed;
    transform.position = position;
  }

  //右端のboolean
  //[Command]
  bool Right () {
    for (int i = 0; i < enemys.Count - 1; i++) {
      foreach (Transform childR in enemys [i]) {
        if (childR.transform.position.x == maxRight) {
          Debug.Log ("右");
          return true;
        }
      }
    }
    return false;
  }

  //左端のboolean
  //[Command]
  bool Left () {
    for (int i = 0; i < enemys.Count - 1; i++) {
      foreach (Transform childL in enemys [i]) {
        if (childL.transform.position.x == maxLeft) {
          Debug.Log ("左");
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
