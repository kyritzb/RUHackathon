## Graph Generator (Bryan)
### Drawing the graph
The graph generator is an object that builds a three dimensional mesh from a multivariable calculus function. In order to create the mesh, we needed to derive vertices of points in the 3d space. We did this by performing the math formulas and getting a z for each point from -20 to 20 x and y. Once we got an array of vertices we needed to then draw the surface of this graph by connecting vertices with triangles and connecting them together. When all of these small triangles are woven together, a 3d mesh of the graph of the function is created. 

### The Calculus functions
In order to make the grapher more robust, we needed a way to enter custom functions from a user interface. To do this we created a standard calculator user interface and enabled it to build a function that will be passed onto the graph generation. This was especially challenging because we needed a way to convert a string into math operations and evaluate its result. This would have been a very hard task to accomplish but luckily we ran into http://mathparser.org/, which we were able to import into our project and utilize to evaluate the string version of the math formula. In order to generate graphs from more basic shapes, we created another user interface that contains 6 presets to basic graphs.

### Problems
There were many issues that we ran into while developing the grapher. First, the graph is unable to calculate implicit functions as the mesh would be rendered incorrectly. With more time, we may be able to determine the best ways to connect our vertices to create triangles and render them. Our work around for this hack was to separate the mesh into 8 different quadrants such as

<p align="center">
        (+x,+y,+z),(-x,+y,+z),(+x,-y,+z),(-x,+-y,+z),
        (+x,+y,-z),(-x,+y,-z),(+x,-y,-z),(-x,+-y,-z)
</p>
<p align="center">
  <img width="300" height="300" src="https://upload.wikimedia.org/wikipedia/commons/thumb/6/60/Octant_numbers.svg/220px-Octant_numbers.svg.png">
</p>

This allowed each quadrant to be its own, seperate part to prevent rendering issues as well as fixing the issues of drawing in quadrants where the function does not exist. The second issue we ran into was that the library we used to convert a string of a math function into an evaluable function, was very slow. This makes the user have to wait a long time for the graph to be calculated. We were unable to fix this issue, but for demoing purposes we decided to create preset functions that would bypass the math parser library and generate the graph fast.

### Preset Equations

| Function Name | Equation |
| --- | --- |
| x=y plane | z = x+y |
| cone | z = sqrt(x^2+y^2)|
|Hyperboloid one sheet | z = sqrt( ((x^2)/( a^2)) + ((y^2)/( b^2)) - -1|
|saddle | z= x^2-y^2 |
|wave | x^3 + sqrt(y) |
|dome | -x^2-y^2 |
