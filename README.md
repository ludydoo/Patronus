# Patronus

N-Dimensional matrix operations

# Usage

```
// Empty matrix
var matrix = Patronus.Matrix();

// Create a 1 dimension matrix from data
var matrix = Patronus.From(1, 2, 3, 4, 5, ..., n);

// Create a 3x3 shaped matrix
var matrix = Patronus.Matrix(3, 3, 3)

// Create a 2x2 matrix from data
var matrix = Patronus.From(1, 2, 3, 4).Reshape(2, 2);
var matrix = Patronus.Matrix(2, 2, new int[]{1, 2, 3, 4);
```