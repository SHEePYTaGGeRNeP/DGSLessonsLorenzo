using UnityEditor;
using UnityEngine;

namespace Assets.Editor.Scripts
{
    class Colorizer : EditorWindow
    {
        private Color color;

        [MenuItem("Tools/Open Colorizer Window")]
        public static void ShowWindow()
        {
            EditorWindow window = GetWindow<Colorizer>();
            window.position = new Rect(Screen.width / 2, Screen.height / 2, 350, 200);
            window.minSize = new Vector2(350, 200);
            window.Show();
        }

        private void OnGUI()
        {
            color = EditorGUILayout.ColorField("Color", color);
            if (GUILayout.Button("Colorize!"))
                Colorize();
        }

        private void Colorize()
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                Renderer renderer = obj.GetComponent<Renderer>();
                if (renderer != null)
                    renderer.sharedMaterial.color = color;
            }
        }
    }
}
