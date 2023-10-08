using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueryProcessor : MonoBehaviour
{
    public List<Query> Querys;

    public void ApplyQuerys() 
    {
        foreach (Query thisQuery in Querys)
        {
            thisQuery.ApplyQuiry();
        }
    }
}
