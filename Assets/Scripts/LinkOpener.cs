using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkOpener : MonoBehaviour
{
    [SerializeField] private string url = "https://docs.google.com/document/d/14hujaMUbd0in7deEKVlxeN6yg6kUwpua65xjsHyGnvA/edit?usp=sharing";

    public void OpenLink()
    {
        Application.OpenURL(url);
    }

}
