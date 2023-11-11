module HelperFunctions where

encloseRole role = (\name message -> "[" ++ role ++ "]" ++ name ++ " said: " ++ message)

main = do
    let role = "Admin"
    let sendAdminMessage = encloseRole role

    let adminName = "Pesho"
    let adminMessage = "Hi guys!"

    print $ sendAdminMessage adminName adminMessage
