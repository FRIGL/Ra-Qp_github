using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonConverter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public string WriteTupleListQuiry(TupleListQuiry tupleListQuiry)
    {
        string json = JsonUtility.ToJson(tupleListQuiry, false);
        return json;
    }

    public TupleListQuiry ReadTupleListQuiry(string tupleListQuiryJsonString)
    {
        TupleListQuiry tupleListQuiry = JsonUtility.FromJson<TupleListQuiry>(tupleListQuiryJsonString);
        return tupleListQuiry;
    }
}

/*
 * 
 * 
 * 
 *         VesselSaveObejct vesselSaveObejct = JsonUtility.FromJson<VesselSaveObejct>(VesselSaveSystem.Load());

        LoadVessel(vesselSaveObejct);
*/
