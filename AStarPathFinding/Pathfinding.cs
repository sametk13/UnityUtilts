using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform TargetPosition;

    [SerializeField] float drawLineThickness = 5;
    [SerializeField] bool canDrawLine = true;
    Grid GridReference;

    private void Awake()
    {
        GridReference = GetComponent<Grid>();
    }

    private void Update()
    {
        FindPath(player.position, TargetPosition.position);
        if (GridReference.FinalPath != null && GridReference.FinalPath.Count > 0)
        {
            player.position = Vector3.MoveTowards(player.position, GridReference.FinalPath[0].vPosition, 1f * Time.deltaTime);
        }
        else
        {
            Debug.Log("Completed path");
        }
    }
    void FindPath(Vector3 a_StartPos, Vector3 a_TargetPos)
    {
        Node StartNode = GridReference.NodeFromWorldPoint(a_StartPos);
        Node TargetNode = GridReference.NodeFromWorldPoint(a_TargetPos);

        List<Node> OpenList = new List<Node>();
        HashSet<Node> ClosedList = new HashSet<Node>();

        OpenList.Add(StartNode);

        while (OpenList.Count > 0)
        {
            Node CurrentNode = OpenList[0];
            for (int i = 1; i < OpenList.Count; i++)
            {
                if (OpenList[i].FCost < CurrentNode.FCost || OpenList[i].FCost == CurrentNode.FCost && OpenList[i].ihCost < CurrentNode.ihCost)
                {
                    CurrentNode = OpenList[i];
                }
            }
            OpenList.Remove(CurrentNode);
            ClosedList.Add(CurrentNode);

            if (CurrentNode == TargetNode)
            {
                GetFinalPath(StartNode, TargetNode);
            }

            foreach (Node NeighborNode in GridReference.GetNeighboringNodes(CurrentNode))
            {
                if (!NeighborNode.bIsWall || ClosedList.Contains(NeighborNode))
                {
                    continue;//Skip it
                }
                int MoveCost = CurrentNode.igCost + GetManhattenDistance(CurrentNode, NeighborNode);

                if (MoveCost < NeighborNode.igCost || !OpenList.Contains(NeighborNode))
                {
                    NeighborNode.igCost = MoveCost;
                    NeighborNode.ihCost = GetManhattenDistance(NeighborNode, TargetNode);
                    NeighborNode.ParentNode = CurrentNode;

                    if (!OpenList.Contains(NeighborNode))
                    {
                        OpenList.Add(NeighborNode);
                    }
                }
            }

        }
    }

    void GetFinalPath(Node a_StartingNode, Node a_EndNode)
    {
        List<Node> FinalPath = new List<Node>();
        Node CurrentNode = a_EndNode;

        while (CurrentNode != a_StartingNode)
        {
            FinalPath.Add(CurrentNode);
            CurrentNode = CurrentNode.ParentNode;
        }
        FinalPath.Reverse();
        GridReference.FinalPath = FinalPath;
    }

    int GetManhattenDistance(Node a_nodeA, Node a_nodeB)
    {
        int ix = Mathf.Abs(a_nodeA.iGridX - a_nodeB.iGridX);
        int iy = Mathf.Abs(a_nodeA.iGridY - a_nodeB.iGridY);

        return ix + iy;
    }

    private void OnDrawGizmos()
    {
        if (canDrawLine && GridReference != null && GridReference.FinalPath != null && GridReference.FinalPath.Count > 0)
        {
            for (int i = 1; i < GridReference.FinalPath.Count; i++)
            {
                var p1 = GridReference.FinalPath[i - 1].vPosition;
                var p2 = GridReference.FinalPath[i].vPosition;
                Handles.DrawBezier(p1, p2, p1, p2, Color.green, null, drawLineThickness);
            }
            var pos1 = player.position;
            var pos2 = GridReference.FinalPath[0].vPosition;
            Handles.DrawBezier(pos1, pos2, pos1, pos2, Color.red, null, drawLineThickness*1.5f);
        }
    }
}
