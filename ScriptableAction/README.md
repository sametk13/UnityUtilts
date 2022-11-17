# Why we need Scriptable Actions?

Regarding the fact that being able to Invoke an action through a scriptable object is allowing us to utilise actions in a flexible ways. 
Firstly, we are being able to create new actions through editor by using the scriptable objects, which is allowing us to bypass the extra code that would be needed to written.
However, that doesn't mean that we are forced to use the scriptable objects, we can also access the created actions with the code as well.
Overall, the flexibility that the system provides is basically not allowing us to fall into an action and event spaghetti.

# How To Use
1) Create a scriptable action using the project file system
2) Add scriptable action setter script to your object.
3) Add the desired function through the unity event on the scriptable action setter and assign the scriptable action
4) Now you can either call the scriptable object by defining it inside a script or you can use the Call Action method inside of the scriptable action itself on inspector.
