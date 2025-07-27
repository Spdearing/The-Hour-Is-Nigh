using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private bool blobDied;

    [Header("Scripts")]

    [Header("Enemy")]
    [SerializeField] private GameObject smallBlob;
    [SerializeField] private GameObject mediumBlob;
    [SerializeField] private GameObject largeBlob;

    private void Awake()
    {
        if (Instance != null && Instance != this){
            Destroy(gameObject); 
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }
}
