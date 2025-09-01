using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Tev.Services;

public sealed class ServiceManager
{
    private readonly Dictionary<Type, TevisianService> services;

    public ServiceManager()
    {
        services = [];
    }

    public T Register<T>() where T : TevisianService, new()
    {
        if (!services.ContainsKey(typeof(T)))
        {
            T t = new();

            services[typeof(T)] = t;

            return t;
        }

        return null;
    }

    public T GetService<T>() where T : TevisianService
    {
        if (services.TryGetValue(typeof(T), out TevisianService tService))
        {
            return tService as T;
        }
        return null;
    }

    public void Initialize()
    {
        foreach (var service in services.Values)
        {
            service.Initialize();
        }
    }

    public void Shutdown()
    {
        foreach (var service in services.Values)
        {
            service.Shutdown();
        }
    }

    public void Draw(GameTime gameTime)
    {
        foreach (var service in services.Values)
        {
            service.Draw(gameTime);
        }
    }

    public void Update(GameTime gameTime)
    {
        foreach (var service in services.Values)
        {
            service.Update(gameTime);
        }
    }
}