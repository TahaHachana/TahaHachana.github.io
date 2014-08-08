module HtmlApp.Location

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html
open IntelliFactory.WebSharper.Google.Maps

[<JavaScript>]
module Client =

    let Main () =
        Div [Attr.Id "map"]
        |>! OnAfterRender (fun elt ->
            let center = LatLng(36.8615875, 10.1947133)
            let options = MapOptions(center, 15)
            let map = Google.Maps.Map(elt.Dom, options)
            let markerOptions = MarkerOptions(center)
            markerOptions.Map <- map
            markerOptions.Title <- "Click me"
            let marker = Marker(markerOptions)
            let infoOptions = InfoWindowOptions()
            infoOptions.Content <- """<div><img class="thumbnail" src="Chipmonk.jpeg" alt="Picture" id="chipmonk" /></div><div class="caption"><h4>I'm somewhere around here.</h4></div>"""
            let iw = InfoWindow(infoOptions)
            iw.Open(map, marker))

[<Sealed>]
type Control() =
    inherit Web.Control()

    [<JavaScript>]
    override __.Body =
        Client.Main() :> _
