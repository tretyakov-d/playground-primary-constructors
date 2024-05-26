namespace PrimaryConstructors;

class Dependency {}

class DependencyFactory
{
    public Dependency CreateDependency() => new();
}