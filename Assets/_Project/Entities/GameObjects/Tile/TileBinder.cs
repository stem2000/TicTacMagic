using System.Collections.Generic;
using UnityEngine;

namespace TicTacMagic
{
    public class TileBinder : MonoBehaviour
    {
        public List<Tile> tiles;

        private void OnValidate()
        {
            if (tiles != null)
                BindTiles();
        }

        private void BindTiles()
        {
            foreach (var tile in tiles)
            {
                BindDefinedNeighbours(tile);
                BindAllNeighbours(tile);
            }
        }

        private void BindDefinedNeighbours(Tile tile)
        {
            tile.up = FindClosestByDirection(tile, Vector2.up);
            tile.down = FindClosestByDirection(tile, Vector2.down);
            tile.left = FindClosestByDirection(tile, Vector2.left);
            tile.right = FindClosestByDirection(tile, Vector2.right);
        }

        private Tile FindClosestByDirection(Tile tile, Vector2 direction)
        {
            Tile rTile = null;

            foreach (var fTile in tiles)
            {
                if(tile == fTile) 
                    continue;

                var fTilePos = fTile.GetPosition();
                var tilePos = tile.GetPosition();

                if (Vector2.Angle(fTilePos - tilePos, direction) == 0)
                {
                    if (rTile == null) rTile = fTile;
                    else
                    {
                        if ((fTilePos - tilePos).magnitude < (rTile.GetPosition() - tilePos).magnitude)
                            rTile = fTile;
                    }
                }
            }

            return rTile;
        }

        private void BindAllNeighbours(Tile tile)
        {
            List<Tile> rTiles = new List<Tile>();

            tile.neighbours.Clear();

            rTiles.Add(tile.left);
            rTiles.Add(tile.right);
            rTiles.Add(tile.up);
            rTiles.Add(tile.down);

            if (tile.right != null)
            {
                if(!rTiles.Contains(tile.right.up))
                    rTiles.Add(tile.right.up);
                if (!rTiles.Contains(tile.right.down))
                    rTiles.Add(tile.right.down);
            }

            if (tile.up != null)
            {
                if (!rTiles.Contains(tile.up.right))
                    rTiles.Add(tile.up.right);
                if (!rTiles.Contains(tile.up.left))
                    rTiles.Add(tile.up.left);
            }

            if (tile.down != null)
            {
                if (!rTiles.Contains(tile.down.right))
                    rTiles.Add(tile.down.right);
                if (!rTiles.Contains(tile.down.left))
                    rTiles.Add(tile.down.left);
            }

            if (tile.left != null)
            {
                if (!rTiles.Contains(tile.left.up))
                    rTiles.Add(tile.left.up);
                if (!rTiles.Contains(tile.left.down))
                    rTiles.Add(tile.left.down);
            }

            foreach(var fTile in rTiles)
            {
                if(fTile != null)
                    tile.neighbours.Add(fTile);
            }
        }
    }
}
