import os
from application import application
from flask import flash, request, redirect, send_file, render_template
import sqlhelper
from filehelper import list_files, download_file, upload_file, download_file_from_folder

UPLOAD_FOLDER = "uploads"
BUCKET = "tdt-document-files"

@application.route('/projectdocument', methods=['POST'])
def projectdocument_add():
    try:
        content = request.json
        _projectid = content['ProjectId']
        _docname = content['DocName']
        _filepath = content['FilePath']
        _description = content['Description']
        _doccategory = content['DocCategory']

        sql = "CALL usp_AddDocumentToProject(%s, %s, %s, %s, %s)"
        data = (_projectid, _docname, _filepath, _description, _doccategory,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)        

@application.route('/projectdocument/<int:id>', methods=['DELETE'])
def delete_projectdocument(id):
    try:
        sql = "CALL usp_RemoveDocumentFromProject(%s)"
        data = (id,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/projectdocument/<int:projectid>', methods=['GET'])
def projectdocument(projectid):
    try:
        resp = sqlhelper.do_selectmultibyid("CALL usp_GetDocsForProject(%s)", projectid)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)


@application.route("/storage")
def storage():
    contents = list_files(BUCKET)
    return render_template('storage.html', contents=contents)

@application.route("/upload/<projectid>", methods=['POST'])
def upload(projectid):
    if request.method == "POST":
        f = request.files['file']
        
        f.save(os.path.join(UPLOAD_FOLDER, f.filename))
        upload_file(f"{UPLOAD_FOLDER}/{f.filename}", BUCKET, projectid)

        return f.filename


@application.route("/download/<filename>", methods=['GET'])
def download(filename):
    if request.method == 'GET':
        output = download_file(filename, BUCKET)

        return send_file(output, as_attachment=True)

@application.route("/download/<foldername>/<filename>", methods=['GET'])
def download_fromfolder(foldername, filename):
    if request.method == 'GET':
        output = download_file_from_folder(filename, foldername, BUCKET)

        return send_file(output, as_attachment=True)
