using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public GameObject[] tab;

    public void test()
    {
        Debug.Log("c'est cliqué");
    }

    public void ChangeTab()
    {
        tab[0].SetActive(false);
        Debug.Log("ça disparait");
    }
    /*private void OnMouseDown()
    {
        gameObject.GetComponent<SceneLoader>().LoadScene(0);
        Debug.Log("t'as cliqué");
    }*/
}
