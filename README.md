# Zapper_Interview

**save-settings**

Parameters:

settingData = Data to be stored

key = Identifier to be stored ( user => userid, settings=> settingKey)

type = Identifier if one is storing user settings or general settings

User Example:

settingData = 00000011

key = user1342

type = user

Settings Example:

settingData = WhatsApp Notifications Enabled

key = 9

type = settings


------------------------------------------------------------------------------------------------------------------

**get-settings**


Parameters:

type = Identifier if one is storing user settings or general settings

Example:

type = user "gets user file" / settings "gets settings file "
