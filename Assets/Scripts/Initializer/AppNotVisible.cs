using UnityEngine;

public class AppNotVisible : MonoBehaviour
{

    public GameObject[] runPictures;

    void Awake()
    {
        for (int i = 0; i < runPictures.Length; i++)
        {
            if (runPictures[i] != null)
            {
                runPictures[i].SetActive(false);
            }
        }
    }    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
