# Graph-Theory
A useful C# graph and vertex class along with implementations of algorithms for various problems.

## Vertex
The Vertex class stores the neighbors (vertices that it is connected to), the costs (the weights of the edges to the vertices that it is connected to), and a nickname (it would be smart to make sure every vertex has a unique nickname). There is an operator to determine if two vertices are the same.

## Graph
A graph can be created (only needs a nickname) but it only gets interesting when vertices are added. The Graph class stores a List<Vertex> that has every vertex that included in the Graph. There are several methods for getting these vertices but edges can only be retrieved using the Neighbor and Costs variables inside the Vertex class. 

## TSP
This contains a memory intensive algorithim for solving the Traveling Salesman problem.

## Program
The main method is here. 
