import HelperFunctions

getFirstValueFrom2Tuple (a,_) = a
getSecondValueFrom2Tuple (_,a) = a

-- customZipWith func firstList secondList = 
--     if null (customTail firstList) || null (customTail secondList)
--         then [func (customHead firstList) (customHead secondList)]
--     else [func (customHead firstList) (customHead secondList)] ++ customZipWith func (customTail firstList) (customTail secondList)

customZipWith func firstList secondList = 
    if null firstList || null secondList
        then []
    else [func (getFirstValueFrom2Tuple (customHead (zip firstList secondList))) (getSecondValueFrom2Tuple (customHead (zip firstList secondList)))] ++ customZipWith func (customTail firstList) (customTail secondList)


brokenZipper firstList secondList = zipWith (\a b -> if a < 0 || b < 0 then 0 else a + b) firstList secondList

main = do
    print $ brokenZipper [23, -6, 48, 54, 12, -5] [15, -3, 55, 3, -4, 6]

