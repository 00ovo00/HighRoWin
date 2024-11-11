using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : SingletonBase<DataManager>
{
    private int rowCount = 0;
    public Action OnScoreChanged;
    
    public int RowCount
    {
        get
        {
            return rowCount;
        }
        set
        {
            rowCount = value;
            OnScoreChanged?.Invoke();
        }
    }
}
