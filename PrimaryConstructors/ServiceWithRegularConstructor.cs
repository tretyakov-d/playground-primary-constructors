namespace PrimaryConstructors;

class ServiceWithRegularConstructor
{
    public readonly Dependency Dependency;

    public ServiceWithRegularConstructor(DependencyFactory dependencyFactory)
    {
        Dependency = dependencyFactory.CreateDependency();
    }
}