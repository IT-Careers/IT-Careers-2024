module GeneratorUtilities where

import MathUtilities

primeNumbers' i = 
    if isPrime i
        then i : primeNumbers' (i + 1)
    else primeNumbers' (i + 1)

primeNumbers = 2 : primeNumbers' 3

enumerate start end =
    if start > end
        then []
    else start : enumerate (start + 1) end

enumerate' end = enumerate 0 end

fibonacci' prePrevious previous = (prePrevious + previous) : fibonacci' previous (prePrevious + previous)
fibonacci = [1, 1] ++ fibonacci' 1 1