# ECS
This is a fast and easy ECS framework for use in both game and business application.

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
