
	SELECT 
		1 as tag
		,Null as parent
		,ls.LocationSiteId AS [location!1!locationsiteid!ELEMENT]
		,ls.LocationSiteName AS [location!1!locationSiteName!ELEMENT] 
		,null AS [scene!2!sceneid!ELEMENT]
		,null AS [scene!2!titleId!ELEMENT]

	FROM LocationSites  ls
	
	UNION ALL
	SELECT 
	 2 
	,1 
	,s.LocationSiteId
	,null
	,s.SceneId
	,s.TitleId
	FROM
	LocationSites  ls
	JOIN Scenes s ON
	ls.LocationSiteId = s.LocationSiteId
	ORDER BY 3,1 

	--SELECT 
	--	 2 as tag
	--	,1 as parent
	--	,null
	--	,null		
	--	,m.TitleId
	--	,m.Title
	
	--FROM  dbo.vw_MoviesScenesLocationSites  m
	--JOIN  dbo.vw_MoviesScenesLocationSites  lm
	--ON lm.LocationSiteId =m.LocationSiteId
	
	
	--) as TmpTable
	--order by tag,[location!1!locationid!ELEMENT], [movie!2!title!ELEMENT]
	for xml explicit ;
	--)
	--select @WebSiteXmlData = '<?xml version="1.0" encoding="UTF-8" ?><doc>' + cast(@x as nvarchar(max)) + '</doc>'
	--select @WebSiteXmlData as LocationMovies
	--END 
	--GO

--	SELECT
--    LocationSiteId, LocationSiteName ,
--    (SELECT    SceneId, TitleId FROM Scenes WHERE Scenes.LocationSiteId = 
--      LocationSites.LocationSiteId FOR XML AUTO, TYPE, ELEMENTS) 
--      AS LocationSecnes
--FROM
--    LocationSites
--FOR XML AUTO, ELEMENTS