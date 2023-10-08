using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TupleManager : MonoBehaviour
{
    #region Singleton-Shenanigans

    public static TupleManager singleton;

    // Start is called before the first frame update
    void Start()
    {
        if (singleton && singleton != this)
        {
            Destroy(this);
        }
        else
        {
            singleton = this;
        }

        BuildTupleVariableList();
    }

    #endregion


    public TupleSaveObject tupleSaveObject;

    public RectTransform tupleVariableList;

    public RectTransform tupleVariablePrefab;
    public Vector2 tupleVariableOffset = new Vector2(0, 0); 

    public TupleSaveObject GetDefaltTupleSaveObject(){ return tupleSaveObject; }

    public void ReBuildTupleVariableList()
    {
        DestroyTupleVariableList();
        BuildTupleVariableList();
    }

    public void DestroyTupleVariableList()
    {
        for (var i = tupleVariableList.transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(tupleVariableList.transform.GetChild(i).gameObject);
        }
    }

    public void BuildTupleVariableList() 
    {
        for (int i = 0; i < tupleSaveObject.GetVariables().Count; i++)
        {
            RectTransform newTupleVariable = Instantiate(tupleVariablePrefab, Vector3.zero, Quaternion.identity);
            newTupleVariable.transform.SetParent(tupleVariableList);
            newTupleVariable.localScale = Vector3.one;
            newTupleVariable.anchoredPosition = tupleVariableOffset * i;

            TupleVariableManager newTupleVariableManager = newTupleVariable.gameObject.GetComponent<TupleVariableManager>();
            newTupleVariableManager.SetTupleVariableSaveObject(tupleSaveObject.GetVariables()[i]);
        }
    }

 


    public void AddVariable() 
    {
        tupleSaveObject.AddVariable();
        ReBuildTupleVariableList();
    }

    public void SubtractVariable()
    {
        tupleSaveObject.SubtractVariable();
        ReBuildTupleVariableList();
    }
}
