namespace PrimaryConstructors;

class ServiceWithPrimaryConstructor(DependencyFactory dependencyFactory)
{
    public readonly Dependency Dependency = dependencyFactory.CreateDependency();
}