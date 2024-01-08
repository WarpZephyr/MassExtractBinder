using SoulsFormats;

namespace MassExtractBinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                foreach (var arg in args)
                {
                    if (Directory.Exists(arg))
                    {
                        Console.WriteLine($"Processing folder {arg}");
                        HandleFolder(arg);
                    }
                    else if (File.Exists(arg))
                    {
                        string outFolder = Path.Combine(PathHandler.GetFolder(arg), "mass-extracted");
                        PathHandler.EnsureFolderExists(outFolder);
                        HandleFile(outFolder, arg);
                    }
                }

                Console.WriteLine("Finished without errors.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Finished with an error.");
                Console.ReadLine();
            }
        }

        static void HandleFolder(string folder)
        {
            string outFolder = Path.Combine(folder, "mass-extracted");
            PathHandler.EnsureFolderExists(outFolder);

            var files = Directory.EnumerateFiles(folder, "*", SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                HandleFile(outFolder, file);
            }
        }

        static void HandleFile(string outFolder, string file)
        {
            if (BND3.IsRead(file, out BND3 bnd3))
            {
                Console.WriteLine($"Processing BND3 {Path.GetFileName(file)}");
                HandleBinder(outFolder, bnd3);
            }
            else if (BND4.IsRead(file, out BND4 bnd4))
            {
                Console.WriteLine($"Processing BND4 {Path.GetFileName(file)}");
                HandleBinder(outFolder, bnd4);
            }
        }

        static void HandleBinder(string outFolder, IBinder binder)
        {
            foreach (var file in binder.Files)
            {
                string outPath = Path.Combine(outFolder, file.Name ?? file.ID.ToString());
                PathHandler.EnsureOutPathExists(outPath);
                File.WriteAllBytes(outPath, file.Bytes);
            }
        }
    }
}
