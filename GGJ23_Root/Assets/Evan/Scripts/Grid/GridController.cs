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
    public int cellScale = 1;
    public List<GridCell> boardCells = new List<GridCell>();
    public List<GameObject> boardCellMeshes = new List<GameObject>();
    public List<Vector3> pathCellPositions = new List<Vector3>();
    public GameObject gridCellMesh;
    public Transform gridCellMeshParent;

    public Material gridBase;
    public Material gridInvalid;
    public Material gridHighlight;


    private void Start() {
        GenerateGrid();
        
    }

    public void GenerateGrid() {
        //Find our path cells in scene and store their positions
        var pathCells = FindObjectsOfType<Transform>().Where(cell => cell.transform.CompareTag("Path")).ToList();
        foreach (var path in pathCells) {
            pathCellPositions.Add(new Vector3(path.position.x, 0, path.position.z));
            
            // var bleh = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            // bleh.transform.position = new Vector3(path.position.x, 0, path.position.z);
            
        }

        for (int x = 0; x < gridWidth; x += cellScale) {
            for (int z = 0; z < gridHeight; z += cellScale) {
                var cellPos = new Vector3((-gridWidth / 2 + x), 0, (-gridHeight / 2 + z));
                GridCell newCell = new GridCell((int)cellPos.x, (int)cellPos.z);
                boardCells.Add(newCell);

                newCell.canBeOccupied = false;
                
                var cellMesh = Instantiate(gridCellMesh, gridCellMeshParent);
                cellMesh.transform.localScale *= cellScale;
                cellMesh.transform.localPosition = new Vector3((int)cellPos.x, 0, (int)cellPos.z);
                cellMesh.GetComponent<MeshRenderer>().material = gridBase;
                boardCellMeshes.Add(cellMesh);
                cellMesh.SetActive(false);
            }
        }

        foreach (var pathTile in pathCells) {
            for (int x = -1; x < 2; x++) {
                for (int z = -1; z < 3; z++) {
                    Vector3 posToCheck = new Vector3(pathTile.position.x + (x * cellScale), 0, pathTile.position.z + (z * cellScale));
                    if (DoesCellExist((int)posToCheck.x, (int)posToCheck.z)) {
                        var cellData = GetCell((int)posToCheck.x, (int)posToCheck.z);

                        if (pathCellPositions.Contains(posToCheck)) {
                            continue;
                        }
                    
                        cellData.canBeOccupied = true;
                        GetCellMesh(cellData.x, cellData.z).SetActive(true);
                    }
                    
                }
            }
        }
        
        UpdateGridMesh();
    }

    public void Update() {
        // UpdateGridMesh();
    }

    public void UpdateGridMesh() {
        // Debug.Log("Updating Grid Mesh");
        foreach (var mesh in boardCellMeshes) {
            var cellData = GetCell((int) mesh.transform.position.x, (int) mesh.transform.position.z);
            if (cellData.isOccupied && mesh.activeSelf) {
                mesh.SetActive(false);
                // Debug.Log("X:" + cellData.x + " Z:" + cellData.z + " Changed to Disabled");
                continue;
            }

            var meshRend = mesh.GetComponent<MeshRenderer>();
            if (cellData.canBeOccupied && meshRend.materials[0] != gridBase) {
                meshRend.materials[0] = gridBase;
                // Debug.Log("X:" + cellData.x + " Z:" + cellData.z + " Changed to Base");
                continue;
            }
            
            if(!cellData.canBeOccupied && meshRend.material !=  gridInvalid) {
                meshRend.material = gridInvalid;
                meshRend.gameObject.SetActive(false);
                // Debug.Log("X:" + cellData.x + " Z:" + cellData.z + " Changed to Invalid");
            }
            
            //mesh.GetComponent<MeshRenderer>().material = cellData.canBeOccupied ? gridBase : gridInvalid;
            
        }
        // Debug.Log("Finished Updating Grid Mesh");
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

    public bool DoesCellExist(int x, int z) {
        foreach (var cell in boardCells) {
            if (cell.x == x && cell.z == z) {
                return true;
            }
        }
        return false;
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
