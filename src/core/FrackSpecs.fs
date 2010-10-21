﻿module FrackSpecs
open Frack
open NaturalSpec
open BaseSpecs

[<Scenario>]
let ``When running an app that just returns pre-defined values, those values should be returned.``() =
  let ``running an app with predefined values`` request =
    printMethod "200, type = text/plain and length = 5, Howdy"
    app.Invoke(request)
  let request = getUtility "GET"
  Given request
  |> When ``running an app with predefined values``
  |> It should equal ( 200, hdrs, body )
  |> Verify