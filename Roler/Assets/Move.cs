using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody player;

    public GameManager gm;

    public float runSpeed = 500f;
    public float strafeSpeed = 500f;
    public float jumpForce = 15f;

    protected bool strafeLeft = false;
    protected bool strafeRight = false;
    protected bool Jump = false;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "obstacles")
        {
            gm.EndGame();
            Debug.Log("Game Over");
        }
    }

    void Update()
    {
        if(Input.GetKey("a"))
        {
            strafeLeft = true;
        }
        else
        {
            strafeLeft = false;
        }

        if(Input.GetKey("d"))
        {
            strafeRight = true;
        } 
        else
        {
            strafeRight = false;
        }
        if(Input.GetKeyDown("space"))
        {
            Jump = true;
        }
        if(transform.position.y < -2f) 
        {
            gm.EndGame();
            Debug.Log("Game Over");
        }
       
    }

    void FixedUpdate()
    {
        //player.AddForce(0, 0, runSpeed * Time.deltaTime);

        player.MovePosition(transform.position + Vector3.forward * runSpeed * Time.deltaTime);

        if(strafeLeft)
        {
            player.AddForce(-strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if(strafeRight)
        {
            player.AddForce(strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Jump)
        {
            player.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Jump = false;
        }
    }

}
