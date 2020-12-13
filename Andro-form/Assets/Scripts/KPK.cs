using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KPK : MonoBehaviour
{
    public GameObject InteractionButton;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        InteractionButton.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InteractionButton.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
