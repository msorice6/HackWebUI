using UnityEngine;

public class ZoneSpawnChk : MonoBehaviour
{

    public Transform[] spawnZones;
    [SerializeField] private Transform mail_cellsContainer_no;
    [SerializeField] private Transform mail_cellsContainer_yes;
    [SerializeField] private Transform mail_cellsContainer_maybe;
    public void onButtonPress()
    {

        printSpawnZones();
        if (AllZonesHaveChild() == true)
        {
            int randomSeed = UnityEngine.Random.Range(1, 4); // Returns 1, 2, or 3
            GameObject imageCopy = null;

            switch (randomSeed)
            {
                case 1:
                    imageCopy = Instantiate(mail_cellsContainer_maybe.gameObject, mail_cellsContainer_maybe.transform.parent, false);
                    break;
                case 2:
                    imageCopy = Instantiate(mail_cellsContainer_yes.gameObject, mail_cellsContainer_yes.transform.parent, false);
                    break;
                case 3:
                    imageCopy = Instantiate(mail_cellsContainer_no.gameObject, mail_cellsContainer_no.transform.parent, false);
                    break;
            }

            imageCopy.SetActive(true);
            if (spawnZones != null) {
                Debug.Log("destroy!");
            foreach (Transform zone in spawnZones)
            {
                    if (zone == null) continue;

                    for (int i = zone.childCount - 1; i >= 0; i--)
                    {
                        Destroy(zone.GetChild(i).gameObject);
                    }
                }
            }
        }
    }

    public void printSpawnZones() //  vibecoded AI for testing
    {
        if (spawnZones == null || spawnZones.Length == 0)
        {
            Debug.Log("spawnZones is null or empty");
        }
        else
        {
            string allZones = "";
            for (int i = 0; i < spawnZones.Length; i++)
            {
                Transform z = spawnZones[i];
                allZones += z != null ? $"[{i}] {z.name} (children: {z.childCount}), " : $"[{i}] null, ";
            }
            Debug.Log(allZones);
        }
    }

    private int getNewSpawnZoneLenght()
    {
        int c=0;
        for (int i = 0; i < spawnZones.Length; i++)
        {
            if (spawnZones[i] == null)
                continue;

            c++;
        }
        return c;

    }

    public bool AllZonesHaveChild()
    {
        if (spawnZones == null || spawnZones.Length == 0)
            return false;

        int lenght = getNewSpawnZoneLenght(); // i need to check if there are elements in spawnZone[] wich are null. 


        for (int i = 0; i < lenght; i++)
        {
            if (spawnZones[i] == null || spawnZones[i].childCount == 0)
                return false;
        }
        

        return true;
    }

}
