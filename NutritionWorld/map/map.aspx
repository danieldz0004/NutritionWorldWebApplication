<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="map.aspx.cs" Inherits="NutritionWorld.Views.Home.map.map" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="initial-scale=1,maximum-scale=1,user-scalable=no" />
    <script type="text/javascript" src="jquery-3.2.1.js"></script>
	<script src="mapbox-gl.js"></script>
	<link href="mapbox-gl.css" rel="stylesheet" />
	<script src="mapbox-gl-directions.js"></script>
	<link rel="stylesheet" href="mapbox-gl-directions.css" type="text/css" />
    <style>
        body { margin:0; padding:0; }
        #map { position:absolute; top:0; bottom:0; width:100%; }
        .marker {
            display: block;
            border: none;
            border-radius: 50%;
            cursor: pointer;
            padding: 0;
            background-repeat: no-repeat;
            background-size: 100% 100%;
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="map"></div>
    </form>
    <script>
        var geojson = {
            "features": [
                { "properties": { "message": "MrRice", "iconSize": [50, 50], "img": 1 }, "geometry": { "coordinates": [144.98583, -37.81306] } },
                { "properties": { "message": "Houcaller", "iconSize": [50, 50], "img": 2 }, "geometry": { "coordinates": [144.97181, -37.80934] } },
                { "properties": { "message": "PIZZA4U", "iconSize": [50, 50], "img": 3 }, "geometry": { "coordinates": [144.97169, -37.81074] } },
                { "properties": { "message": "FanSalad", "iconSize": [50, 50], "img": 4 }, "geometry": { "coordinates": [144.97007, -37.81057] } },
                { "properties": { "message": "ACESeafood", "iconSize": [50, 50], "img": 5 }, "geometry": { "coordinates": [144.94293, -37.81417] } },
                { "properties": { "message": "ONE", "iconSize": [50, 50], "img": 6 }, "geometry": { "coordinates": [144.98413, -37.81610] } }
            ]
        };
        window.onload = function () {
            mapboxgl.accessToken = "pk.eyJ1IjoibTI1NzQyMjQ5MzEiLCJhIjoiY2ptMWVuam1oMGt3eDNwb2JpM2xnbHNwZyJ9.hJPlwiaXcgiaAPS5QhHPWA";
            var map = new mapboxgl.Map({
                container: "map",
                style: "mapbox://styles/mapbox/streets-v9",
                center: [144.96, -37.81],
                zoom: 13
            });

            map.addControl(new MapboxDirections({ accessToken: mapboxgl.accessToken }), "top-left");
            map.addControl(new mapboxgl.NavigationControl());

            geojson.features.forEach(function (marker) {
                if (marker.properties.message == '<%=GetName%>') {
                    var el = document.createElement('div');
                    el.className = 'marker';
                    el.style.backgroundImage = 'url(\'/Content/Photo/' + marker.properties.img + '.jpg\')';
                    el.style.width = marker.properties.iconSize[0] + 'px';
                    el.style.height = marker.properties.iconSize[1] + 'px';

                    el.addEventListener('click', function () {
                        window.alert(marker.properties.message);
                    });

                    new mapboxgl.Marker(el)
                        .setLngLat(marker.geometry.coordinates)
                        .addTo(map);
                }
            });
        }
    </script>
</body>
</html>
