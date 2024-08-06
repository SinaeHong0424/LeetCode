using System;
using System.Collections.Generic;

public class LRUCache
{
    private readonly int capacity;
    private readonly Dictionary<int, LinkedListNode<(int key, int value)>> cache;
    private readonly LinkedList<(int key, int value)> usageOrder;

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        cache = new Dictionary<int, LinkedListNode<(int key, int value)>>();
        usageOrder = new LinkedList<(int key, int value)>();
    }

    public int Get(int key)
    {
        if (!cache.ContainsKey(key))
        {
            return -1;
        }

        // Move the accessed item to the front of the usage order
        var node = cache[key];
        usageOrder.Remove(node);
        usageOrder.AddFirst(node);

        return node.Value.value;
    }

    public void Put(int key, int value)
    {
        if (cache.ContainsKey(key))
        {
            // Update the existing item's value and move it to the front of the usage order
            var node = cache[key];
            node.Value = (key, value);
            usageOrder.Remove(node);
            usageOrder.AddFirst(node);
        }
        else
        {
            if (cache.Count >= capacity)
            {
                // Remove the least recently used item from the cache and usage order
                var lruNode = usageOrder.Last;
                cache.Remove(lruNode.Value.key);
                usageOrder.RemoveLast();
            }

            // Add the new item to the cache and usage order
            var newNode = new LinkedListNode<(int key, int value)>((key, value));
            cache[key] = newNode;
            usageOrder.AddFirst(newNode);
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
