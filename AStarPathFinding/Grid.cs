using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] bool canDrawGizmos = true;
    [SerializeField] Vector2 GridWorldSize;
    [SerializeField] LayerMask obstacleMask;

    [SerializeField] float fNodeRadius = 0.25f;
    [SerializeField] float fDistanceBetweenNodes;

    Node[,] NodeArray;
    public List<Node> FinalPath;

    float fNodeDiameter;
    int iGridSizeX, iGridSizeY;

    private void Start()
    {
        fNodeDiameter = fNodeRadius * 2;
        iGridSizeX = Mathf.RoundToInt(GridWorldSize.x / fNodeDiameter);
        iGridSizeY = Mathf.RoundToInt(GridWorldSize.y / fNodeDiameter);
        CreateGrid();
    }

    void CreateGrid()
    {
        NodeArray = new Node[iGridSizeX, iGridSizeY];
        Vector3 bottomLeft = transform.position - Vector3.right * GridWorldSize.x / 2 - Vector3.forward * GridWorldSize.y / 2;
        for (int x = 0; x < iGridSizeX; x++)
        {
            for (int y = 0; y < iGridSizeY; y++)
            {
                Vector3 worldPoint = bottomLeft + Vector3.right * (x * fNodeDiameter + fNodeRadius) + Vector3.forward * (y * fNodeDiameter + fNodeRadius);
                bool Wall = true;

                if (Physics.CheckSphere(worldPoint, fNodeRadius, obstacleMask))
                {
                    Wall = false;
                }

                NodeArray[x, y] = new Node(Wall, worldPoint, x, y);
            }
        }
    }
    public List<Node> GetNeighboringNodes(Node a_NeighborNode)
    {
        List<Node> NeighborList = new List<Node>();
        int icheckX, icheckY;

        icheckX = a_NeighborNode.iGridX + 1;
        icheckY = a_NeighborNode.iGridY;
        if (icheckX >= 0 && icheckX < iGridSizeX)
        {
            if (icheckY >= 0 && icheckY < iGridSizeY)
            {
                NeighborList.Add(NodeArray[icheckX, icheckY]);
            }
        }
        icheckX = a_NeighborNode.iGridX - 1;
        icheckY = a_NeighborNode.iGridY;
        if (icheckX >= 0 && icheckX < iGridSizeX)
        {
            if (icheckY >= 0 && icheckY < iGridSizeY)
            {
                NeighborList.Add(NodeArray[icheckX, icheckY]);
            }
        }
        icheckX = a_NeighborNode.iGridX;
        icheckY = a_NeighborNode.iGridY + 1;
        if (icheckX >= 0 && icheckX < iGridSizeX)
        {
            if (icheckY >= 0 && icheckY < iGridSizeY)
            {
                NeighborList.Add(NodeArray[icheckX, icheckY]);
            }
        }
        icheckX = a_NeighborNode.iGridX;
        icheckY = a_NeighborNode.iGridY - 1;
        if (icheckX >= 0 && icheckX < iGridSizeX)
        {
            if (icheckY >= 0 && icheckY < iGridSizeY)
            {
                NeighborList.Add(NodeArray[icheckX, icheckY]);
            }
        }

        return NeighborList;
    }
    public Node NodeFromWorldPoint(Vector3 a_vWorldPos)
    {
        float ixPos = ((a_vWorldPos.x + GridWorldSize.x / 2) / GridWorldSize.x);
        float iyPos = ((a_vWorldPos.z + GridWorldSize.y / 2) / GridWorldSize.y);

        ixPos = Mathf.Clamp01(ixPos);
        iyPos = Mathf.Clamp01(iyPos);

        int ix = Mathf.RoundToInt((iGridSizeX - 1) * ixPos);
        int iy = Mathf.RoundToInt((iGridSizeY - 1) * iyPos);

        return NodeArray[ix, iy];
    }

    private void OnDrawGizmos()
    {
        if (canDrawGizmos)
        {
            Gizmos.DrawCube(transform.position, new Vector3(GridWorldSize.x, 1, GridWorldSize.y));

            if (NodeArray != null)
            {
                foreach (Node n in NodeArray)
                {
                    if (n.bIsWall)
                    {
                        Gizmos.color = Color.cyan;
                    }
                    else
                    {
                        Gizmos.color = Color.yellow;
                    }

                    if (FinalPath != null)
                    {
                        if (FinalPath.Contains(n))
                        {
                            Gizmos.color = Color.red;
                        }
                    }
                    Gizmos.DrawCube(n.vPosition, new Vector3(1, 0.01f, 1) * (fNodeDiameter - fDistanceBetweenNodes));
                }
            }
        }
    }
}
