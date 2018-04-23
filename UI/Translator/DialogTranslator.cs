using NodeCanvas.DialogueTrees;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogTranslator : MonoBehaviour {

    private DialogueTreeController dtc;
    public string[] dialogs;

	// Use this for initialization
	void Start () {
        dtc = GetComponent<DialogueTreeController>();
        dialogs = dtc.blackboard.GetVariableNames();

        foreach (string dialog in dialogs)
        {
            try
            {
                dtc.blackboard.SetValue(dialog, TranslatorManager.instance.GetDialogTranslationById(dialog));
            }catch(KeyNotFoundException e)
            {
                Debug.LogWarning(" Not found the translation of the id '" + dialog + "' on the excel file.");
            }
        }
	}
}
