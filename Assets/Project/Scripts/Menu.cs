using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Project.Scripts;
using TMPro;

public class Menu : MonoBehaviour
{
    private string[] _list = {"a1247.swc", "a1531.swc", "a1963.swc", "a2191.swc", "a3783.swc", "pkj1559.swc",};

    // Start is called before the first frame update
    void Start()
    {
        var dropdown = gameObject.GetComponent<TMP_Dropdown>();
        dropdown.options = new List<TMP_Dropdown.OptionData>();
        foreach (var l in _list)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData {text = l});
            dropdown.RefreshShownValue();
        }
    }
}