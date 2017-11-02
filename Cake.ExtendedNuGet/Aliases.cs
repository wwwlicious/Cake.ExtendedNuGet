using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
using NuGet.Versioning;

namespace Cake.ExtendedNuGet
{
    using NuGet.Packaging;
    

    /// <summary>
    /// Extended NuGet Aliases
    /// </summary>
    [CakeAliasCategory("NuGet")]
    public static class ExtendedNuGetAliases
    {
        /// <summary>
        /// Gets the Package Id from a .nupkg file
        /// </summary>
        /// <returns>The package Id.</returns>
        /// <param name="context">The context.</param>
        /// <param name="file">The .nupkg file to read.</param>
        [CakeMethodAlias]
        [CakeNamespaceImport("NuGet")]
        public static string GetNuGetPackageId (this ICakeContext context, FilePath file)
        {
            var f = file.MakeAbsolute(context.Environment).FullPath;

            using (var reader = new PackageArchiveReader(f))
            {
                return reader.NuspecReader.GetId();
            }
        }

        /// <summary>
        /// Gets the Package Version from a .nupkg file
        /// </summary>
        /// <returns>The package version.</returns>
        /// <param name="context">The context.</param>
        /// <param name="file">The .nupkg file to read.</param>
        [CakeMethodAlias]
        [CakeNamespaceImport("NuGet")]
        public static SemanticVersion GetNuGetPackageVersion (this ICakeContext context, FilePath file)
        {
            var f = file.MakeAbsolute (context.Environment).FullPath;
            using (var reader = new PackageArchiveReader(f))
            {
                return reader.NuspecReader.GetVersion();
            }
        }
    }
}
