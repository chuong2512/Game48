using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIdeAfter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Hide());
        
        IEnumerator Hide()
        {
            yield return new WaitForSeconds(8);
            gameObject.SetActive(false);
        }
    }
}
