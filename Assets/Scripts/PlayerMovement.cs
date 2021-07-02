using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    bool alive = true;

    public float speed = 5;
    [SerializeField] Rigidbody rb;

    // float horizontalInput;
    int playerPosition = 1;
    // [SerializeField] float horizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;

    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;

    private void FixedUpdate () {

        if (!alive) {
            return;
        }

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        // Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        Vector3 movePost = rb.position + forwardMove;

        switch (playerPosition) {
            case 0:
                // if (movePost.x > -3) {
                // movePost.x = movePost.x - 1;
                // break;
                // }
                movePost.x = -3;
                break;
            case 1:
                movePost.x = 0;
                break;
            case 2:
                movePost.x = 3;
                break;
            default:
                break;
        }

        // print (movePost);
        rb.MovePosition (movePost);
    }

    // Update is called once per frame
    void Update () {
        // horizontalInput = Input.GetAxis ("Horizontal");

        if (Input.GetKeyDown (KeyCode.LeftArrow) && playerPosition > 0) {
            playerPosition--;
        } else if (Input.GetKeyDown (KeyCode.RightArrow) && playerPosition < 2) {
            playerPosition++;
        }

        if (Input.GetKeyDown (KeyCode.UpArrow)) {
            Jump ();
        }
    }

    public void Die () {
        alive = false;

        Invoke ("Restart", 2);
    }

    public void Restart () {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
    }

    void Jump () {
        // Check whether we are currently grounded
        float height = GetComponent<Collider> ().bounds.size.y;
        bool isGrounded = Physics.Raycast (transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        // If we are, jump
        rb.AddForce (Vector3.up * jumpForce);
    }
}