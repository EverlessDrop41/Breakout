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

        GUILayout.Label("Super Hard Block", EditorStyles.label);
        SuperHardBlock =  EditorGUILayout.ObjectField(SuperHardBlock,typeof(Sprite), false) as Sprite;
        GUILayout.Label("Hard Block", EditorStyles.label);
        HardBlock = EditorGUILayout.ObjectField(HardBlock, typeof(Sprite), false) as Sprite;
        GUILayout.Label("Medium Block", EditorStyles.label);
        MediumBlock = EditorGUILayout.ObjectField(MediumBlock, typeof(Sprite), false) as Sprite;
        GUILayout.Label("Weak Block", EditorStyles.label);
        WeakBlock = EditorGUILayout.ObjectField(WeakBlock, typeof(Sprite), false) as Sprite;
    }
}
