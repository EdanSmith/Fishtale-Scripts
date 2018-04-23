//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;
//using System;

public static class CustomMenuItems
{
    //[MenuItem("GameObject/Convert To TextMeshPro (UI)", false, 0)]
    //public static void ConvertTextToTMP()
    //{
    //    ItemSpecificationWindow itemSpecificationWindow = (ItemSpecificationWindow)AssetDatabase.LoadAssetAtPath("Assets/Resources/Prefabs/ItemSpecificationWindow.prefab", typeof(ItemSpecificationWindow));
    //    //ItemSpecificationWindow itemSpecificationWindow = Instantiate(Resources.Load("Prefabs/ItemSpecificationWindow"));

    //    GameObject selection = Selection.activeGameObject;
    //    Text sourceText = selection.GetComponent<Text>();
    //    RectTransform sourceRect = selection.GetComponent<RectTransform>();
    //    if (sourceText == null)
    //    {
    //        Debug.Log("No Text found to replace.");
    //        return;
    //    }

    //    GameObject destinationGo = GameObject.Instantiate(selection);
    //    destinationGo.name = selection.name;
    //    destinationGo.transform.SetParent(selection.transform.parent.transform, false);
    //    destinationGo.transform.SetSiblingIndex(selection.transform.GetSiblingIndex() + 1);
    //    GameObject.DestroyImmediate(destinationGo.GetComponent<Text>());

    //    TextMeshProUGUI destinationText = destinationGo.AddComponent<TextMeshProUGUI>();
    //    destinationText.font = itemSpecificationWindow.getFont();

    //    destinationText.text = sourceText.text;
    //    destinationText.fontSize = sourceText.fontSize;
    //    destinationText.color = sourceText.color;

    //    TextAlignmentOptions destinationAlignment = TextAlignmentOptions.Midline;
    //    TextAnchor anchor = sourceText.alignment;
    //    switch (anchor)
    //    {
    //        case TextAnchor.LowerCenter:
    //            destinationText.alignment = TextAlignmentOptions.Bottom;
    //            break;
    //        case TextAnchor.LowerLeft:
    //            destinationText.alignment = TextAlignmentOptions.BottomLeft;
    //            break;
    //        case TextAnchor.LowerRight:
    //            destinationText.alignment = TextAlignmentOptions.BottomRight;
    //            break;
    //        case TextAnchor.MiddleCenter:
    //            destinationText.alignment = TextAlignmentOptions.Center;
    //            break;
    //        case TextAnchor.MiddleLeft:
    //            destinationText.alignment = TextAlignmentOptions.Left;
    //            break;
    //        case TextAnchor.MiddleRight:
    //            destinationText.alignment = TextAlignmentOptions.Right;
    //            break;
    //        case TextAnchor.UpperCenter:
    //            destinationText.alignment = TextAlignmentOptions.Top;
    //            break;
    //        case TextAnchor.UpperLeft:
    //            destinationText.alignment = TextAlignmentOptions.TopLeft;
    //            break;
    //        case TextAnchor.UpperRight:
    //            destinationText.alignment = TextAlignmentOptions.TopRight;
    //            break;
    //        default:
    //            destinationText.alignment = TextAlignmentOptions.Midline;
    //            break;
    //    }

    //    //overflow
    //    if (sourceText.horizontalOverflow == HorizontalWrapMode.Overflow || sourceText.verticalOverflow == VerticalWrapMode.Overflow)
    //    {
    //        destinationText.enableWordWrapping = false;
    //        destinationText.overflowMode = TextOverflowModes.Overflow;
    //    }

    //    //reset the rect because adding a TMPro component resets it
    //    RectTransform destinationRect = destinationGo.GetComponent<RectTransform>();
    //    destinationRect.sizeDelta = sourceRect.sizeDelta;

    //    destinationText.UpdateFontAsset();

    //    GameObject.DestroyImmediate(sourceText.gameObject);
    //}

    //private static ItemSpecificationWindow Instantiate(UnityEngine.Object @object)
    //{
    //    throw new NotImplementedException();
    //}
}