using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidadHorizontal = 5f;
    public float fuerzaSalto = 10f;
    public KeyCode teclaIzquierda = KeyCode.LeftArrow;
    public KeyCode teclaDerecha = KeyCode.RightArrow;
    public KeyCode teclaSalto = KeyCode.UpArrow;

    public Transform groundCheck;
    public float radioGroundCheck = 0.2f;
    public LayerMask capaSuelo;

    private Rigidbody2D rb;
    private float inputHorizontal;
    private bool quiereSaltar;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(teclaIzquierda))
        {
            inputHorizontal = -1f;
        }
        else if (Input.GetKey(teclaDerecha))
        {
            inputHorizontal = 1f;
        }
        else
        {
            inputHorizontal = 0f;
        }

        if (Input.GetKeyDown(teclaSalto))
        {
            quiereSaltar = true;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(inputHorizontal * velocidadHorizontal, rb.linearVelocity.y);

        if (quiereSaltar && EstaEnSuelo())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
            quiereSaltar = false;
        }
    }

    private bool EstaEnSuelo()
    {
        return Physics2D.OverlapCircle(groundCheck.position, radioGroundCheck, capaSuelo);
    }

    private void OnDrawGizmos()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, radioGroundCheck);
    }
}