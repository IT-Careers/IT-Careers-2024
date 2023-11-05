loop index endIndex =
    if index == endIndex
        then return()
    else do
        print index
        loop (index + 1) endIndex


repeatString repeatStr count = repeatStringInternal repeatStr count ""

repeatStringInternal repeatStr count result = 
    if count == 0
        then result
    else
        repeatStringInternal repeatStr (count - 1) (result ++ repeatStr)

-- "prefix -> testprefix -> testprefix -> testprefix -> testprefix -> test"

sumNNumbers n = sumInternal 1 n

sumInternal startNum n = 
    if startNum > n
        then 0
    else startNum + sumInternal (startNum + 1) n
