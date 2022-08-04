using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float horizontalMove;
    private float verticalMove;
    private int countCollectibles;

    [SerializeField] float speed;
    [SerializeField] TextMeshProUGUI countCollectiblesText;
    [SerializeField] TextMeshProUGUI winText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
	countCollectibles = 0;
	CountCollectiblesText();
    }

	void OnMove(InputValue movementValue)
	{
	   Vector2 movementVector = movementValue.Get<Vector2>();
	   horizontalMove = movementVector.x;
	   verticalMove = movementVector.y; 
	}

	void CountCollectiblesText()
	{
	   countCollectiblesText.text = "Token: " + countCollectibles.ToString();

		if (countCollectibles >= 3)
		   {
		     winText.text = "LEVEL 1 \n COMPLETED";
		   }
	}


       private void FixedUpdate()
       {
           Vector3 playerMovement = new Vector3(horizontalMove,0,verticalMove);

		rb.AddForce(playerMovement*speed);
       }

	private void OnTriggerEnter(Collider other)
	{
	   if (other.gameObject.CompareTag("Token-Collectible"))
	   {
	      other.gameObject.SetActive(false);
	      countCollectibles += 1;
	      CountCollectiblesText();

	   }
	}
	
}
