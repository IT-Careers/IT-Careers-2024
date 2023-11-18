module ExamPrep.MostValuedCustomer where

import Utilities.StringUtilities
import Utilities.ListUtilities

getFirstValueOf2Tuple (a, _) = a
getSecondValueOf2Tuple (_, a) = a

getFirstValueOf3Tuple (a, _, _) = a
getSecondValueOf3Tuple (_, a, _) = a
getThirdValueOf3Tuple (_, _, a) = a

containsPerson people personName = 
    not $ null $ filter (\x -> getFirstValueOf3Tuple x == personName) people

containsProduct products product = 
    not $ null $ filter (\x -> getFirstValueOf2Tuple x == product) products

getExistingProducts products personProducts =
    filter (\personProduct -> containsProduct products personProduct) personProducts

addNewProducts people products personName personProducts = 
    if null people
        then []
    else 
        if getFirstValueOf3Tuple (customHead people) == personName
            then [
                (personName, 
                getSecondValueOf3Tuple (customHead people) ++ personProducts, 
                (getThirdValueOf3Tuple (customHead people) + calculateTotalPrice (getProductsByProductNames products personProducts)))] 
                ++ addNewProducts (customTail people) products personName personProducts
        else [customHead people] ++ addNewProducts (customTail people) products personName personProducts

discountProducts products = 
    map (\x -> (getFirstValueOf2Tuple x, ((getSecondValueOf2Tuple x) * 9) `div` 10)) products

getProductsByProductNames products productNames = 
    filter (\x -> not $ null $ filter (\productName -> productName == getFirstValueOf2Tuple x) productNames) products

calculateTotalPrice products  = 
    foldl (\a e -> a + getSecondValueOf2Tuple e) 0 products 

readUntilPrint people products = do
    input <- getLine
    if input == "Print"
        then do 
            print people
    else do
        if input == "Discount"
            then do
                readUntilPrint people (discountProducts products)
        else do
            let params = splitString input ": "
            let personName = params!!0
            let personProducts = splitString (params!!1) ", "

            let existingProducts = getExistingProducts products personProducts

            if containsPerson people personName
                then do
                    readUntilPrint (addNewProducts people products personName personProducts) products
            else do 
                readUntilPrint (people ++ [(personName, existingProducts, calculateTotalPrice (getProductsByProductNames products existingProducts))]) products

readUntilShopIsOpen products = do
    input <- getLine
    if input == "Shop is open"
        then do 
           readUntilPrint [] products
    else do
        let params = splitString input " "
        let productName = params!!0
        let productPrice = read (params!!1) :: Int

        readUntilShopIsOpen (products ++ [(productName, productPrice)])

mostValuedCustomer = do
    readUntilShopIsOpen []