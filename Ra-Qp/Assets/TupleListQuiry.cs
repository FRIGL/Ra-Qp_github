using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TupleListQuiry
{
    public TupleList inputList;

    public int queryType;
    public string queryCondition;

    public TupleList outputList;

    public TupleListQuiry(TupleList inputList, int queryType, string queryCondition, TupleList outputList) 
    {
        this.inputList = inputList;
        this.queryType = queryType;
        this.queryCondition = queryCondition;
        this.outputList = outputList;
    }
}
