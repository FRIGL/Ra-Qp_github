using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonTest01 : MonoBehaviour
{
    public JsonConverter jsonConverter;

    public TupleListQuiry tupleListQuiry; 

    public string output;

    // Start is called before the first frame update
    void Start()
    {
        output = jsonConverter.WriteTupleListQuiry(tupleListQuiry);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
