using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonTest02 : MonoBehaviour
{
    public JsonConverter jsonConverter;

    

    public string input;

    public TupleListQuiry tupleListQuiry;

    // Start is called before the first frame update
    void Start()
    {
        tupleListQuiry = jsonConverter.ReadTupleListQuiry(input);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
