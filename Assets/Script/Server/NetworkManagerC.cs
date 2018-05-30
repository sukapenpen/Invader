using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class NetworkManagerC : NetworkManager {

  private int connectPerson = 0;

  public override void OnServerConnect (NetworkConnection conn) {
    connectPerson += 1;
    Debug.Log (connectPerson);
  }

  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {

  }
}
