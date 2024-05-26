namespace PrimaryConstructors;

public class Test
{
    private readonly ServiceFactory _serviceFactory = new();

    [Fact]
    public void RegularConstructor_DependencyFactoryIsCollected()
    {
        var service = _serviceFactory.CreateService(factory => new ServiceWithRegularConstructor(factory));
        
        GC.Collect();
        
        Assert.True(_serviceFactory.DependencyFactoryIsCollected());
    }

    [Fact]
    public void PrimaryConstructor_DependencyFactoryIsCollected()
    {
        var service = _serviceFactory.CreateService(factory => new ServiceWithPrimaryConstructor(factory));
        
        GC.Collect();
        
        Assert.True(_serviceFactory.DependencyFactoryIsCollected());
    }
    
    [Fact]
    public void RegularConstructorWithCaptureAndRelease_DependencyFactoryIsCollected()
    {
        var service = _serviceFactory.CreateService(factory => new ServiceWithRegularConstructorAndCapture(factory));

        Assert.True(service.HasDependencyFactory());
        GC.Collect();
        Assert.False(_serviceFactory.DependencyFactoryIsCollected());
        
        service.RemoveReferenceToFactory();

        Assert.False(service.HasDependencyFactory());
        GC.Collect();
        Assert.True(_serviceFactory.DependencyFactoryIsCollected());
    }
    
    [Fact]
    public void PrimaryConstructorWithCaptureAndRelease_DependencyFactoryIsCollected()
    {
        var service = _serviceFactory.CreateService(factory => new ServiceWithPrimaryConstructorAndCapture(factory));
        
        Assert.True(service.HasDependencyFactory());
        GC.Collect();
        Assert.False(_serviceFactory.DependencyFactoryIsCollected());
        
        service.RemoveReferenceToFactory();

        Assert.False(service.HasDependencyFactory());
        GC.Collect();
        Assert.True(_serviceFactory.DependencyFactoryIsCollected());
    }
}