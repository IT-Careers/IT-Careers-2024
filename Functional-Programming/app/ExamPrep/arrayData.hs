import Utilities.ListUtilities
import Utilities.StringUtilities

customDumbRemoveElem list elem = 
    if null list
        then []
    else 
        if (customHead list) == elem
            then customTail list
        else [customHead list] ++ customDumbRemoveElem (customTail list) elem

customDumbSort list = 
    if null list
        then []
    else [customFindMin list] ++ customDumbSort (customDumbRemoveElem list (customFindMin list))

main = do
    numbers <- getLine
    command <- getLine
    
    let parsedNumbers = map (\x -> read x :: Int) (splitString numbers " ")
    let average = (foldl (\a e -> a + e) 0 parsedNumbers) `div` (length parsedNumbers) 
    let filteredNumbers = filter (\a -> a > average) parsedNumbers

    if command == "Min" 
        then do
            print $ customFindMin filteredNumbers
    else 
        if command == "Max"
            then do
                print $ customFindMax filteredNumbers
        else do
            print $ customJoin (customDumbSort filteredNumbers) " "
