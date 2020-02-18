using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// a placer sur l'objet qui trigger la description

public class ScanTrigger : MonoBehaviour
{
    public Description scan;

    public void TriggerDescription()
    {
        FindObjectOfType<DescriptionManager>().StartDescription(scan);
    }

}
