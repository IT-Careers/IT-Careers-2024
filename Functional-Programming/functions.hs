import Data.List
abstractFunc a b func = func a b

func1 a b = a + b
func2 a b = show(a) ++ show(b)
func3 a b = show(a) ++ " -> " ++ show(b)



absList list = map customAbs list

customAbs a = 
    if a < 0 
        then (a * (-1)) 
    else a


-- (a) => 1 + a

plus1List list = map (1 + ) list

plus1 a = a + 1

isEven num = num `mod` 2 == 0
findEven = filter isEven


customSum list = foldl (+) 0 list

funcSubtract res a = res - a


subtractList list = foldl funcSubtract 0 list



funcSubtractRight a res = a - res
subtractListRight list = foldr funcSubtractRight 0 list 


funcResult a b = show(a) ++ " -> " ++ show(b)


funcResult2 a b c = a * b * c + 10


maxElementList list = foldl customMax (minBound :: Int) list

maxElementListBuildIn list =  maximum list

maxElementListBuildInSort list = last (sort list)

customMax a b = 
    if a >= b 
        then a 
    else b


anonSum = (\ a b -> a + b)

zipSumElements firstList secondList = zipWith anonSum firstList secondList