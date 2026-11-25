using UnityEngine;

public class makeAndRemove : MonoBehaviour
{

    [SerializeField] private GameObject window_1;
    [SerializeField] private GameObject old_window_1;

//    [SerializeField] private Transform desiredFather;
    public void onClickBrowse()
    {

        if (old_window_1 != null)
            old_window_1.SetActive(false);
        
        window_1.SetActive(true);
        
        if (old_window_1 != null)
            window_1.transform.localPosition = new Vector3(0, 0, 0);
        //window_1.transform.SetParent(desiredFather, false);

    }

}
