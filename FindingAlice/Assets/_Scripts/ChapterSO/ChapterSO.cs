using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chapter", menuName = "ScriptableObjects/ChapterScriptableObject")]
public class ChapterSO : ScriptableObject
{
    #region "Public"
    public string synopsys;
    public Sprite chapterSprite;
    #endregion
}
