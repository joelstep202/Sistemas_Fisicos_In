using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class procedural : MonoBehaviour
{
    [SerializeField] private GameObject clonoriginal;
    [SerializeField] private int nivelesramas = 3;
    [SerializeField] private float initialSize = 4f;
    [SerializeField, Range(0f, 1f)] private float reductionPerLevel = 0.1f;
    Queue<GameObject> myQueue = new Queue<GameObject>();



    private int currentLevel = 1;

    void Start()
    {

        GameObject rootBranch = Instantiate(clonoriginal, transform);
        ChangeBranchSize(rootBranch, initialSize);
        myQueue.Enqueue(rootBranch);
        GenerateTree();

    }
    private void GenerateTree()
    {
        if (currentLevel >= nivelesramas)
        {
            return;
        }
        ++currentLevel;
        float newSize = Mathf.Max(initialSize - initialSize * reductionPerLevel * (currentLevel - 1), 0.1f);
        var branchesCreatedThisCycle = new List<GameObject>();
        while (myQueue.Count > 0)
        {
            var rootBranch = myQueue.Dequeue();

            var leftBranch = CreateBranch(rootBranch, Random.Range(5, 20));
            var rightBranch = CreateBranch(rootBranch, -Random.Range(5, 25));

            ChangeBranchSize(leftBranch, newSize);
            ChangeBranchSize(rightBranch, newSize);

            branchesCreatedThisCycle.Add(leftBranch);
            branchesCreatedThisCycle.Add(rightBranch);
        }

        Debug.Log(currentLevel);
        foreach (var newBranches in branchesCreatedThisCycle)
        {
            myQueue.Enqueue(newBranches);
        }

        GenerateTree();


    }
    private GameObject CreateBranch(GameObject prevBranch, float relativeAngle)
    {
        GameObject newBranch = Instantiate(clonoriginal, transform);
        newBranch.transform.localPosition = prevBranch.transform.localPosition + prevBranch.transform.up * GetBranchLength(prevBranch);
        newBranch.transform.localRotation = prevBranch.transform.localRotation * Quaternion.Euler(0, 0, relativeAngle);
        return newBranch;
    }
    private void ChangeBranchSize(GameObject branchInstance, float newSize)
    {
        var square = branchInstance.transform.GetChild(0);
        var circle = branchInstance.transform.GetChild(1);
        //update the scale of the square
        var newSquareScale = square.transform.localScale;
        newSquareScale.y = newSize;
        square.transform.localScale = newSquareScale;
        //update the position of the square
        var newSquarePosition = square.transform.localPosition;
        newSquarePosition.y = newSize / 2f;
        square.transform.localPosition = newSquarePosition;



        //update the position of circle
        var newCirclePosition = circle.transform.localPosition;
        newCirclePosition.y = newSize;
        circle.transform.localPosition = newCirclePosition;

    }
    private float GetBranchLength(GameObject branchInstance)
    {
        return branchInstance.transform.GetChild(0).localScale.y;
    }
}
