module StringUtilities where

import ListUtilities

repeatString str n = 
    if n == 1
        then str
    else str ++ (repeatString str (n - 1))

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
