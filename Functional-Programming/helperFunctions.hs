module HelperFunctions where
    
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

customLengthInternal list i =
    if null list
        then i
    else customLengthInternal (customTail list) (i + 1)

customLength list = customLengthInternal list 0
customReverse list =
    if null list
        then []
    else (customReverse (customTail list)) ++ [customHead list] 

customGetElementOnIndexInternal list index i = 
    if i == index
        then customHead list
    else customGetElementOnIndexInternal (customTail list) index (i + 1)
customGetElementOnIndex list index = customGetElementOnIndexInternal list index 0

customSum list = 
    if null list
        then 0
    else (customHead list) + customSum (customTail list)


repeatString str n = 
    if n == 1
        then str
    else str ++ (repeatString str (n - 1))

loop loopData condition actualization body = do
    if not (condition loopData)
        then return()
    else do 
        body loopData
        loop (actualization loopData) condition actualization body

readUntil command execution = do
    input <- getLine
    if input == command
        then return () 
    else readUntil command execution

enumerate start end =
    if start > end
        then []
    else start : enumerate (start + 1) end

enumerate' end = enumerate 0 end

fibonacci' prePrevious previous = (prePrevious + previous) : fibonacci' previous (prePrevious + previous)
fibonacci = [1, 1] ++ fibonacci' 1 1

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

primeNumbers' i = 
    if isPrime i
        then i : primeNumbers' (i + 1)
    else primeNumbers' (i + 1)

primeNumbers = 2 : primeNumbers' 3

stringIndexOfInternal str subStr index = 
    if null str
        then -1
    else 
        if take (length subStr) str == subStr
            then index
        else stringIndexOfInternal (customTail str) subStr (index + 1)

stringIndexOf str subStr = stringIndexOfInternal str subStr 0

splitString str delimiter =
    if stringIndexOf str delimiter == -1
        then [str]
    else [take (stringIndexOf str delimiter) str] ++ splitString (drop ((stringIndexOf str delimiter) + (length delimiter)) str) delimiter

customJoin arr delimiter = 
    if null arr
        then ""
    else 
        if null (customTail arr)
            then (show $ customHead arr)
        else (show $ customHead arr) ++ delimiter ++ customJoin (customTail arr) delimiter