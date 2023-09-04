using System;
using System.Collections.Generic;
using Debug = UnityEngine.Debug;

public class ServiceProvider
{
    private static ServiceProvider _instance;
    public static ServiceProvider Container => _instance ?? (_instance = new ServiceProvider());

    private Dictionary<Type, IService> _services = new();
    
    public void Register<TService>(TService service) where TService : class, IService
    {
        if (_services.ContainsKey(service.GetType()))
        {
            Debug.LogWarning($"You are trying to register {service}. It have been already registered.");
            return;
        }

        _services.Add(service.GetType(), service);
    }

    public TService Single<TService>() where TService : class, IService
    {
        if (_services.TryGetValue(typeof(TService), out IService service))
            return (TService)service;

        Debug.LogError($"Requested service {typeof(TService)} not found");
        return null;
    }
}
