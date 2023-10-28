module HelperFunctions where

customHead arr = take 1 arr

customTail arr = drop 1 arr

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

splitString str delimiter = 
    if null str
        then []
    else 
        if (take (length delimiter) str) == delimiter
            then (splitString (drop (length delimiter) str) delimiter)
        else [(customHead str)] ++ (splitString (customTail str) delimiter)