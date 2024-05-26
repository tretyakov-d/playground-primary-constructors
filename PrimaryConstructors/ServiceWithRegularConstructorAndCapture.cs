namespace PrimaryConstructors;

class ServiceWithRegularConstructorAndCapture
{
    private DependencyFactory? _dependencyFactory;

    public ServiceWithRegularConstructorAndCapture(DependencyFactory dependencyFactory)
    {
        _dependencyFactory = dependencyFactory;
    }

    public bool HasDependencyFactory() => _dependencyFactory != null;

    public void RemoveReferenceToFactory() => _dependencyFactory = null;
}