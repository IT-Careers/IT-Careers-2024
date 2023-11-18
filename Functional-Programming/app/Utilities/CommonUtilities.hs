module Utilities.CommonUtilities where
    
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