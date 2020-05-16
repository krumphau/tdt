from application import application
from flask import flash, request
import sqlhelper
from authhelper import require_appkey

@application.route('/relatedproject', methods=['POST'])
@require_appkey
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
@require_appkey
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
@require_appkey
def relatedproject(projectid):
    try:
        resp = sqlhelper.do_selectmultibyid("CALL usp_GetRelatedProjects(%s)", projectid)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)