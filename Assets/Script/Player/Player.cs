using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {

  public int xAxis = 1;
  public int yAxis = -1;
  public float speed = 0.5f;
  public float waitT = 1.5f;
  public double maxRight = -2;
  public double maxLeft = -13;
  public GameObject enemyPrefab;
  private string playerNetID;
  [SyncVar] private string playerName;


  //[SyncVar] private string playerIdentity;

  public override void OnStartLocalPlayer () {
    playerNetID = GetComponent<NetworkIdentity> ().netId.ToString ();
    Debug.Log (playerNetID + "テス");
    if (playerNetID == "1") {
      playerName = "Player1";

      Debug.Log ("やったぜ");
    }
    if (playerNetID == "3") {
      playerName = "Player2";
      Debug.Log ("やりますねぇ");
    }
  }

  // Use this for initialization
  void Start () {
    Debug.Log (playerName + "おおお");
    if (playerName == "Player1") {
      GameObject enemys = Instantiate (enemyPrefab, new Vector3 (-11.0f, 0.0f, 0.0f), Quaternion.identity);
      NetworkServer.Spawn (enemys);
    } else if (playerName == "Player2") {
      GameObject enemys = Instantiate (enemyPrefab, new Vector3 (4.0f, 0.0f, 0.0f), Quaternion.identity);
      NetworkServer.Spawn (enemys);
    }
  }

  // Update is called once per frame
  void Update () {
    if (isLocalPlayer) {
      if (Input.GetKey (KeyCode.RightArrow)) {
        Vector2 position = transform.position;
        position.x += xAxis * speed;
        transform.position = position;
      }
      if (Input.GetKey (KeyCode.LeftArrow)) {
        Vector2 position = transform.position;
        position.x -= xAxis * speed;
        transform.position = position;
      }
    }
  }
}