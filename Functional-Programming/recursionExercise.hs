-- exercise

findLogTwoFromN n = 
    if n < 1
        then -1
    else 1 + findLogTwoFromN (n / 2)

-- 15 -> 7 -> 3 -> 1
-- 15 / 2
-- 7 / 2
-- 3 / 2
-- 1 / 2

-- 4
-- 2

factorial n = 
    if n == 1
        then 1
    else n * factorial (n - 1)

findFactorial i n initalValue =
    if i == n
        then initalValue
    else findFactorial (i + 1) n (initalValue * (i + 1))

findFactorialUser n = findFactorial 0 n 1

fibonacci n = 
    if n == 0
        then 0
    else if n == 1
        then 1
    else fibonacci (n - 1) + fibonacci (n - 2)

fibonacciIter i n firstPrev secondPrev =
    if n == 0
        then 0
    else if n == 1 || n == 2
        then 1
    else if i == n
        then firstPrev + secondPrev
    else do 
        fibonacciIter (i + 1) n (firstPrev + secondPrev) firstPrev


fibonacciIterUser n = fibonacciIter 3 n 1 1
-- 5

-- 0 1 1 2 3 5 8

repeatString str count = 
    if count == 1
        then str
    else str ++ repeatString str (count - 1)

reversedTriangle n =
    if n == 0
        then return()
    else do
        print (repeatString "*" n)
        reversedTriangle (n - 1)