[![Build Status](https://travis-ci.org/ludydoo/Patronus.svg?branch=master)](https://travis-ci.org/ludydoo/Patronus)

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
var matrix = Patronus.Matrix(2, 2, new int[]{1, 2, 3, 4});
```

## Sequence

Creates a matrix with sequenced data

```
// Creates a 2x2 matrix starting from 1 to 8

var matrix = Patronus.Matrix(2, 2).Sequence(1).Print()
var matrix = Patronus.Sequence(1, 2, 2);

matrix.Print()

// Output
//
// ++++++++  
// + 1  2 +  
// + 3  4 +  
// ++++++++  


```

## Randomize

Creates a matrix with random data

```

// Creates a 2x2 matrix with random data between -5 and 5

var matrix = Patronus.Matrix(2, 2).Randomize(-5, 5).Print()
var matrix = Patronus.Random(-5, 5, 2, 2)

matrix.Print();

// Output
//
// ++++++++++  
// + -1   5 +  
// +  3   9 +  
// ++++++++++  


```

## Padding

Adds padding

```

var matrix = new Matrix(2, 2).Sequence(1).Pad(0)
var matrix = Patronus.Sequence(1, 2, 2).Pad(0)

matrix.Print();

// Output
//
// +++++++++++++++++++
// +  0   0   0   0  +
// +  0   1   2   0  +  
// +  0   3   4   0  +  
// +  0   0   0   0  +
// +++++++++++++++++++


```





