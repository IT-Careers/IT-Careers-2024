module Utilities.MathUtilities where

isOdd a = a `mod` 2 == 1
isEven a = not $ isOdd a

isPrimeInternal n i = 
    if i == 1
        then True
    else 
        if n `mod` i == 0
            then False
        else isPrimeInternal n (i - 1)

isPrime 1 = False
isPrime n = isPrimeInternal n (toInteger (floor (sqrt (realToFrac n))))