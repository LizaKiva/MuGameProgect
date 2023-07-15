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
    
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(promptLeftDelay <= 0)
            {
                EnablePrompt();
                StartCoroutine(StartCountdown());
            }
            promptLeftDelay = promptStayDelay;
        }
    }

    void EnablePrompt()
    {
        PromptObject.SetActive(true);
    }

    void DisablePrompt()
    {
        PromptObject.SetActive(false);
    }
}
