using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using System.Reflection;

[InitializeOnLoad]
public static class ShowFileExtensions
{
    // ================================================================================
    //  static constructor
    // --------------------------------------------------------------------------------

    static ShowFileExtensions()
    {
        EditorApplication.projectWindowItemOnGUI += ProjectWindowItemOnGUI;
    }

    // ================================================================================
    //  checking editor events
    // --------------------------------------------------------------------------------

    private static void ProjectWindowItemOnGUI(string guid, Rect rect)
    {
        if (Event.current.alt)
        {
            EditorWindow window = GetProjectWindow();

            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            UnityEngine.Object obj = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(assetPath);

            if (obj != null && AssetDatabase.IsMainAsset(obj) && !IsDirectory(obj))
            {
                if (showsBigIcons)
                {
                    // just draw it bold in upper left
                    string extension = Path.GetExtension(assetPath);
                    GUI.Label(rect, extension, EditorStyles.boldLabel);
                }
                else
                {
                    // we overpaint the filename here, does look a bit dirty and might need adjustment of the offset
                    var labelRect = rect.Translate(new Vector2(16f, 1f));
                    var fileName = Path.GetFileName(assetPath);
                    GUI.Label(labelRect, fileName);
                }
            }

            EditorApplication.RepaintProjectWindow();
        }
    }

    // ================================================================================
    //  getting infos about the project window
    // --------------------------------------------------------------------------------

    private static bool showsBigIcons
    {
        get
        {
            return isTwoColumnMode && listAreaGridSize > 16f;
        }
    }

    private static bool isTwoColumnMode
    {
        get
        {
            var projectWindow = GetProjectWindow();

            var projectWindowType = projectWindow.GetType();
            var modeFieldInfo = projectWindowType.GetField("m_ViewMode", BindingFlags.Instance | BindingFlags.NonPublic);

            int mode = (int)modeFieldInfo.GetValue(projectWindow);

            // 0 == ViewMode.OneColumn
            // 1 == ViewMode.TwoColum

            return mode == 1;
        }
    }

    private static float listAreaGridSize
    {
        get
        {
            var projectWindow = GetProjectWindow();

            var projectWindowType = projectWindow.GetType();
            var propertyInfo = projectWindowType.GetProperty("listAreaGridSize", BindingFlags.Instance | BindingFlags.Public);
            return (float)propertyInfo.GetValue(projectWindow, null);
        }
    }

    /// <summary>
    /// there's a chance here we get the wrong one when two project windows are open
    /// </summary>
    private static EditorWindow GetProjectWindow()
    {
        if (EditorWindow.focusedWindow != null && EditorWindow.focusedWindow.titleContent.text == "Project")
        {
            return EditorWindow.focusedWindow;
        }

        return GetExistingWindowByName("Project");
    }

    private static EditorWindow GetExistingWindowByName(string name)
    {
        EditorWindow[] windows = Resources.FindObjectsOfTypeAll<EditorWindow>();
        foreach (var item in windows)
        {
            if (item.titleContent.text == name)
            {
                return item;
            }
        }

        return default(EditorWindow);
    }

    // ================================================================================
    //  utilities
    // --------------------------------------------------------------------------------

    private static Rect Translate(this Rect rect, Vector2 delta)
    {
        rect.x += delta.x;
        rect.y += delta.y;

        return rect;
    }

    private static bool IsDirectory(UnityEngine.Object obj)
    {
        if (obj == null)
        {
            return false;
        }

        return obj is DefaultAsset && !AssetDatabase.IsForeignAsset(obj);
    }
}