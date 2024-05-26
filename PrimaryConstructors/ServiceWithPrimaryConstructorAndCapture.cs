namespace PrimaryConstructors;

class ServiceWithPrimaryConstructorAndCapture(DependencyFactory dependencyFactory)
{
    public bool HasDependencyFactory() => dependencyFactory != null;

    public void RemoveReferenceToFactory() => dependencyFactory = null;
}