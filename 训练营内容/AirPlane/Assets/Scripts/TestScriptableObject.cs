using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScriptableObject : MonoBehaviour {
    
    private void Start() {
        
        TestScriptable data = Resources.Load<TestScriptable>("GameData");

        Debug.Log(" GameData  ====> : " + data.val);
    }

}