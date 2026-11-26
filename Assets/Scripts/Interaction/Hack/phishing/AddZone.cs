using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class AddZone : MonoBehaviour
{
    [SerializeField] private Transform[] spawnZones;
    [SerializeField] private Transform targetParent;
    [SerializeField] private Transform scriptZoneSpawnChk; // when i make the spawnZones i need to check if the spawnZones are filled, i need for this a script wich checks if every spawnZone element has a children, i need to pass has parameter to this script the newly created cloned from DraggableZoneItem gameObject, so i pass as parameter the cloned gameObjects to the script and i make the check in ZoneSpawnChk, if the cloned Gameobjects are filled then it sends the mail from ZoneSpawnChk

    public void onButtonPress()
    {
        int n = HasAnyActiveZone();
        for (int i = targetParent.childCount - 1; i >= 0; i--)
        {
            Destroy(targetParent.GetChild(i).gameObject);
        }
        if (n != -1) // checks if web_bank or web_something... is enabled, so if there is 1 those wich has setActive(true)
        {
            Transform activeZone = spawnZones[n];
            int childCount = activeZone.childCount;
            GameObject[] imageCopy = new GameObject[childCount];

            
            ZoneSpawnChk zoneSpawnCheck = scriptZoneSpawnChk.GetComponentInChildren<ZoneSpawnChk>(true);
            zoneSpawnCheck.spawnZones = new Transform[childCount];

            for (int i = 0; i < childCount; i++)
            {
                Transform child = activeZone.GetChild(i);
                imageCopy[i] = Instantiate(child.gameObject, targetParent, false);

                // keep the same size and the same offset from the window centre that the element has in web_home,
                // whatever anchors it uses (fixed or stretch), so the copy sits in the same place inside hack_bank
                RectTransform srcRect = child as RectTransform;
                RectTransform copyRect = imageCopy[i].GetComponent<RectTransform>();
                Vector2 size = srcRect.rect.size;
                copyRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size.x);
                copyRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size.y);


                imageCopy[i].GetComponent<Image>().color = Color.white;

                // remove every script DraggableZoneItemCpy into the ClonedObject
                foreach (var script in imageCopy[i].GetComponentsInChildren<DraggableZoneItemCpy>(true))
                {
                    Destroy(script);
                }


                // remove the uploaded source image uploaded into the component Image
                Image img = imageCopy[i].GetComponent<Image>();
                if (img != null)
                {
                    img.sprite = null;
                    img.color = Color.white;
                }

                imageCopy[i].SetActive(true); 

                // get DraggableZoneItemCpy from child.gameObject and assign imageCopy[i] to zone_1
                DraggableZoneItemCpy draggable = child.gameObject.GetComponentInChildren<DraggableZoneItemCpy>(true);
                if (draggable != null)
                {
                    draggable.zone_1 = imageCopy[i];
                }

                // pass the parameter of the cloned element to spawnZones in ZoneSpawnChk ( when you press the button checks, if zone_1 is filled(every element in zone_1 has a children) then it sends an email
                
                if (zoneSpawnCheck != null)
                {
                    zoneSpawnCheck.spawnZones[i] = imageCopy[i].transform;
                }

            }
        }
    }

    private int HasAnyActiveZone()
    {
        if (spawnZones == null || spawnZones.Length == 0)
            return -1;

        for (int i = 0; i < spawnZones.Length; i++)
        {
            if (spawnZones[i] != null && spawnZones[i].gameObject.activeSelf)
            {
                return i; // Found at least one active zone
            }
        }

        return -1; // No active zones found
    }
}
