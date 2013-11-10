using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DistrictModel;

/// <summary>
/// Summary description for DownloadableFileInfo
/// </summary>
public class DownloadableFileInfo
{
    private Byte[] _fileByteArray;
    private String _fileName;
    private Boolean hasFile = false;

    public DownloadableFileInfo(district_event districtEvent)
    {
        districtEvent.file_repositoryReference.Load();

        if (districtEvent.file_repository != null)
        {
            this._fileByteArray = districtEvent.file_repository.file_blob;
            this._fileName = districtEvent.file_repository.file_name;
            this.hasFile = true;
        }

    }


    public String fileByteArrayToString()
    {
        System.Text.Encoding enc = System.Text.Encoding.ASCII;
        return enc.GetString(_fileByteArray);  
    }

    public  String parseApplicationType()
    {
        String post = "text";
        String ext = System.IO.Path.GetExtension(_fileName);

        switch (ext.ToLower())
        {
            case "doc":
                post = "msword";
                break;

            case "pdf":
                post = "pdf";
                break;

            case "xml":
                post = "xml";
                break;

            default:
                break;
        }

        return "application/" + post;
    }

    public Byte[] FileByteArray
    {
        get { return _fileByteArray; }
        set { _fileByteArray = value; }
    }    

    public String FileName
    {
        get { return _fileName; }
        set { _fileName = value; }
    }

    public Boolean HasFile
    {
        get { return hasFile; }
        set { hasFile = value; }
    }
}
