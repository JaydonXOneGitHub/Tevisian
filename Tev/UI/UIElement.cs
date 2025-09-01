#pragma warning disable IDE0130
#pragma warning disable IDE0031

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Tev.UI;

public class UIElement
{
    public Vector2 Offset { get; set; }

    private UIElement parent;
    private readonly UITreeService tree;

    private readonly List<UIElement> children;
    private readonly List<UIElement> addQueue;
    private readonly List<UIElement> removeQueue;

    public Vector2 GlobalOffset { get; private set; }





    public UIElement(UITreeService tree)
    {
        children = [];
        addQueue = [];
        removeQueue = [];
        this.tree = tree;
    }

    public virtual void OnAddedToTree() { }
    public virtual void OnRemovedFromTree() { }


    protected virtual void InternalUpdate(GameTime gameTime)
    {

    }

    protected virtual void InternalDraw(GameTime gameTime)
    {

    }

    public void Update(GameTime gameTime)
    {
        ProcessQueue();

        if (parent != null)
        {
            GlobalOffset = Offset + parent.GlobalOffset;
        }
        else
        {
            GlobalOffset = Offset;
        }

        foreach (var child in children)
        {
            child.Update(gameTime);
        }

        InternalUpdate(gameTime);
    }

    public void Draw(GameTime gameTime)
    {
        foreach (var child in children)
        {
            child.Draw(gameTime);
        }

        InternalDraw(gameTime);
    }


    public void AddChild(UIElement child)
    {
        if (child.parent != null)
        {
            Console.WriteLine("Element already has parent!");
            return;
        }

        children.Add(child);

        child.parent = this;

        child.OnAddedToTree();
    }

    public void RemoveChild(UIElement child)
    {
        if (child.parent != this)
        {
            Console.WriteLine("Element's parent is NOT ME!");
            return;
        }

        children.Remove(child);

        child.parent = null;

        child.OnRemovedFromTree();
    }

    public UIElement GetParent() => parent;

    public UITreeService GetTree() => tree;

    public void SetParent(UIElement other)
    {
        if (children.Contains(other) || this == other)
        {
            Console.WriteLine("Cannot set parent to child or self!");
            return;
        }

        if (parent != null)
        {
            parent.RemoveChild(this);
        }

        parent = other;

        if (parent != null)
        {
            parent.AddChild(this);
        }
    }

    private void ProcessQueue()
    {
        foreach (var toRemove in removeQueue)
        {
            RemoveChild(toRemove);
        }

        foreach (var toAdd in addQueue)
        {
            AddChild(toAdd);
        }

        if (addQueue.Count > 0)
        {
            addQueue.Clear();
        }
        
        if (removeQueue.Count > 0)
        {
            removeQueue.Clear();
        }
    }
    
    public void DeferredAddChild(UIElement child)
    {
        if (child.parent != null)
        {
            Console.WriteLine("Element already has parent!");
            return;
        }

        addQueue.Add(child);
    }

    public void DeferredRemoveChild(UIElement child)
    {
        if (child.parent != this)
        {
            Console.WriteLine("Element's parent is NOT ME!");
            return;
        }

        removeQueue.Add(child);
    }
}