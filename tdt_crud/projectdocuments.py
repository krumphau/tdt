from app import app
from flask import flash, request
import sqlhelper

@app.route('/projectdocument', methods=['POST'])
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

@app.route('/projectdocument/<int:id>', methods=['DELETE'])
def delete_projectdocument(id):
    try:
        sql = "CALL usp_RemoveDocumentFromProject(%s)"
        data = (id,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@app.route('/projectdocument/<int:projectid>', methods=['GET'])
def projectdocument(projectid):
    try:
        resp = sqlhelper.do_selectmultibyid("CALL usp_GetDocsForProject(%s)", projectid)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)