from application import application
from flask import flash, request
import sqlhelper
from authhelper import require_appkey

@application.route('/projectvisit', methods=['POST'])
@require_appkey
def projectvisit_add():
    try:
        content = request.json
        _projectId = content['ProjectId']
        _visitstart = content['VisitStart']
        _visitend = content['VisitEnd']
        _visitor = content['Visitor']

        sql = "CALL usp_AddVisitToProject(%s, %s, %s, %s)"
        data = (_projectId, _visitstart, _visitend,_visitor,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)        

@application.route('/projectvisit/<int:id>', methods=['PUT'])
@require_appkey
def projectvisit_update(id):
    try:
        content = request.json
        _visitstart = content['VisitStart']
        _visitend = content['VisitEnd']
        _visitor = content['Visitor']

        sql = "CALL usp_UpdateVisit(%s, %s, %s, %s)"
        data = (id, _visitstart, _visitend,_visitor,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e) 

@application.route('/projectvisit/<int:id>', methods=['DELETE'])
@require_appkey
def delete_projectvisit(id):
    try:
        sql = "CALL usp_RemoveVisitFromProject(%s)"
        data = (id,)
        resp = sqlhelper.do_writedata(sql, data)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)

@application.route('/projectvisit/<int:projectid>', methods=['GET'])
@require_appkey
def projectvisit(projectid):
    try:
        resp = sqlhelper.do_selectmultibyid("CALL usp_GetVisitsForProject(%s)", projectid)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)