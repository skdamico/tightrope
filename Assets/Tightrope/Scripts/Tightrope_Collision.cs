using UnityEngine;
using System.Collections;

public class Tightrope_Collision : MonoBehaviour {
    private RaycastHit hit;
    private GameObject cameraHMD;

    private bool isFalling = false;
    private double timer = 0.0;
    private double delay = 10.0;

    void Awake() {
    }

    void Start() {
        cameraHMD = this.transform.Find("Camera (eye)").gameObject;
    }

    bool IsPlayerOnDestructable() {
        if (Physics.Raycast(cameraHMD.transform.position, Vector3.down, out hit)) {
            return hit.transform.gameObject.name == "env_ledge";
        }

        return false;
    }

    // Update is called once per frame
    void Update() {
        if (!this.isFalling) {
            bool isOnLedge = this.IsPlayerOnDestructable();
            if (isOnLedge && this.timer > this.delay) {
                this.isFalling = true;
                this.timer = 0.0;
                Rigidbody rigidbody = this.GetComponent<Rigidbody>();
                rigidbody.useGravity = true;

                Rigidbody ledgebody = hit.transform.gameObject.GetComponent<Rigidbody>();
                ledgebody.useGravity = true;
                ledgebody.isKinematic = false;
                ledgebody.AddTorque(hit.transform.up * 0.4f);
                ledgebody.AddTorque(hit.transform.right * 0.1f);
                ledgebody.AddForce(hit.transform.up * -20.0f);

                Debug.Log("Player is on the ledge!");
            }
            else if (!isOnLedge) {
                this.timer = 0.0;
            }
            else {
                // increment timer
                this.timer += Time.deltaTime;
            }
        }
    }
}
