from application import application
from flask import flash, request
import sqlhelper

@application.route('/relatedproject', methods=['POST'])
def relatedproject_add():
    try:
        content = request.json
        _projectid = content['ProjectId']
        _related = content['RelationshipKey']

        sql = "CALL usp_AddRelatedProject(%s, %s)"
        data = (_projectid, _related,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)        

@application.route('/relatedproject/<int:id>', methods=['DELETE'])
def delete_relatedproject(id):
    try:
        sql = "CALL usp_RemoveRelatedProject(%s)"
        data = (id,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/relatedproject/<int:projectid>', methods=['GET'])
def relatedproject(projectid):
    try:
        resp = sqlhelper.do_selectmultibyid("CALL usp_GetRelatedProjects(%s)", projectid)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)