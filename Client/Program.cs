using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

using var httpClient = new HttpClient();
await using var requestContentStream = new MemoryStream();
await JsonSerializer.SerializeAsync( requestContentStream, new CreateFoo( "" ) );
requestContentStream.Seek( 0, SeekOrigin.Begin );
using var httpRequest = new HttpRequestMessage( HttpMethod.Put, "http://localhost:5000/Foo" )
{
    Content = new StreamContent( requestContentStream )
};
httpRequest.Content.Headers.ContentType = new( "application/json" );
httpRequest.Content.Headers.Add( "api-version", "1.0" );
using var response = await httpClient.SendAsync( httpRequest, HttpCompletionOption.ResponseHeadersRead );
if ( !response.IsSuccessStatusCode )
{
    var rawJson = await response.Content.ReadAsStringAsync();
    var validationProblemDetails = JsonSerializer.Deserialize<ValidationProblemDetails>( rawJson );
}

Console.WriteLine( "Done..." );
Console.ReadLine();

public record CreateFoo( String Name );

/*

{
    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
    "title": "One or more validation errors occurred.",
    "status": 400,
    "traceId": "00-84075aa65ec81f409bc74a3af930ea5c-f846f3a15024794e-00",
    "errors": {
        "Name": ["The Name field is required."]
    }
}

 */