# Graph-Theory
A useful C# graph and vertex class along with implementations of algorithms for various problems.

## Vertex
The Vertex class stores the neighbors (vertices that it is connected to), the costs (the weights of the edges to the vertices that it is connected to), and a nickname (it would be smart to make sure every vertex has a unique nickname). There is an operator to determine if two vertices are the same. Each vertex also requires coordinates but if you do not need coordinates, set the x and y position to 0 and it will work well.

## Graph
A graph can be created (only needs a nickname) but it only gets interesting when vertices are added. The Graph class stores a List<Vertex> that has every vertex that included in the Graph. There are several methods for getting these vertices but edges can only be retrieved using the Neighbor and Costs variables inside the Vertex class. Also contains an overloaded + operator

## TSP
This folder contains heuristic algorithims for solving the Traveling Salesman problems including a brute force alorithim and an algorithim of own design

### Brute Force
Do *not* try using this with more than 10 cities. The PermuteItems<> method is very inefficient and the system thorws an OutOfMemoryException(); when trying with more than 11 cities.

### Arun's algorithim
Follows the following steps: 
* Put the cities on a coordinate grid
* Separate into upper and lower halves based on the median y-coordinate
* Create the paths through each half by starting at the leftmost city then going to the next leftmost city
* Join the leftmost and rightmost cities in the higher and lower paths to get a cycle

## Program
The main method is here. Currently containes a list of 65 cities as vertices to try these algorithims with
