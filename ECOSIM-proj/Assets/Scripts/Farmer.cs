using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Farmer : MonoBehaviour
{
    private bool isBesaceOpen;
    public Case targetedCase = null;
    public bool interactForUI = false; // will be used to disable buttons on market panel

    public Canvas besace;

    void Start()
    {
        besace.gameObject.SetActive(false);
    }

    void Update()
    {
        isBesaceOpen = besace.gameObject.activeSelf;
        // Right click on interactable
        RightClickOnInteract();
    }

    public void RightClickOnInteract()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            // We create a ray
            Vector3 origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(origin, Vector3.forward);
            // If the ray hits
            if (hit)
            {
                Interactable interact = hit.collider.GetComponent<Interactable>();
                // If close enough
                if (interact != null && interact.isInteractable())
                {
                    if(!isBesaceOpen) //  & besace is closed
                    {
                        if (interact.tag == "case")
                        {
                            interactForUI = false;
                            targetedCase = (Case)interact;
                            // Show seedbag or the vegbag depending on whether there is a seed in the case
                            if (targetedCase.seed != null)
                            {
                                besace.gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                                besace.gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                                besace.gameObject.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
                                besace.gameObject.transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
                            }
                            else
                            {
                                besace.gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
                                besace.gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                                besace.gameObject.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
                                besace.gameObject.transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
                            }
                        }
                        else if (interact.tag == "market")
                            {
                                interactForUI = true; // so we can disable buttons for our vegetables in the market (Selectable)
                                besace.gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false); 
                                besace.gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                                besace.gameObject.transform.GetChild(0).GetChild(2).gameObject.SetActive(true); // open MARKET
                                besace.gameObject.transform.GetChild(0).GetChild(3).gameObject.SetActive(false);
                        }
                         openBesace();
                    }
                    
                    if (isBesaceOpen)
                    {
                        closeBesace();
                    }
                }
            }
        }
    }

    public void openBesace()
    {
        besace.gameObject.SetActive(true); //activeSelf
    }

    public void closeBesace()
    {
        besace.gameObject.SetActive(false); //activeSelf
    }

    public void win()
    {
        besace.gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
        besace.gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        besace.gameObject.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
        besace.gameObject.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
        openBesace();
    }
    
}
