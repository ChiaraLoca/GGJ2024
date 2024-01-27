using System.IO;
using System.Text;
using UnityEngine;

public class StramingAssetsManager
{
    public static void CreateFile(string directoryName, string fileName, string content)
    {
        string dir = Path.Combine(Application.streamingAssetsPath, directoryName);
        string dirAndFileName = Path.Combine(dir, fileName);

        if (!Directory.Exists(dir))
        {

            Directory.CreateDirectory(dir);
        }
        else
        {


            if (File.Exists(dirAndFileName))
            {
                File.Delete(dirAndFileName);
            }
        }

        using (FileStream fs = File.Create(dirAndFileName))
        {
            byte[] contentByte = new UTF8Encoding().GetBytes(content);
            fs.Write(contentByte, 0, contentByte.Length);


        }


    }

    public static FileInfo GetFileInDirectory(string directoryName, string fileName)
    {

        FileInfo filesInfo = null;

        string dir = Path.Combine(Application.streamingAssetsPath, directoryName);
        if (!Directory.Exists(dir))
        {
            return null;
        }
        DirectoryInfo directoryInfo = new DirectoryInfo(dir);
        FileInfo[] allFiles = directoryInfo.GetFiles(".");
        foreach (FileInfo t in allFiles)
        {
            if (!t.Name.Contains("meta") && t.Name.Equals(fileName))
            {
                filesInfo = t;
                return filesInfo;
            }
        }


        return filesInfo;
    }

    
}