using UnityEngine;
using System.Collections;

public class Tightrope_LedgeBreak : MonoBehaviour {

    private GameObject mainCamera;
    private RaycastHit hit;

    void Awake() {
        print("why you no log");
        mainCamera = GameObject.Find("tr_hmd");
    }

    void Start() {
    }

    bool IsPlayerOnLedge() {
        /*
        if (Physics.Raycast(mainCamera.transform.position, Vector3.down, out hit)) {
            print("We hit");
            return true;//hit.transform.gameObject == this.gameObject;
        }
        */
        return false;
    }

    // Update is called once per frame
    void Update() {
        if (this.IsPlayerOnLedge()) {
            print("Player is on the ledge!");
        }
    }
}
