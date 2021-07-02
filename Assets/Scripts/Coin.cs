using UnityEngine;

public class Coin : MonoBehaviour {

    [SerializeField] float turnSpeed = 90f;

    private void OnTriggerEnter (Collider collider) {

        // Check that object we collided which is player
        if (collider.gameObject.name != "Player") {
            return;
        }

        // Add to the player's score
        GameManager.inst.IncrementScore ();

        // Destroy this coin object
        Destroy (gameObject);

    }

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        transform.Rotate (0, 0, turnSpeed * Time.deltaTime);
    }
}