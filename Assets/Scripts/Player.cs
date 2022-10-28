using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpAmount;
    public float downAmount;

    public Rigidbody2D rb;

    //Pulo
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public int numeroDescida;


    void Start()
    {

    }

    void Update()
    {
        if (GameManager.instance.gameIsOver)
            return;

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded)
        {
            numeroDescida = 1;
        }

        //Movimentacao
        if (Input.GetButtonDown("Pular"))
        {
            Jump();
        }

        if (Input.GetButtonDown("Descer") )
        {
            Down();
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            EfeitosSonoros.instance.somPulo.Play();
        }
    }

    public void Down()
    {
        if (numeroDescida >= 1)
        {
            rb.AddForce(Vector2.down * downAmount, ForceMode2D.Impulse);
            numeroDescida -= 1;
        }
    }
}
