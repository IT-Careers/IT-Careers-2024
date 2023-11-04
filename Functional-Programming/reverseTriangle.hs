import HelperFunctions

reverseTriangle n = do
    if n == 0
        then return()
    else do
        putStrLn (repeatString "*" n)
        reverseTriangle (n - 1)
        putStrLn (repeatString "#" n)

main = do
    a <- getLine
    let n = read a :: Int
    reverseTriangle n