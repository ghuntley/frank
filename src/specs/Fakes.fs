﻿namespace Frack.Specs
module Fakes =
  open System
  open System.Collections.Specialized
  open System.IO
  open System.Text
  open System.Web

  let url = new Uri("http://wizardsofsmart.net/something/awesome?name=test&why=how")
    
  let mutable queryString = new NameValueCollection()
  queryString.Add("name","test")
  queryString.Add("why","how")
    
  let mutable headers = new NameValueCollection()
  headers.Add("HTTP_TEST", "value")
  
  let context =
    { new HttpContextBase() with
        override this.Request =
          { new HttpRequestBase() with
              override this.HttpMethod = "GET"
              override this.Url = url
              override this.QueryString = queryString
              override this.Headers = headers
              override this.ContentType = "text/html"
              override this.ContentLength = 5 
              override this.InputStream = new MemoryStream(Encoding.UTF8.GetBytes("Howdy")) :> Stream } }