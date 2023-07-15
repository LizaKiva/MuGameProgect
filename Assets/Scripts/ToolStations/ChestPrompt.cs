using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestPrompt : MonoBehaviour
{
    private GameObject PromptObject;
    private float promptStayDelay = 0.5F;
    private float promptLeftDelay = 0F;

    void Start()
    {
        PromptObject = transform.GetChild(0).gameObject;
        DisablePrompt();
    }

    IEnumerator StartCountdown()
    {
        while (promptLeftDelay > 0)
        {
            promptLeftDelay -= Time.deltaTime;
            yield return null;
        }

        DisablePrompt();
        yield return null;
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (promptLeftDelay <= 0)
            {
                EnablePrompt();
                promptLeftDelay = promptStayDelay;
                StartCoroutine(StartCountdown());
            }
            else
            {
                promptLeftDelay = promptStayDelay;
            }
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
