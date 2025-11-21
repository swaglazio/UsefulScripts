using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour

// USAGE AT THE END OF THE SCRIPT

{

    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                // Search for existing instance.
                _instance = FindFirstObjectByType<T>();

                // Create new instance if one doesn't already exist.
                if (_instance == null)
                {
                    // Ensure that there's a GameObject to attach the singleton to.
                    var singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<T>();
                    singletonObject.name = typeof(T).ToString() + " (Singleton)";

                    // Make sure the singleton persists across scenes.
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}



/* Game Manager Exemple
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    
    protected override void Awake()
    {
        base.Awake(); // /!\ Important => Calls the singleton script Awake() [Write awake script under this line]
    }
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
*/
