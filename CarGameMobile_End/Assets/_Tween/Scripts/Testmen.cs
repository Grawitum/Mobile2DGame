using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testmen : MonoBehaviour
{

    [SerializeField][ContextMenu("DoSomething")]
    void DoSomething()
    {
        Debug.Log("Perform operation");
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
