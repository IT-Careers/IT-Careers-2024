import HelperFunctions

main = do
    a <- getLine
    let n = read a :: Int
    print $ customSum (take n primeNumbers)
    
