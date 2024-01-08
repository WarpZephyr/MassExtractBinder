namespace MassExtractBinder
{
    public static class PathHandler
    {
        public static void EnsureFolderExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static void EnsureOutPathExists(string path)
        {
            EnsureFolderExists(GetFolder(path));
        }

        public static string GetFolder(string path)
        {
            string? folder = Path.GetDirectoryName(path);
            if (string.IsNullOrEmpty(folder))
            {
                throw new InvalidOperationException($"Could not get the folder name of: {path}");
            }

            return folder;
        }
    }
}
