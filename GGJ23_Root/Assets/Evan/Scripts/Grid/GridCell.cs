

using UnityEngine;
public class GridCell
{
    public int x, z;
    public bool isOccupied;
    public GameObject currentOwner;
    public bool canBeOccupied;

    public GridCell(int x, int z, bool isOccupied, GameObject currentOwner, bool canBeOccupied) {
        this.x = x;
        this.z = z;
        this.isOccupied = isOccupied;
        this.currentOwner = currentOwner;
        this.canBeOccupied = canBeOccupied;
    }

    public GridCell(int x, int z) {
        this.x = x;
        this.z = z;
    }
}
