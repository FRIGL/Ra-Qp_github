using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TupleListElementManager : MonoBehaviour
{
    public Text indexText;

    public RectTransform TupleListElementVariablePrefab;

    public void initializeElement(TupleSaveObject tupleSaveObject, int index, float tupleListXOffset)
    {
        this.indexText.text = index.ToString();

        //build tuple variables
        for (int i = 0; i < tupleSaveObject.GetVariables().Count; i++)
        {
            RectTransform newListElementVariable = Instantiate(TupleListElementVariablePrefab, Vector3.zero, Quaternion.identity);
            newListElementVariable.transform.SetParent(this.transform);
            newListElementVariable.anchoredPosition = new Vector2(tupleListXOffset * i, 0);

            TupleListElementVariableManager manager = newListElementVariable.gameObject.GetComponent<TupleListElementVariableManager>();
            manager.initialize(tupleSaveObject.GetVariables()[i]);
        }
    }
}
