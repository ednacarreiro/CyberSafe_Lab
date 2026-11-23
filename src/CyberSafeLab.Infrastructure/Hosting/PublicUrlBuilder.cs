using CyberSafeLab.Application.Abstractions;
namespace CyberSafeLab.Infrastructure.Hosting;
public sealed class PublicUrlBuilder : IUrlBuilder
{
 private readonly string _baseUrl;
 public PublicUrlBuilder()
 {
   var supplied = Environment.GetEnvironmentVariable("PUBLIC_BASE_URL");
   var port = Environment.GetEnvironmentVariable("PORT");
   if (!int.TryParse(port, out var p) || p is < 1 or > 65535) p = 3000;
   if (Uri.TryCreate(supplied, UriKind.Absolute, out var uri) &&
       uri.Scheme == Uri.UriSchemeHttps && string.IsNullOrWhiteSpace(uri.UserInfo) &&
       string.IsNullOrEmpty(uri.Query) && string.IsNullOrEmpty(uri.Fragment) && uri.AbsolutePath == "/")
     _baseUrl = uri.GetLeftPart(UriPartial.Authority);
   else _baseUrl = $"http://localhost:{p}";
 }
 public string Absolute(string path) => _baseUrl + path;
}
