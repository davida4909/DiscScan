using System.Diagnostics;
using System.IO;

namespace DiscScan
{
    public class DiscScanner
    {
        public DiscScanner() 
        { 
        }
        /// <summary>
        /// Scan all File Sytem Objects in the current path
        /// </summary>
        /// <param name="path"></param>
        public void ScanDirectory(string path)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                Debug.WriteLine(directoryInfo.FullName);

                // Files
                FileInfo[] files = directoryInfo.GetFiles();
                foreach (FileInfo file in files)
                {
                    // action
                    Debug.WriteLine(file.FullName);
                }

                // Folders
                DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
                foreach (DirectoryInfo subDirectory in subDirectories) 
                {
                    ScanSubDirectory(subDirectory);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void ScanSubDirectory(DirectoryInfo directory)
        {
            try
            {
                Debug.WriteLine(directory.FullName);

                // Files
                FileInfo[] files = directory.GetFiles();
                foreach (FileInfo file in files)
                {
                    // action
                    Debug.WriteLine(file.FullName);
                }

                // Folders
                DirectoryInfo[] subDirectories = directory.GetDirectories();
                foreach (DirectoryInfo subDirectory in subDirectories)
                {
                    //Debug.WriteLine(subDirectory.FullName);
                    ScanSubDirectory(subDirectory);
                }
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }
        }

        public void SyncDirectory(string sourcePath, string destPath)
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(sourcePath);
                Debug.WriteLine(directoryInfo.FullName);

                // Files
                FileInfo[] files = directoryInfo.GetFiles();
                foreach (FileInfo file in files)
                {
                    // action
                    Debug.WriteLine(file.FullName);
                    if (File.Exists(Path.Combine(destPath, file.Name)))
                    {
                        // check last mod times
                    }
                    else
                    {
                        File.Copy(file.FullName, Path.Combine(destPath, file.Name), true);
                    }
                }

                // Folders
                DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
                foreach (DirectoryInfo subDirectory in subDirectories)
                {
                    SyncSubDirectory(subDirectory, Path.Combine(destPath, subDirectory.Name)); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void SyncSubDirectory(DirectoryInfo directory, string destPath)
        {
            try
            {
                Debug.WriteLine(directory.FullName);

                if (!Directory.Exists(destPath))
                {
                    Directory.CreateDirectory(destPath);
                }

                // Files
                FileInfo[] files = directory.GetFiles();
                foreach (FileInfo file in files)
                {
                    // action
                    Debug.WriteLine(file.FullName);
                    if (File.Exists(Path.Combine(destPath, file.Name)))
                    {
                        // check last mod times
                    }
                    else
                    {
                        File.Copy(file.FullName, Path.Combine(destPath, file.Name), true);
                    }
                }

                // Folders
                DirectoryInfo[] subDirectories = directory.GetDirectories();
                foreach (DirectoryInfo subDirectory in subDirectories)
                {
                    Debug.WriteLine(subDirectory.FullName);
                    SyncSubDirectory(subDirectory, Path.Combine(destPath, subDirectory.Name));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
