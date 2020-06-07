
using boto3;

using System.Collections.Generic;

public static class filehelper {
    
    // 
    //     Function to upload a file to an S3 bucket
    //     
    public static void upload_file(object file_name, object bucket, object folder_name) {
        var object_name = file_name;
        if (folder_name) {
            object_name = file_name.replace("uploads", folder_name);
        }
        var s3_client = boto3.client("s3");
        var response = s3_client.upload_file(file_name, bucket, object_name);
        return response;
    }
    
    // 
    //     Function to download a given file from an S3 bucket
    //     
    public static string download_file(object file_name, object bucket) {
        var s3 = boto3.resource("s3");
        var output = "downloads/" + file_name;
        s3.Bucket(bucket).download_file(file_name, output);
        return output;
    }
    
    // 
    //     Function to download a given file from an S3 bucket
    //     
    public static string download_file_from_folder(object file_name, object folder_name, object bucket) {
        var s3 = boto3.resource("s3");
        var output = "downloads/" + file_name;
        s3.Bucket(bucket).download_file(folder_name + "/" + file_name, output);
        return output;
    }
    
    // 
    //     Function to list files in a given S3 bucket
    //     
    public static List<object> list_files(object bucket) {
        var s3 = boto3.client("s3");
        var contents = new List<object>();
        foreach (var item in s3.list_objects(Bucket: bucket)["Contents"]) {
            contents.append(item);
        }
        return contents;
    }
}
