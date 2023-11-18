module Utilities.ListUtilities where

customHead arr = arr!!0

customTail arr = drop 1 arr

customFindMinInternal arr min = 
    if null arr
        then min
    else 
        if (customHead arr) < min
            then customFindMinInternal (customTail arr) (customHead arr)
        else customFindMinInternal (customTail arr) min

customFindMin arr = customFindMinInternal (customTail arr) (customHead arr)

customFindMaxInternal arr min = 
    if null arr
        then min
    else 
        if (customHead arr) > min
            then customFindMaxInternal (customTail arr) (customHead arr)
        else customFindMaxInternal (customTail arr) min

customFindMax arr = customFindMaxInternal (customTail arr) (customHead arr)

customMap list mapper = 
    if null list
        then []
    else mapper (customHead list) : customMap (customTail list) mapper

customFilter list filtrator = 
    if null list
        then []
    else if (filtrator (customHead list))
        then customHead list : customFilter (customTail list) filtrator
    else customFilter (customTail list) filtrator

customReduce list reducer aggregator = 
    if null list
        then aggregator
    else customReduce (customTail list) reducer (reducer aggregator (customHead list))

customReduceRight list reducer aggregator = 
    if null list
        then aggregator
    else reducer (customHead list) (customReduceRight (customTail list) reducer aggregator)

customLengthInternal list i =
    if null list
        then i
    else customLengthInternal (customTail list) (i + 1)

customLength list = customLengthInternal list 0

customIndexOfInternal list elem index = 
    if null list
        then -1
    else 
        if (customHead list) == elem
            then index
        else customIndexOfInternal (customTail list) elem index + 1 

customIndexOf list elem = customIndexOfInternal list elem 0

customSortMerge [] secondPartition comparator = secondPartition
customSortMerge firstPartition [] comparator = firstPartition
customSortMerge firstPartition secondPartition comparator =
    if (comparator (customHead firstPartition) (customHead secondPartition) <= 0)
        then [(customHead firstPartition)] ++ customSortMerge (customTail firstPartition) secondPartition comparator
    else [(customHead secondPartition)] ++ customSortMerge firstPartition (customTail secondPartition) comparator
    
customSort [] comparator = []
customSort [a] comparator = [a]
customSort list comparator = 
    customSortMerge
        (customSort (take ((length list) `div` 2) list) comparator) 
        (customSort (drop ((length list) `div` 2) list) comparator)
        comparator

customReverse list =
    if null list
        then []
    else (customReverse (customTail list)) ++ [customHead list] 

customGetElementOnIndexInternal list index i = 
    if i == index
        then customHead list
    else customGetElementOnIndexInternal (customTail list) index (i + 1)
customGetElementOnIndex list index = customGetElementOnIndexInternal list index 0

customJoin arr delimiter = 
    if null arr
        then ""
    else 
        if null (customTail arr)
            then (show $ customHead arr)
        else (show $ customHead arr) ++ delimiter ++ customJoin (customTail arr) delimiter