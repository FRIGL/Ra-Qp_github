using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TupleListsOrganizer : MonoBehaviour
{
    #region Singleton-Shenanigans

    public static TupleListsOrganizer singleton;

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
    }

    #endregion



    public List<TupleListManager> tupleListManagers;

    [Header("instigation")]
    public RectTransform tupleListManagersRoot;
    public float tupleListManagersXOffset = 0;
    public RectTransform tupleListManagerPrefab;

    public TupleList GetTupleList(string name) 
    {
        foreach (TupleListManager thisTupleListManager in tupleListManagers)
        {
            if(thisTupleListManager.GetName() == name)
            {
                return thisTupleListManager.GetTupleList();
            }
        }

        return null;
    }

    public TupleListManager GetTupleListManager(string name) 
    {
        TupleListManager tupleListManager = tupleListManagers.Find(t => t.GetName() == name);

        if(tupleListManager == null) 
        {
            tupleListManager = AddTupleListManager( name);
        }

        return tupleListManager;
    }

    public TupleListManager AddTupleListManager(string name)
    {
        RectTransform newTupleListManager = Instantiate(tupleListManagerPrefab, Vector3.zero, Quaternion.identity);
        newTupleListManager.transform.SetParent(tupleListManagersRoot);
        newTupleListManager.localScale = Vector3.one;
        newTupleListManager.anchoredPosition = new Vector2(tupleListManagersXOffset * tupleListManagers.Count, 0);

        TupleListManager manager = newTupleListManager.gameObject.GetComponent<TupleListManager>();

        tupleListManagers.Add(manager);

        return manager;
    }
}
