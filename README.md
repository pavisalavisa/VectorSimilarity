# Similar_3D_Points
Finding similar points with O(n) complexity

Given array of n vectors each containing 3 components ( components ranging between 1 and 20) find similar vectors.
Vectors are considered similar if two out of three components are matching. (3,2,4) and (3,3,4) are similar but not
(3,2,2) and (4,3,2). 

Vectors have 3 components ( aka 3D points) and each of them is between 1-20. 

We make another array of vectors which now contain sums of three permutations of components( 12,13,23). 
To make sure sum 12 and 21 are different we multiply leading number by ten. If both 12 and 21 give the same sum 
it's not a problem because those are the same numbers then. 

Create new integer array which is going to store hash values our hash function produces. Idea is that every sum
combined with it's position in the vector ( that is every permutation) has got to yield different hash value.
If two sums yield the same hash value that means they were both the same permutation which means two out of 
three components of the vector are the same hence those vectors are similar.

Complexity of this algorithm is O(n) but we do use additional space for sum and hash table. We could've avoided
sum array had we inserted values into hashTable instantly but I believe that this increases clarity.

Note that nested for function is never going to be traversed more than 3 times so we can assume it's got 
constant complexity O(1).
