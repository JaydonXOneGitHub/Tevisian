#pragma warning disable IDE0130
#pragma warning disable IDE0031

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MoonSharp.Interpreter;
using Tev.Core;

namespace Tev.UI;

public class UIElement
{
    [MoonSharpHidden]
    public Vector2 Offset { get; set; }

    public uint LayerDepth { get; set; } = 0;

    protected float internalLayerDepth = 0;

    private UIElement? parent;
    private readonly UITreeService tree;

    private readonly HashSet<UIElement> children;

    private readonly HashSet<Action> doQueue;

    [MoonSharpHidden]
    public Vector2 GlobalOffset { get; private set; }

    public const float LayerDepthDivider = 10000000;



    public UIElement(UITreeService tree)
    {
        children = [];
        doQueue = [];
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

    [MoonSharpHidden]
    public HashSet<Action> GetDoQueue() => doQueue;

    [MoonSharpHidden]
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

        internalLayerDepth = ((float)LayerDepth / LayerDepthDivider);

        foreach (var child in children)
        {
            child.Update(gameTime);
        }

        InternalUpdate(gameTime);
    }

    [MoonSharpHidden]
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

    public UIElement? GetParent() => parent;

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
        foreach (var action in doQueue)
        {
            action?.Invoke();
        }

        doQueue.Clear();
    }

    public void DeferredAddChild(UIElement child)
    {
        if (child.parent != null)
        {
            Console.WriteLine("Element already has parent!");
            return;
        }

        doQueue.Add(() => AddChild(child));
    }

    public void DoDeferred(Action queuedAction)
        => doQueue.Add(queuedAction);

    public void DeferredRemoveChild(UIElement child)
    {
        if (child.parent != this)
        {
            Console.WriteLine("Element's parent is NOT ME!");
            return;
        }

        doQueue.Add(() => RemoveChild(child));
    }

    [MoonSharpHidden]
    public HashSet<UIElement> GetChildren() => children;
}