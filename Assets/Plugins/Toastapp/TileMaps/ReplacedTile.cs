using System.Collections.Generic;
using UnityEngine.Tilemaps;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityEngine
{
    [Serializable]
    [CreateAssetMenu(fileName = "New Replaced Tile", menuName = "Tiles/Replaced Tile")]
    public class ReplacedTile : Tile
    {

        public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
        {
#if UNITY_EDITOR
            if (EditorApplication.isPlaying)
            {
                this.color = new Color(0, 0, 0, 0);
            }
            else
            {
                this.color = Color.white;
            }
#else
            this.color = new Color(0, 0, 0, 0);
#endif
            return base.StartUp(position, tilemap, go);
        }
    }
}
