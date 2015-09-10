# NinjectNamedScopesStrangeness
A test solution that shows unusual behavior with the NamedScope extension that boils down to the generic scoping mechanism in Ninject.

Demonstrates an issue our company had with Ninject scopes. When using ```DefinesNamedScope``` for a parent/high level object
and using ```InNamedScope``` for some contained/low level object (down several levels), don't forget to remove all singletons in between - you might have forgotten about them.
 
 In this solution ```IMainProcessor``` is configured with ```DefinesNamedScope```. ```IData``` is configured with ```InNamedScope```. ```ISecondaryProcessor``` is
 configured with ```InSingletonScope```. The first ```IMainProcessor``` instance works just fine and ```IData``` can be fetched repeatedly. Then a GC 
 run removes that instance and its scope. After that a second ```IMainProcessor``` is created with its own scope. A call to retrieve another
 ```IData``` instance fails because ```ISecondaryProcessor``` is still looking up to the parent ```IContext``` of the first ```IMainProcessor``` instance which
 has been disposed. Thus a ```ScopeDisposedException``` is thrown.

 The problem with Ninject scopes is, that a scope is just a key to a part of the Cache in Ninject and no metainformation is available
 that says, that one scope is enclosing/outliving the other scope in terms of lifespan. This makes it even possible to create an object that 
 creates a singleton that has the shortlived object's IContext as its parent context.
