using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private int m_count = 0;
    private Rigidbody rb;
    public Text m_countText;
    public Text m_winText;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        SetCountText();
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        rb.AddForce (movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            m_count++;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        m_countText.text = "Count : " + m_count.ToString ();

        if (m_count >= 12)
        {
            m_winText.text = "You Win !";
        }
    }
}