using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TupleListManager : MonoBehaviour
{
    public bool main = false; 

    public TupleList tupleList;

    public Text nameText; 

    [Header("spacing")]
    public float tupleListXOffset = 0;
    public float tupleListYOffset = 0;

    [Header("RectTrasnformListRoots")]
    public RectTransform tupleListKeysList;
    public RectTransform tupleListElementsList;

    [Header("prefabs")]
    public RectTransform TupleListKeyPrefab;
    public RectTransform TupleListElementPrefab;

    public string GetName(){ return tupleList.name; }
    public TupleList GetTupleList(){ return tupleList; }


    public void Set(string name, TupleList tupleList) 
    {
        if(main == false) 
        {      
            this.tupleList = tupleList;
            this.tupleList.name = name;
        }

        Initialize();
    }



    public void Initialize() 
    {
        nameText.text = GetName();
        ReBuildTupleList();
    }

    private void Start()
    {
        Initialize();
    }

    public void ReBuildTupleList()
    {
        DestroyTupleList();
        BuildTupleList();
    }

    public void DestroyTupleList()
    {
        for (var i = tupleListKeysList.transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(tupleListKeysList.transform.GetChild(i).gameObject);
        }

        for (var i = tupleListElementsList.transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(tupleListElementsList.transform.GetChild(i).gameObject);
        }
    }

    public void BuildTupleList() 
    {
        if(tupleList.GetTuples().Count > 0) 
        {
            //build keys
            for (int i = 0; i < tupleList.GetTuples()[0].GetVariables().Count; i++)
            {
                RectTransform newTupleListKey = Instantiate(TupleListKeyPrefab, Vector3.zero, Quaternion.identity);
                newTupleListKey.transform.SetParent(tupleListKeysList);
                newTupleListKey.anchoredPosition = new Vector2(tupleListXOffset * i, 0);

                TupleListKeyManager newTupleListKeyManager = newTupleListKey.gameObject.GetComponent<TupleListKeyManager>();
                newTupleListKeyManager.initializeKey(tupleList.GetTuples()[0].GetVariables()[i].GetVariableName());
            }

            //build elements
            for (int i = 0; i < tupleList.GetTuples().Count; i++)
            {
                RectTransform newTupleListElement = Instantiate(TupleListElementPrefab, Vector3.zero, Quaternion.identity);
                newTupleListElement.transform.SetParent(tupleListElementsList);
                newTupleListElement.anchoredPosition = new Vector2(0, tupleListYOffset * i);

                TupleListElementManager newTupleListElementManager = newTupleListElement.gameObject.GetComponent<TupleListElementManager>();
                newTupleListElementManager.initializeElement(tupleList.GetTuples()[i], i, tupleListXOffset);
            }
        }

        
    }


    public void AddElement()
    {
        tupleList.AddElement(TupleManager.singleton.GetDefaltTupleSaveObject());
        ReBuildTupleList();
    }

    public void SubtractElement()
    {
        tupleList.SubtractElement();
        ReBuildTupleList();
    }
}
