using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    
    private static Manager s_instance;
    private static Manager Instance { get { Init(); return s_instance; } }
    
    
    
    private ObjectManager ObjectManager = new ObjectManager();
    
    public static ObjectManager Obj { get { return Instance.ObjectManager; } }
    
    
    
    private ResourceManager ResourceManager = new ResourceManager();
    private PoolManager PoolManager = new PoolManager();
    private InputManager _input_manager = new InputManager();
    private UIManager UIManager = new UIManager();
    private SceneManagers SceneManager = new SceneManagers();
    
    
    public static ResourceManager Resource { get { return Instance.ResourceManager; } }
    public static PoolManager Pool { get { return Instance.PoolManager; } }
    public static UIManager UI { get { return Instance.UIManager; } }
    public static SceneManagers Scene { get { return Instance.SceneManager; } }
    public static InputManager Input { get { return Instance._input_manager; } }
    
    private static void Init() {
        if (s_instance == null) {
            GameObject Go = GameObject.Find("@Manager");
            if (Go == null) {
                Go = new GameObject("@Manager");
                Go.AddComponent<Manager>();
            }
            DontDestroyOnLoad(Go);
            s_instance = Go.GetComponent<Manager>();
            //s_instance.DataManager.Init();
            //s_instance.PoolManager.Init();
            //s_instance.NetworkManager.Init();
        }
    }
    
    public static void Clear() {
        Input.Clear();
        UI.Clear();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
