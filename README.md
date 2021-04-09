# ECS
An incomplete ECS framework written in C#. Authored in 2016. 

The framework contains functionality for creating entities and components as well as managing them in groups but the functionality to facilitate systems hasn't been fleshed out. That being said, the framework is functional if you'd like to use it, it'll just require a little more elbow grease than was planned when I first wrote it. The idea is that systems will be easy to create once you can derive from the base Systems class to get all applicable entities/components required for each specific system. As it stands, you will have to collect all of those yourself using activeEntities and the component managers. I am going to work on it slowly when I have time, I just happened to find this source on an old harddrive and wanted to go ahead and throw it on github. Enjoy!

## Use

### Entities and Components

First, we want to create a new EntityManager, which is our method of keeping track of all active entities.
```
EntityManager entityManager = new EntityManager();
```

Next, you'll have to create an Entity. Entity is a class that contains nothing but an ID field. It is used for components to keep reference to the Entity in the global lists.
```
Entity entity = entityManager.createEntity("MyEntity");
```

From here, you can add Components. I'm using two previously created components, SomeComponent and AnotherComponent. SomeComponent contains a `public string stuff = "Hello World!";` and AnotherComponent is empty. A 
new instance of the component will be created and added to a global list of components for easy tracking.
```
entityManager.addComponent<SomeComponent>(entity.id);
entityManager.addComponent<AnotherComponent>(entity.id);
```

Now, we can access and modify the components we just added.
```
Console.WriteLine(entityManager.getComponent<SomeComponent>(entity.id).stuff);
```
Or
```
entityManager.getComponent<SomeComponent>(entity.id).stuff = "Goodbye World!";
```

# WIP - Using Systems

To create a system, create a class that inherits EntitySystem.
```
public class TestSystem : EntitySystem
```

Then declare your constructor:
```
public TestSystem(EntityManager entityHandler) :
    base(entityHandler, new Type[] {
        typeof(SomeComponent) })
 ```

