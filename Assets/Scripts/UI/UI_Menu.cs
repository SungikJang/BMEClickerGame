using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Menu : MonoBehaviour
{
    [SerializeField]
    private Button Close;
    // Start is called before the first frame update
    void Start()
    {
        Close.onClick.AddListener(() => {
            this.gameObject.SetActive(false);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
