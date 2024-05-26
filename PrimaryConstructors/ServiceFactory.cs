namespace PrimaryConstructors;

class ServiceFactory
{
    private WeakReference<DependencyFactory>? _dependencyFactoryRef;

    public T CreateService<T>(Func<DependencyFactory, T> fn)
    {
        if (_dependencyFactoryRef != null)
            throw new InvalidOperationException("CreateService cannot be used more than once.");

        var dependencyFactory = new DependencyFactory();
        _dependencyFactoryRef = new WeakReference<DependencyFactory>(dependencyFactory);
        
        return fn(dependencyFactory);
    }

    public bool DependencyFactoryIsCollected()
    {
        if (_dependencyFactoryRef == null)
            throw new InvalidOperationException("Must use CreateService first.");
        
        return _dependencyFactoryRef.TryGetTarget(out _) is false;
    }
}