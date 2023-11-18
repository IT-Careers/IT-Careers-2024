module ExamPrep.Camping where

import Utilities.StringUtilities
import Utilities.ListUtilities

getFirstValueOfTuple (a, _, _) = a
getSecondValueOftuple (_, b, _) = b
getThirdValueOftuple (_, _, c) = c

addNewCamper people personName newCamper timeToStay = 
    if null people
        then []
    else 
        if getFirstValueOfTuple (customHead people) == personName
            then [(personName, (getSecondValueOftuple (customHead people) ++ [newCamper]), getThirdValueOftuple (customHead people) + timeToStay)] ++ addNewCamper (customTail people) personName newCamper timeToStay
        else [(customHead people)] ++ addNewCamper (customTail people) personName newCamper timeToStay

printCampers campers = 
    if null campers
        then return ()
    else do
        putStrLn $ "***" ++ (customHead campers)
        printCampers (customTail campers)

printPeople people = do
    if null people
        then return ()
    else do
        let currentPerson = customHead people
        putStrLn (getFirstValueOfTuple currentPerson ++ ": " ++ (show $ length (getSecondValueOftuple currentPerson)))
        printCampers (getSecondValueOftuple currentPerson)
        putStrLn ("Total stay: " ++ (show $ getThirdValueOftuple currentPerson) ++ " nights")
        printPeople (customTail people)

readUntilEnd people = do
    input <- getLine
    if input == "end"
        then do 
            let sortedByLengthOfName = customSort people (\x y -> (length (getFirstValueOfTuple x)) - (length (getFirstValueOfTuple y)))
            let sortedByNumberOfCampers = customSort sortedByLengthOfName (\x y -> (length (getSecondValueOftuple y)) - (length (getSecondValueOftuple x)))
            printPeople sortedByNumberOfCampers
    else do
        let params = splitString input " "
        let personName = params!!0
        let camperModel = params!!1
        let timeToStay = read (params!!2) :: Int

        if not $ null (filter (\x -> (getFirstValueOfTuple x) == personName) people)
            then do
                let existingPerson = customHead (filter (\x -> (getFirstValueOfTuple x) == personName) people)

                if null (filter (\x -> x == camperModel) (getSecondValueOftuple existingPerson))
                    then do 
                        readUntilEnd (addNewCamper people personName camperModel timeToStay)
                else do
                    readUntilEnd people
        else do
            readUntilEnd (people ++ [(personName, [camperModel], timeToStay)])

camping = do
    readUntilEnd []