using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

public class Files
{
    Dictionary<string, Permissions> database = new Dictionary<string, Permissions>();
  
    public void CreateFile(string filename)
    {
       database.Add(filename, PermissionBuilder.FromName("Default"));
    }

    public void AddPermission(string filename, string permissionName)
    {
        database[filename] |= PermissionBuilder.FromName(permissionName);
    }

    public void RemovePermission(string filename, string permissionName)
    {
        database[filename] = (PermissionBuilder.FromName(permissionName) ^ Permissions.All) & database[filename];
    }

    public override string ToString()
    {
        string result = "";
        foreach (var element in database)
        {
            var valueArray = element.Value.ToString().Split(',');
            string values = "";
            for (int i = 0; i < valueArray.Length; i++)
            {
                values += valueArray[i];
            }

            result += element.Key + ": " + values + "\n";
        }
        return result;
    }
}