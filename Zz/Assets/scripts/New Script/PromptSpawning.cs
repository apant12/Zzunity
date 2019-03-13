using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PromptSpawning : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _prompt;
    [SerializeField]
    private GameObject[] _morningPrompt;
    [SerializeField]
    private GameObject[] _afternoonPrompt;
    [SerializeField]
    private GameObject[] _nightPrompt;
    [SerializeField]
    private GameObject[] _bedPrompt;
    [SerializeField]
    private GameObject[] _statusPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator NextPrompt(GameObject nextPrompt, float timeNeeded)
    {
        yield return new WaitForSeconds(timeNeeded);
        nextPrompt.SetActive(true);
    }
}
