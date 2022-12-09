using UnityEngine;

namespace Managers
{
    public class CursorManager : MonoBehaviour
    {
        [SerializeField] private Texture2D cursorMira;

        private void Start()
        {
            Cursor.SetCursor(cursorMira, new Vector2(cursorMira.width / 2f, cursorMira.height / 2f),
                CursorMode.ForceSoftware);
        }
    }
}