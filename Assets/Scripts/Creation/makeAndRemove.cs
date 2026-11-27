using UnityEngine;

public class makeAndRemove : MonoBehaviour
{

    [SerializeField] private GameObject window_1;
    [SerializeField] private GameObject old_window_1;
    [SerializeField] private bool keepOldWindow;


    //    [SerializeField] private Transform desiredFather;
    public void onClickBrowse()
    {
        if (keepOldWindow == null)
        {
            keepOldWindow = false;
        }


        if (old_window_1 == null) // if i dont give any parameter to old_window_1 it authomatically takes the father of the object with this script attached
            old_window_1 = this.transform.parent.gameObject; 

        if (old_window_1 != null && !keepOldWindow)
            old_window_1.SetActive(false);
        
        window_1.SetActive(true);
        
        if (old_window_1 != null)
            window_1.transform.localPosition = new Vector3(0, 0, 0);

    }

}