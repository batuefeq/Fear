using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour
{
    bool isPicked;
    public Transform pickUpHolder;
    private GameObject pickUpObject;
    private List<GameObject> inventory = new();

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.gameObject.CompareTag("Throwable") && other.gameObject.transform.parent != gameObject.transform)
            {
                pickUpObject = other.gameObject;
                pickUpObject.transform.parent = pickUpHolder;            
                isPicked = true;
            }
            else if (other.gameObject.CompareTag("QuestObject"))
            {
                inventory.Add(other.gameObject);
                print(inventory);
                Destroy(other.gameObject); // DO STUF                
            }
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.gameObject.CompareTag("Throwable") && other.gameObject.transform.parent != gameObject.transform)
            {
                pickUpObject = other.gameObject;
                pickUpObject.transform.parent = pickUpHolder;
                isPicked = true;
            }
            else if (other.gameObject.CompareTag("QuestObject"))
            {             
                inventory.Add(other.gameObject);
                print(inventory);
                Destroy(other.gameObject);
            }
        }
    }


    private void PickingMechanic()
    {
        if (isPicked)
        {
            pickUpObject.transform.position = pickUpHolder.position;
            if (Input.GetMouseButtonDown(0))
            {
                isPicked = false;
                pickUpObject.transform.parent = null;                
                pickUpObject.GetComponent<Rigidbody>().AddForce(pickUpHolder.forward * Time.deltaTime * 50000f, ForceMode.Impulse);
            }
            if (Input.GetMouseButtonDown(1))
            {
                isPicked = false;
                pickUpObject.transform.parent = null;
            }
        }
    }


    void Start()
    {
        
    }


    void Update()
    {
        PickingMechanic();
    }
}
