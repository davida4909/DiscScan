using System.Diagnostics;
using System.IO;

namespace DiscScan
{
    public class DiscScanner
    {
        const string op_eq = "=";
        const string op_add = "+";
        const string op_upd = ">";

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
        /// <summary>
        /// Sync Directory
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destPath"></param>
        public void SyncDirectory(string sourcePath, string destPath)
        {
            try
            {
                string destFile;
                Log log = new Log();
                DirectoryInfo directoryInfo = new DirectoryInfo(sourcePath);
                //Debug.WriteLine(directoryInfo.FullName);
                log.Logit(op_upd, sourcePath, destPath);

                // Files
                FileInfo[] files = directoryInfo.GetFiles();
                foreach (FileInfo file in files)
                {
                    // action
                    //Debug.WriteLine(file.FullName);
                    destFile = Path.Combine(destPath, file.Name);
                    if (File.Exists(destFile))
                    {
                        // check last mod times
                        if (file.LastWriteTime > File.GetLastWriteTime(destFile))
                        {
                            // update
                            File.Copy(file.FullName, destFile, true);
                            log.Logit(op_upd, file.FullName, destFile);
                        }
                        else
                        {
                            log.Logit(op_eq, file.FullName, destFile);
                        }
                    }
                    else
                    {
                        // create
                        File.Copy(file.FullName, destFile);
                        log.Logit(op_add, file.FullName, destFile);
                    }
                }

                // Folders
                DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
                foreach (DirectoryInfo subDirectory in subDirectories)
                {
                    SyncSubDirectory(log, subDirectory, Path.Combine(destPath, subDirectory.Name)); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void SyncSubDirectory(Log log, DirectoryInfo directory, string destPath)
        {
            try
            {
                string destFile;
                //Debug.WriteLine(directory.FullName);

                if (!Directory.Exists(destPath))
                {
                    Directory.CreateDirectory(destPath);
                    log.Logit(op_add, directory.FullName, destPath);
                }

                // Files
                FileInfo[] files = directory.GetFiles();
                foreach (FileInfo file in files)
                {
                    // action
                    //Debug.WriteLine(file.FullName);
                    destFile = Path.Combine(destPath, file.Name);
                    if (File.Exists(destFile))
                    {
                        // check last mod times
                        if (file.LastWriteTime > File.GetLastWriteTime(destFile))
                        {
                            // update
                            File.Copy(file.FullName, destFile, true);
                            log.Logit(op_upd, file.FullName, destFile);
                        }
                        else
                        {
                            log.Logit(op_eq, file.FullName, destFile);
                        }
                    }
                    else
                    {
                        // create
                        File.Copy(file.FullName, destFile);
                        log.Logit(op_add, file.FullName, destFile);
                    }
                }

                // Folders
                DirectoryInfo[] subDirectories = directory.GetDirectories();
                foreach (DirectoryInfo subDirectory in subDirectories)
                {
                    //Debug.WriteLine(subDirectory.FullName);
                    SyncSubDirectory(log, subDirectory, Path.Combine(destPath, subDirectory.Name));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
