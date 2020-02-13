using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// a placer sur l'objet qui trigger la description

public class DescriptionTrigger : MonoBehaviour
{
    public Description description;

    public void TriggerDescription()
    {
        FindObjectOfType<DescriptionManager>().StartDescription(description);
    }

}
