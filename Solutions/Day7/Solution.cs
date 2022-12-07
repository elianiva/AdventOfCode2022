using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2022.Solutions.Day7;

internal record struct TreeFile(int Size, string Name);

internal sealed class TreeNode
{
    public string Name { get; }
    public List<TreeFile> Files { get; } = new();
    public List<TreeNode> Nodes { get; } = new();
    public TreeNode? ParentNode { get; set; } = null;
    public int FileSizeCount => Files.Sum(file => file.Size) + Nodes.Sum(node => node.FileSizeCount);


    public TreeNode(string nodeName, TreeNode? parentNode = null)
    {
        Name = nodeName;
        ParentNode = parentNode;
    }

    public TreeNode GetNode(string nodeName) => Nodes.Where(node => node.Name == nodeName).First();
}

internal class Solution
{
    private const int AVAILABLE_SPACE = 70_000_000;
    private const int MIN_UNUSED = 30_000_000;
    private const int MAX_FILE_SIZE = 100_000;

    public static void CollecValidNodes(TreeNode node, List<TreeNode> nodeSizes)
    {
        foreach (TreeNode childNode in node.Nodes)
        {
            if (childNode.FileSizeCount < MAX_FILE_SIZE)
            {
                nodeSizes.Add(childNode);
            }
            CollecValidNodes(childNode, nodeSizes);
        }
    }

    public static void GetSmallestFreedValue(TreeNode node, List<int> minValues, int usedSpace)
    {
        int nodeSize = node.FileSizeCount;
        int currentSize = usedSpace - nodeSize;
        if (AVAILABLE_SPACE - currentSize >= MIN_UNUSED)
        {
            minValues.Add(nodeSize);
        }

        foreach (TreeNode childNode in node.Nodes)
        {
            GetSmallestFreedValue(childNode, minValues, usedSpace);
        }
    }

    private static TreeNode BuildTree(IEnumerable<string> lines)
    {
        TreeNode root = new("/");

        TreeNode currentNode = root;
        foreach (string line in lines)
        {
            string[] lineSegments = line.Split(' ');

            // cd command
            if (lineSegments is ["$", "cd", string target])
            {
                currentNode = target switch
                {
                    "/" => root,
                    ".." => currentNode.ParentNode!,
                    string t => currentNode.GetNode(t),
                    _ => throw new Exception("INVALID"),
                };
            }

            // ls command
            if (lineSegments is ["$", "ls"])
            {
                continue;
            }

            // add dir
            if (lineSegments is ["dir", string dirName])
            {
                currentNode.Nodes.Add(new TreeNode(dirName, currentNode));
                continue;
            }

            // add file
            if (lineSegments is [string fileSizeStr, string fileName])
            {
                int fileSize = int.Parse(fileSizeStr);
                currentNode.Files.Add(new TreeFile(fileSize, fileName));
            }
        };

        return root;
    }

    public static int FirstPart(Stream lines)
    {
        TreeNode tree = BuildTree(lines.ToEnumerable());
        List<TreeNode> validNodes = new();
        CollecValidNodes(tree, validNodes);
        return validNodes.Sum(node => node.FileSizeCount);
    }

    public static int SecondPart(Stream lines)
    {
        TreeNode tree = BuildTree(lines.ToEnumerable());
        int usedSpace = tree.FileSizeCount;
        List<int> minValues = new();
        GetSmallestFreedValue(tree, minValues, usedSpace);
        return minValues.Min();
    }
}
