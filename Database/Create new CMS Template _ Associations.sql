/* 
	Uncomment all code below and run once.
	SQL to double-check your work is included but will be commented
	by default.
*/

---- TEST
--USE CISOregon_Test

--DECLARE @CMSTemplateTypeLookupID INT = (
--		SELECT lt.LookupTypeID
--		FROM LookupType lt
--		WHERE lt.NAME = 'CMSTemplateType'
--		)
--DECLARE @CMSSiteLookupID_BENEFITS INT = (
--		SELECT l.LookupID
--		FROM [lookup] l
--		JOIN LookupType lt ON l.LookupTypeID = lt.LookupTypeID
--		WHERE lt.NAME = 'CMSSite'
--			AND l.LookupName = 'Benefits'
--		)

--SELECT @CMSTemplateTypeLookupID [CMS Template Type LookupID Used]
--	,@CMSSiteLookupID_BENEFITS [CMS Site LookupID for Benefits Used]

---- Insert new CMSTemplateType
--INSERT INTO [Lookup] (
--	LookupTypeID
--	,LookupName
--	,LookupDescription
--	)
--VALUES (
--	@CMSTemplateTypeLookupID
--	,'AccountFlyerTemplate'
--	,'AccountFlyerTemplate'
--	)

--DECLARE @NewCMSTemplateTypeID INT = (
--		SELECT SCOPE_IDENTITY()
--		)

--SELECT @NewCMSTemplateTypeID [New CMS TemplateTypeID being used for site association]

---- Insert new CMSSiteTemplateType
--INSERT INTO CMSSiteTemplateType (
--	CMSSiteLookupID
--	,CMSTemplateTypeLookupID
--	)
--VALUES (
--	@CMSSiteLookupID_BENEFITS
--	,@NewCMSTemplateTypeID
--	)

---- Optionally doublecheck your work:
----SELECT l.*
----	,lt.*
----FROM [lookup] l
----JOIN LookupType lt ON l.LookupTypeID = lt.LookupTypeID
----WHERE lt.NAME IN (
----		'CMSTemplateType'
----		,'CMSSite'
----		)

----SELECT *
----FROM CMSSiteTemplateType

---- PRODUCTION
--USE CISOregon

--DECLARE @CMSTemplateTypeLookupID INT = (
--		SELECT lt.LookupTypeID
--		FROM LookupType lt
--		WHERE lt.NAME = 'CMSTemplateType'
--		)
--DECLARE @CMSSiteLookupID_BENEFITS INT = (
--		SELECT l.LookupID
--		FROM [lookup] l
--		JOIN LookupType lt ON l.LookupTypeID = lt.LookupTypeID
--		WHERE lt.NAME = 'CMSSite'
--			AND l.LookupName = 'Benefits'
--		)

--SELECT @CMSTemplateTypeLookupID [CMS Template Type LookupID Used]
--	,@CMSSiteLookupID_BENEFITS [CMS Site LookupID for Benefits Used]

---- Insert new CMSTemplateType
--INSERT INTO [Lookup] (
--	LookupTypeID
--	,LookupName
--	,LookupDescription
--	)
--VALUES (
--	@CMSTemplateTypeLookupID
--	,'AccountFlyerTemplate'
--	,'AccountFlyerTemplate'
--	)

--DECLARE @NewCMSTemplateTypeID INT = (
--		SELECT SCOPE_IDENTITY()
--		)

--SELECT @NewCMSTemplateTypeID [New CMS TemplateTypeID being used for site association]

---- Insert new CMSSiteTemplateType
--INSERT INTO CMSSiteTemplateType (
--	CMSSiteLookupID
--	,CMSTemplateTypeLookupID
--	)
--VALUES (
--	@CMSSiteLookupID_BENEFITS
--	,@NewCMSTemplateTypeID
--	)

---- Optionally doublecheck your work:
----SELECT l.*
----	,lt.*
----FROM [lookup] l
----JOIN LookupType lt ON l.LookupTypeID = lt.LookupTypeID
----WHERE lt.NAME IN (
----		'CMSTemplateType'
----		,'CMSSite'
----		)

----SELECT *
----FROM CMSSiteTemplateType