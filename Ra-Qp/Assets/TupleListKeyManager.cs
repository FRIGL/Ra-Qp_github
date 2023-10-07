using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TupleListKeyManager : MonoBehaviour
{
    public Text key; 

    public void initializeKey(string key) 
    {
        this.key.text = key;
    }
}
