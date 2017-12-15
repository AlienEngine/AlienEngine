using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AlienEngine.Core.IO
{
    public static class FileSystemManager
    {
        /// <summary>
        /// The root path of the file system.
        /// </summary>
        private static string _rootPath;

        /// <summary>
        /// The current working directory.
        /// </summary>
        private static string _currentWorkingDirectory;

        /// <summary>
        /// The list of aliases.
        /// </summary>
        private static Dictionary<string, string> _aliases;

        /// <summary>
        /// The root path of the file system
        /// </summary>
        public static string RootPath => _rootPath;

        /// <summary>
        /// The current working directory.
        /// </summary>
        public static string CurrentWorkingDirectory => _currentWorkingDirectory;

        /// <summary>
        /// The list of aliases.
        /// </summary>
        public static Dictionary<string, string> Aliases => _aliases;

        static FileSystemManager()
        {
            _aliases = new Dictionary<string, string>();
        }

        /// <summary>
        /// Sets the root path.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static void SetRootPath(string path)
        {
            if (Exists(path))
            {
                _rootPath = CleanPath(path);
            }
        }

        /// <summary>
        /// Sets the current working directory.
        /// </summary>
        /// <param name="path"></param>
        public static void SetWorkingDir(string path)
        {
            _currentWorkingDirectory = path;
        }

        /// <summary>
        /// Add a new alias.
        /// </summary>
        /// <param name="key">The key of the alias.</param>
        /// <param name="value">The value of the alias.</param>
        public static void NewAlias(string key, string value)
        {
            if (value[0] == '/')
            {
                value = value.Substring(0, -1);
            }

            _aliases.Add(key, value);
        }

        /// <summary>
        /// Creates a new file.
        /// </summary>
        /// <param name="path">The path of the new file.</param>
        /// <param name="recursive">Define if we have to create parent directories.</param>
        public static bool Mkfile(string path, bool recursive = false)
        {
            var parentDir = Dirname(path);

            if (!Exists(parentDir))
            {
                if (recursive)
                {
                    Mkdir(parentDir, true);
                }
                else
                {
                    throw new DirectoryNotFoundException($"Cannot create file \"{path}\" (parent directory \"{parentDir}\" doesn't exist)");
                }
            }

            var internalPath = _toInternalPath(path);

            try
            {
                var file = File.Create(internalPath);
                file.Close();

                return true;
            }
            catch (Exception e)
            {
                throw new Exception($"Cannot create the file {path}", e);
            }
        }

        /// <summary>
        /// Creates a new file.
        /// </summary>
        /// <param name="path">The path of the new file.</param>
        /// <param name="recursive">Define if we have to create parent directories.</param>
        public static bool CreateFile(string path, bool recursive = false)
        {
            return Mkfile(path, recursive);
        }

        /// <summary>
        /// Reads the file's contents.
        /// </summary>
        /// <param name="path">The path of the fle.</param>
        public static string ReadFileAsString(string path)
        {
            var internalPath = _toInternalPath(path);
            var stream = File.OpenRead(internalPath);

            if (!IsRemote(path) && !stream.CanRead)
            {
                stream.Close();
                throw _accessDeniedException(path, "read");
            }

            stream.Close();

            try
            {
                return File.ReadAllText(path);
            }
            catch (Exception e)
            {
                throw new Exception($"Cannot read the file \"{path}\"", e);
            }
        }

        public static bool WriteFile(string path, string data, bool append = false)
        {
            var internalPath = _toInternalPath(path);

            if (append)
            {
                var contents = ReadFileAsString(path);
                data = contents + data;

                try
                {
                    File.WriteAllText(internalPath, data);
                    return true;
                }
                catch (Exception e)
                {
                    throw new Exception($"Cannot write the file \"{path}\"");
                }
            }
            else
            {
                if (Exists(path))
                {
                    var stream = File.OpenWrite(internalPath);
                    if (!IsRemote(path) && !stream.CanWrite)
                    {
                        stream.Close();
                        throw _accessDeniedException(path);
                    }
                }
                else
                {
                    Mkfile(path, true);
                }

                try
                {
                    File.WriteAllText(internalPath, data);
                    return true;
                }
                catch (Exception e)
                {
                    throw new Exception($"Cannot write the file \"{path}\"");
                }
            }

            return false;
        }

        public static bool Delete(string path)
        {
            var internalPath = _toInternalPath(path);

            if (Exists(path))
            {
                if (IsDirectory(path))
                {
                    var subfiles = ReadDirectory(path);
                    foreach (string file in subfiles)
                    {
                        Delete(file);
                    }

                    try
                    {
                        Directory.Delete(internalPath);
                        return true;
                    }
                    catch (Exception e)
                    {
                        throw new Exception($"Cannot delete the directory \"{path}\".", e);
                    }
                }
                else
                {
                    try
                    {
                        File.Delete(internalPath);
                        return true;
                    }
                    catch (Exception e)
                    {
                        throw new Exception($"Cannot delete the file \"{path}\".", e);
                    }
                }
            }
            else
            {
                throw new Exception($"The file or folder \"{path}\" doesn't exists.");
            }
        }

        public static bool Move(string from, string to)
        {

        }

        public static bool IsDirectory(string path)
        {
            return Directory.Exists(path);
        }

        public static bool Exists(string path)
        {
            return File.Exists(path) || Directory.Exists(path);
        }

        /// <summary>
        /// Constructs a path from parts.
        /// </summary>
        /// <param name="parts">The parts of the path.</param>
        public static string MakePath(params string[] parts)
        {
            return string.Join('\\', parts);
        }

        public static bool Mkdir(string path)
        {

        }

        public static byte[] ReadFileAsBytes(string path)
        {
            return File.ReadAllBytes(path);
        }

        public static FileStream Read(string path)
        {
            return File.OpenRead(path);
        }

        public static async Task<string> AsyncReadFileAsString(string path)
        {
            return await Task.Run(() => ReadFileAsString(path));
        }

        private static void _accessDeniedException(string path, string action = "write")
        {
            var msg = $"Cannot {action} the file \"{path}\": permission denied";
            if (!IsRemote(path))
            {
                msg += $" (The web server user cannot {action} files, chmod needed)";
            }
            return new Exception(msg);
        }

    }
}
