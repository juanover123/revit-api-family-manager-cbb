
namespace cbb.res
{
    using System.Reflection;
    /// <summary>
    /// Resource assembly helper methods
    /// </summary>

    public static class ResourceAssembly
    {
        #region public methods

        /// <summary>
        /// Gets the current resource assembly (assembly containing the resources).
        /// </summary>
        /// <returns>The assembly.</returns>
        public static Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }

        /// <summary>
        /// Gets the namespace of the currently running resource assembly.
        /// </summary>
        /// <returns>The namespace.</returns>
        public static string GetNameSpace()
        {
            return typeof(ResourceAssembly).Namespace + ".";
        }

        #endregion
    }
}
