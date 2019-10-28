using UnityEditor;
using System.Diagnostics;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine;

//[InitializeOnLoad, ExecuteInEditMode]
public class EditorLogMenu : EditorWindow
{
    private static readonly string _folder = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Unity\Editor");

    private static readonly string _fileName = Path.Combine(_folder, "Editor.log");

    [MenuItem("Tools/Open Editor Log", false, 0)]
    private static void OpenEditorLog()
    {
        Process.Start(_fileName);
    }

    [MenuItem("Tools/Open App Data Editor Folder", false, 20)]
    private static void OpenEditorFolder()
    {
        Process.Start(_folder);
    }


    // Add a menu item called "Random Color" to a Image's context menu.
    [MenuItem("CONTEXT/Image/Random Color")]
    static void RandomColor(MenuCommand command)
    {
        Image image = (Image)command.context;
        image.color = new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
    }
    // Add a menu item called "White Color" to a Image's context menu.
    [MenuItem("CONTEXT/Image/White Color")]
    static void WhiteColor(MenuCommand command)
    {
        Image image = (Image)command.context;
        image.color = new Color(1, 1, 1, 1);
    }
    [MenuItem("Tools/Clear PlayerPrefs")]
    private static void NewMenuOption()
    {
        PlayerPrefs.DeleteAll();
    }



}