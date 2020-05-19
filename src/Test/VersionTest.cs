using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using FluentAssertions;
using Xunit;

namespace Test
{
    
    public class VersionTest
    {
        [Fact]
        public void CheckProjectVersions()
        {
            var directory = new DirectoryInfo(Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),"..", "..", "..", "..")));

            var csprojFiles = directory.GetFiles("SafeT*.csproj", SearchOption.AllDirectories);

            List<(string,string)> versions = new List<(string, string)>();
            List<(string,string, string)> references = new List<(string, string, string)>();

            foreach (var csprojFile in csprojFiles)
            {
                XDocument doc = XDocument.Load(csprojFile.FullName);
                var packageId = doc.Descendants("PackageId").Single().Value;
                versions.Add((packageId,doc.Descendants("Version").Single().Value));
                var packageRefs = doc.Descendants("PackageReference")
                    .Where(o => o.Attribute("Include")?.Value.StartsWith("SafeT") ?? false);

                references.AddRange(packageRefs.Select(o=> (packageId, o.Attribute("Include")?.Value, o.Attribute("Version")?.Value)));
            }

            var max = versions.Select(o => new Version(o.Item2)).Max().ToString();

            foreach (var version in versions)
            {
                version.Item2.Should().Be(max, "", version);
            }

            foreach (var reference in references)
            {
                reference.Item3.Should().Be(max, "", reference);

            }
        }
    }
}
