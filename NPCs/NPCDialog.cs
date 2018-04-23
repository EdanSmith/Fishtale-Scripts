using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NPCDialog
{
    public string id;
    public List<string> dialog;
    public string preRequisite;

    public string getDialog()
    {
        return this.id;
    }
}
