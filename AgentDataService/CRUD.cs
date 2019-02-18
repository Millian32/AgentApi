using System;
using IO = System.IO.File;

namespace DataService
{
    public static class CRUD
    {
        public static bool WriteConfigDataToFile(string data, string path)
        {   //would need to lock if sticking with files
            if (string.IsNullOrEmpty(data)) { return false; }
            if (string.IsNullOrEmpty(path)) { return false; }

            try
            {
                IO.WriteAllText(path, data);
            }
            catch (Exception)
            {   // todo: log issue writing file, permissions or in use issue
                return false;
            }

            return true;
        }
    }
}
