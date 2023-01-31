using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

using UnityEngine;
using UnityEngine.UIElements;

public class GridController : MonoBehaviour
{
    public static GridController instance;
    private void Awake() {
        instance = this;
    }


    public int gridWidth, gridHeight;
    public List<GridCell> boardCells = new List<GridCell>();
    public List<GameObject> boardCellMeshes = new List<GameObject>();
    public GameObject gridCellMesh;
    public Transform gridCellMeshParent;

    public Material gridBase;
    public Material gridInvalid;
    public Material gridHighlight;

    public Vector3[] pathCells; //Should be changed to something else but fuck it

    private void Start() {
        GenerateGrid();
        
    }

    public void GenerateGrid() {
        for (int x = 0; x < gridWidth; x++) {
            for (int z = 0; z < gridHeight; z++) {
                var cellPos = new Vector3(-gridWidth / 2 + x, 0, -gridHeight / 2 + z);
                GridCell newCell = new GridCell((int)cellPos.x, (int)cellPos.z);
                boardCells.Add(newCell);
                
                newCell.canBeOccupied = !pathCells.Contains(new Vector3((int) cellPos.x, 0, (int) cellPos.z));
                
                var cellMesh = Instantiate(gridCellMesh,gridCellMeshParent);
                cellMesh.transform.localPosition = new Vector3((int)cellPos.x, 0, (int)cellPos.z);
                cellMesh.GetComponent<MeshRenderer>().material = gridBase;
                boardCellMeshes.Add(cellMesh);
            }
        }
    }

    public void Update() {
        UpdateGridMesh();
    }

    public void UpdateGridMesh() {
        foreach (var mesh in boardCellMeshes) {
            var cellData = GetCell((int) mesh.transform.position.x, (int) mesh.transform.position.z);
            if (cellData.isOccupied) {
                mesh.SetActive(false);
            }

            mesh.GetComponent<MeshRenderer>().material = cellData.canBeOccupied ? gridBase : gridInvalid;
            
        }
    }

    private GameObject lastHighlightedCell;
    public void HighlightSingleCell(int x, int z) {
        if (lastHighlightedCell) {
            lastHighlightedCell.GetComponent<MeshRenderer>().material = gridBase;
        }
        var cellData = GetCell(x, z);
        if (!cellData.isOccupied && !cellData.canBeOccupied) {
            var cellMesh = GetCellMesh(x, z);
            cellMesh.GetComponent<MeshRenderer>().material = gridHighlight;
            lastHighlightedCell = cellMesh;
        }
    }

    public GridCell GetCell(int x, int z) {
        var matchedCells = boardCells.Where(cell => cell.x == x && cell.z == z).ToList();
        if (matchedCells.Count != 1) {
            Debug.Log("<color=red>NO CELL EXISTS AT (" + x + "," + z + ")</color>");
            return new GridCell(0, 0);
        }
        return matchedCells[0];
    }

    public GameObject GetCellMesh(int x, int z) {
        var matchedCellMeshes = boardCellMeshes.Where(cell => cell.transform.position.x == x && cell.transform.position.z == z).ToList();
        if (matchedCellMeshes.Count != 1) {
            Debug.Log("<color=red>NO CELL OR TOO MANY EXIST AT (" + x + "," + z + ")</color>");
            return null;
        }
        return matchedCellMeshes[0];
    }
}
