using DiscScan.Models;
using System;
using System.Collections.Generic;
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
        public List<ScanInfo> ScanDirectory(string path)
        {
            try
            {
                long driveSize = 0;
                List<ScanInfo> scanInfos = new List<ScanInfo>();
                //string? drive = Path.GetPathRoot(path);

                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                //Debug.WriteLine(directoryInfo.FullName);
                ScanInfo root = new ScanInfo(ScanInfo.InfoTypes.Folder, directoryInfo.FullName, directoryInfo.Name, "", directoryInfo.LastWriteTime,0);
                scanInfos.Add(root);
                // Files
                FileInfo[] files = directoryInfo.GetFiles();
                foreach (FileInfo file in files)
                {
                    // action
                    //Debug.WriteLine(file.FullName);
                    ScanInfo fileInfo = new ScanInfo(ScanInfo.InfoTypes.File, directoryInfo.FullName, file.Name, file.Extension, file.LastWriteTime, file.Length);
                    scanInfos.Add(fileInfo);
                    driveSize += file.Length;
                }

                // Folders
                DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
                foreach (DirectoryInfo subDirectory in subDirectories) 
                {
                    driveSize += ScanSubDirectory(scanInfos,subDirectory);
                }
                root.Size = driveSize;
                return scanInfos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        internal long ScanSubDirectory(List<ScanInfo> scanInfos, DirectoryInfo directory)
        {
            try
            {
                long driveSize = 0;

                //Debug.WriteLine(directory.FullName);
                ScanInfo root = new ScanInfo(ScanInfo.InfoTypes.Folder, directory.FullName, directory.Name, "", directory.LastWriteTime, 0);
                scanInfos.Add(root);

                // Files
                FileInfo[] files = directory.GetFiles();
                foreach (FileInfo file in files)
                {
                    // action
                    //Debug.WriteLine(file.FullName);
                    ScanInfo fileInfo = new ScanInfo(ScanInfo.InfoTypes.File, directory.FullName, file.Name, file.Extension, file.LastWriteTime, file.Length);
                    scanInfos.Add(fileInfo);
                    driveSize += file.Length;
                }

                // Folders
                DirectoryInfo[] subDirectories = directory.GetDirectories();
                foreach (DirectoryInfo subDirectory in subDirectories)
                {
                    //Debug.WriteLine(subDirectory.FullName);
                    driveSize += ScanSubDirectory(scanInfos, subDirectory);
                }
                root.Size = driveSize;
                return driveSize;
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message);
                return 0;
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
                log.Logit(op_upd, sourcePath, destPath);

                // Files
                FileInfo[] files = directoryInfo.GetFiles();
                foreach (FileInfo file in files)
                {
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

                if (Directory.Exists(destPath))
                {
                    log.Logit(op_eq, directory.FullName, destPath);
                }
                else
                {
                    Directory.CreateDirectory(destPath);
                    Directory.SetCreationTime(destPath, directory.CreationTime);
                    log.Logit(op_add, directory.FullName, destPath);
                }

                // Files
                FileInfo[] files = directory.GetFiles();
                foreach (FileInfo file in files)
                {
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
