using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool Oyuncu1_mi;
    public Rigidbody2D rb;
    public float OyuncuHizi = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Oyuncu1_mi)
        {
            rb.velocity = Vector2.up * Input.GetAxisRaw("Vertical") * OyuncuHizi;           
        }
        else
        {
			rb.velocity = Vector2.up * Input.GetAxisRaw("Vertical2") * OyuncuHizi;

		}
	}
}
