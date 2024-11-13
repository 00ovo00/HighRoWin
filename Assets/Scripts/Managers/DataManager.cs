using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : SingletonBase<DataManager>
{
    private int _rowCount = 0;
    public Action OnScoreChanged;
    
    public int RowCount
    {
        get
        {
            return _rowCount;
        }
        set
        {
            _rowCount = value;
            OnScoreChanged?.Invoke();
        }
    }
}
