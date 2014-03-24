using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float JumpForce = 300;
    public float MoveSpeed = .1f;
    public int RotateSpeed = 3;

    private bool _isCollidingGround;
    private bool _isRotating;
    private int _degreeRemaining;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_isRotating)
        {
            if (_degreeRemaining > 0)
            {
                transform.Rotate(0f, RotateSpeed, 0f);
                _degreeRemaining -= RotateSpeed;
            }
            else
            {
                transform.Rotate(0f, -RotateSpeed, 0f);
                _degreeRemaining += RotateSpeed;
            }

            if (_degreeRemaining == 0)
                _isRotating = false;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && _isCollidingGround)
                rigidbody.AddForce(new Vector3(0f, JumpForce, 0f));

            if (Input.GetKeyDown(KeyCode.Q))
            {
                _isRotating = true;
                _degreeRemaining = 90;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                _isRotating = true;
                _degreeRemaining = -90;
            }

            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * MoveSpeed, 0, 0));
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.collider.tag == "Ground")
            _isCollidingGround = true;
    }

    void OnCollisionExit(Collision c)
    {
        if (c.collider.tag == "Ground")
            _isCollidingGround = false;
    }
}
