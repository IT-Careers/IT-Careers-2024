accFunc :: String -> Int -> String
accFunc res elem = "(" ++ res ++ "+" ++ show (elem) ++ ")"

mathExpr :: [Int] -> String
mathExpr list = do
  if length list == 0
    then ""
    else foldl accFunc (show (head list)) (tail list)

secondAccFunc elem res = "(" ++ show (elem) ++ "+" ++ res ++ ")"

secondMathExpr list = do
  if null list
    then ""
    else foldr secondAccFunc (show (last list)) (init list)

contains elem list = do
  if null list
    then False
    else do
      let listElem = head list
      if listElem == elem
        then True
        else contains elem (tail list)

distinctAcc res elem =
  if (contains elem res)
    then res
    else res ++ elem : []

distinctListElements list = foldl distinctAcc [] list

duplicateElements list res = do
  if null list
    then res
    else do
      let elem = last list
      let newRes = elem : elem : res
      duplicateElements (init list) newRes

duplicateElementsInList list = duplicateElements list []

duplicateNTimes n list res = do
  if null list
    then res
    else do
      let elem = last list
      let newRes = take n (repeat elem) ++ res
      duplicateNTimes n (init list) newRes

nTimesElementsInList list n = duplicateNTimes n list []

takeSubList i list startIndex endIndex = do
  if i == startIndex
    then do
      let elementsCount = endIndex - startIndex + 1
      take elementsCount list
    else takeSubList (i + 1) (tail list) startIndex endIndex

subList list startIndex endIndex =
  if null list
    then []
    else takeSubList 0 list startIndex endIndex