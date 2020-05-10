from application import application
from flask import flash, request
import sqlhelper

@application.route('/projectvisit', methods=['POST'])
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
def projectvisit(projectid):
    try:
        resp = sqlhelper.do_selectmultibyid("CALL usp_GetVisitsForProject(%s)", projectid)
        resp.status_code = 200
        return resp
    except Exception as e:
        print(e)