using UnityEngine;
using UnityEditor;

public class BlockColourManager : EditorWindow {

    public static Sprite SuperHardBlock;
    public static Sprite HardBlock;
    public static Sprite MediumBlock;
	public static Sprite WeakBlock;

    [MenuItem("Window/Block Color Setter")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(BlockColourManager));
    }

    void OnGUI()
    {
        GUILayout.Label("Set Sprites", EditorStyles.boldLabel);
        EditorGUILayout.BeginHorizontal();
        SuperHardBlock = EditorGUILayout.ObjectField(SuperHardBlock, typeof(Sprite), true);
        EditorGUILayout.EndHorizontal();
    }
}
