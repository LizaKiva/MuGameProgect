using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestPrompt : MonoBehaviour
{
    private GameObject PromptObject;

    void Start()
    {
        PromptObject = transform.GetChild(0).gameObject;
        DisablePrompt();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EnablePrompt();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DisablePrompt();
        }
    }

    void EnablePrompt()
    {
        Debug.Log("Enabled Chest prompt");
        PromptObject.SetActive(true);
    }

    void DisablePrompt()
    {
        Debug.Log("Disabled Chest prompt");
        PromptObject.SetActive(false);
    }
}
